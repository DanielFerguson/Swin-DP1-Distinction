using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    // UI Elements
    [Header("UI Elements")]
    public Text Credits;
    public Text Debt;

    private float playerSpeed = 120f;
    private float rotateSpeed = 120f;

    // GameObject Components
    private Rigidbody2D Rigidbody;
    private SpriteRenderer Renderer;

    // GameObject Variables
    private Class.ClassManager _playerClass;
    private string playerName;
    private int playerLevel = 0;
    private int playerDebt;
    private int unitCreditsRequired;
    private bool canMove = true;
    internal PlayerChoice _playerChoice;
    public bool hasWon = false;

    void Start()
    {
        // Fetch required components attached to GameObject
        Rigidbody = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();

        // Find object name
        playerName = transform.name;

        // Load selected character choice & class
        LoadPlayerChoice();

        // Load selected class attributes
        SetupPlayer();

        hasWon = false;
    }
    void Update()
    {
        if (canMove)
        {
            if (playerName == "Player 1")
            {
                // Rotation
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);
                }

                // Movement
                if (Input.GetKey(KeyCode.W))
                {
                    Rigidbody.velocity = transform.up * playerSpeed * Time.deltaTime;
                }
                else
                {
                    Rigidbody.velocity = Vector2.zero;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    Rigidbody.velocity = -transform.up * playerSpeed * Time.deltaTime;
                }
            }
            else if (playerName == "Player 2")
            {
                // Rotation
                if (Input.GetKey(KeyCode.LeftArrow))
                    transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);

                if (Input.GetKey(KeyCode.RightArrow))
                    transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);

                // Forward Movement
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Rigidbody.velocity = transform.up * playerSpeed * Time.deltaTime;
                }
                else
                {
                    Rigidbody.velocity = Vector2.zero;
                }

                // Backwards 
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Rigidbody.velocity = -transform.up * playerSpeed * Time.deltaTime;
                }
            }
        }
        else
        {
            // Stop player movement
            Rigidbody.velocity = Vector2.zero;
        }

        checkWon();
    }

    // Hovering over a token
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Consume Unit Credits
        if (other.gameObject.tag == "Unit Credits")
        {
            // Destroy GameObject
            Destroy(other.gameObject);

            // Decrement unit credits required
            unitCreditsRequired -= 10;
            Credits.text = "Credits Needed: " + unitCreditsRequired.ToString();
        }

        // Consume job applications
        else if (other.gameObject.tag == "Job Application")
        {
            // Destroy GameObject
            Destroy(other.gameObject);

            // Reduce debt
            playerDebt -= 100;
            Debt.text = "Debt: $" + playerDebt.ToString();

            // Freeze player in position for two seconds
            StartCoroutine("FreezePlayer");
        }
    }

    // Game Manager Checks
    private void checkWon()
    {
        if (playerDebt <= 0) hasWon = true;
        if (playerLevel == 4 && unitCreditsRequired < 0) hasWon = true;
    }

    // Internal Tools
    private void LoadPlayerChoice()
    {
        // Get string variable of class
        switch (playerName)
        {
            case "Player 1":
                // Get Player 1 Class
                switch (PlayerPrefs.GetString("Player1Class"))
                {
                    case "Accounting":
                        _playerChoice = PlayerChoice.Accounting;
                        _playerClass = Class.Accounting;
                        break;
                    case "ComputerScience":
                        _playerChoice = PlayerChoice.ComputerScience;
                        _playerClass = Class.ComputerScience;
                        break;
                    case "Medical":
                        _playerChoice = PlayerChoice.Medical;
                        _playerClass = Class.Medicine;
                        break;
                    case "Teaching":
                        _playerChoice = PlayerChoice.Teaching;
                        _playerClass = Class.Teaching;
                        break;
                }
                break;

            case "Player 2":
                // Get Player 2 Class
                switch (PlayerPrefs.GetString("Player2Class"))
                {
                    case "Accounting":
                        _playerChoice = PlayerChoice.Accounting;
                        _playerClass = Class.Accounting;
                        break;
                    case "ComputerScience":
                        _playerChoice = PlayerChoice.ComputerScience;
                        _playerClass = Class.ComputerScience;
                        break;
                    case "Medical":
                        _playerChoice = PlayerChoice.Medical;
                        _playerClass = Class.Medicine;
                        break;
                    case "Teaching":
                        _playerChoice = PlayerChoice.Teaching;
                        _playerClass = Class.Teaching;
                        break;
                }
                break;
        }
    }

    private void SetupPlayer()
    {
        Renderer.sprite = Resources.Load<Sprite>(_playerClass._TAFE._spriteLocation);       // Sprite
        playerLevel = _playerClass._TAFE._level;                                            // Level
        playerSpeed = playerSpeed * _playerClass._TAFE._speed;                              // Speed
        playerDebt = _playerClass._TAFE._debtAdd;                                           // Debt
        unitCreditsRequired = _playerClass._TAFE._creditsReq;                               // Required Unit Scores
    }

    private string LoadPlayerSprite()
    {
        switch (playerLevel)
        {
            case 0: return _playerClass._TAFE._spriteLocation;
            case 1: return _playerClass._DIPL._spriteLocation;
            case 2: return _playerClass._BACH._spriteLocation;
            case 3: return _playerClass._HONR._spriteLocation;
            case 4: return _playerClass._PHD._spriteLocation;
            default: return _playerClass._TAFE._spriteLocation;
        }
    }

    IEnumerator FreezePlayer()
    {
        canMove = false;
        yield return new WaitForSeconds(JobsHandler.WaitTime);
        canMove = true;
    }
}
