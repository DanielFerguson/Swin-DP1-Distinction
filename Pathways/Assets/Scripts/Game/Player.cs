using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour {

    // UI Elements
    [Header("UI Elements")]
    public Text Course;
    public Text Credits;
    public Text Debt;

    // Sound Elements
    [Header("Sound Elements")]
    public AudioClip moneySound;
    public AudioClip creditSound;
    private AudioSource audioSource;

    [Header("DEBUG Purposes")]
    public bool hasWon = false;

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


    void Start()
    {
        // Fetch required components attached to GameObject
        Rigidbody = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();

        // Sounds
        audioSource = GetComponent<AudioSource>();

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
                if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);
                if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);

                // Movement
                if (Input.GetKey(KeyCode.S)) Rigidbody.velocity = -transform.up * playerSpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.W)) Rigidbody.velocity = transform.up * playerSpeed * Time.deltaTime;
                else Rigidbody.velocity = Vector2.zero;
            }

            else if (playerName == "Player 2")
            {
                // Rotation
                if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed, Space.World);
                if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotateSpeed, Space.World);

                // Movement
                if (Input.GetKey(KeyCode.DownArrow)) Rigidbody.velocity = -transform.up * playerSpeed * Time.deltaTime;
                if (Input.GetKey(KeyCode.UpArrow)) Rigidbody.velocity = transform.up * playerSpeed * Time.deltaTime;
                else Rigidbody.velocity = Vector2.zero;
            }
        }

        else
        {
            // Stop player movement
            Rigidbody.velocity = Vector2.zero;
        }

        CheckIfWon();
    }

    // Token Collection
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Consume Unit Credits
        if (other.gameObject.tag == "Unit Credits")
        {
            // Destroy GameObject
            Destroy(other.gameObject);

            // Decrement unit credits required
            unitCreditsRequired -= 25;
            audioSource.PlayOneShot(creditSound);
            Credits.text = "Credits Needed: " + unitCreditsRequired.ToString();

            // Chech to see if user has upgraded their degree
            CheckDegree();
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
        } else if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
         
            playerDebt += 100;
            audioSource.PlayOneShot(creditSound);
            Debt.text = "Debt: $" + playerDebt.ToString();
        }
    }

    // Game Manager Checks
    private void CheckDegree()
    {
        // Check to see if the player has recieved all their units
        if (unitCreditsRequired <= 0)
        {
            // Update Player Level. Also check to see if they have completed their degree
            if (playerLevel < 4) playerLevel++;
            else CheckIfWon();

            // Update Required Unit Credits with degree requirements
            UpdateRequiredUnitCredits(playerLevel);

            // Change UI status of Player degree
            UpdateDegree(playerLevel);
        }
    }
    private void CheckIfWon()
    {
        // Does the player have no debt?
        if (playerDebt <= 0) hasWon = true;

        // Does the player have a PHD and all necessary credits?
        if (playerLevel == 4 && unitCreditsRequired <= 0) hasWon = true;
    }
    private void UpdateRequiredUnitCredits(int _playerLevel)
    {
        int newCreditRequirements = 0;

        // Get Unit Credit Requirements for the next degree level
        switch (_playerLevel)
        {
            // DIPLOMA
            case 1:
                newCreditRequirements = _playerClass._DIPL._creditsReq;
                break;

            // BACHELORS
            case 2:
                newCreditRequirements = _playerClass._BACH._creditsReq;
                break;

            // HONORS
            case 3:
                newCreditRequirements = _playerClass._HONR._creditsReq;
                break;

            // PHD
            case 4:
                newCreditRequirements = _playerClass._PHD._creditsReq;
                break;
        }

        unitCreditsRequired += newCreditRequirements;

        // Update UI to reflect new requirements
        Credits.text = "Credits Needed: " + unitCreditsRequired;
    }
    private void UpdateDegree(int _playerLevel)
    {
        switch (_playerLevel)
        {
            case 1:
                Course.text = "DIPLOMA";
                playerDebt += _playerClass._DIPL._debtAdd;
                break;

            case 2:
                Course.text = "BACHELORS";
                playerDebt += _playerClass._BACH._debtAdd;
                break;

            case 3:
                Course.text = "HONORS";
                playerDebt += _playerClass._HONR._debtAdd;
                break;

            case 4:
                Course.text = "PHD";
                playerDebt += _playerClass._PHD._debtAdd;
                break;
        }

        Debt.text = "Debt: " + playerDebt.ToString();
    }

    // Internal Tools
    private void LoadPlayerChoice()
    {
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
    IEnumerator FreezePlayer()
    {
        canMove = false;
        yield return new WaitForSeconds(JobsHandler.WaitTime);
        canMove = true;
        audioSource.PlayOneShot(moneySound);
    }
}
