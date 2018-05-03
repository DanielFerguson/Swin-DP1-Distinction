using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCustomization : MonoBehaviour {
    // TODO: Fix alpha channel on select

    [Header("Player 1")]
    public Image wImage;
    public Image aImage;
    public Image sImage;
    public Image dImage;

    [Header("Player 2")]
    public Image upImage;
    public Image downImage;
    public Image leftImage;
    public Image rightImage;

    [Header("Default Selection Settings")]
    public Color avaliable = new Color(0f, 0f, 0f, 0.3f);
    public Color selected = new Color(0f, 0f, 0f, 0.1f);

    [Header("Error Handling System")]
    public GameObject ErrorMessageCanvas;
    public GameObject Player1Error;
    public GameObject Player2Error;
    public GameObject BothPlayerError;
    public GameObject ContinueMessage;

    private PlayerChoice player1Choice = PlayerChoice.notYetSelected;
    private PlayerChoice player2Choice = PlayerChoice.notYetSelected;

    private bool isErrorShowing = false;


    public void Start()
    {
        // Reset images
        ResetPlayerSelection(0);
    }
    public void Update()
    {
        // Check if in error state
        if (!isErrorShowing)
        {
            // Player 1 Selections
            if (Input.GetKeyDown(KeyCode.W))
            {
                player1Choice = PlayerChoice.ComputerScience;
                ResetPlayerSelection(1);
                wImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                player1Choice = PlayerChoice.Teaching;
                ResetPlayerSelection(1);
                aImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                player1Choice = PlayerChoice.Accounting;
                ResetPlayerSelection(1);
                sImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                player1Choice = PlayerChoice.Accounting;
                ResetPlayerSelection(1);
                dImage.color = selected;
            }

            // Player 2 Selections
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player2Choice = PlayerChoice.ComputerScience;
                ResetPlayerSelection(2);
                upImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player2Choice = PlayerChoice.Accounting;
                ResetPlayerSelection(2);
                downImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player2Choice = PlayerChoice.Teaching;
                ResetPlayerSelection(2);
                leftImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player2Choice = PlayerChoice.Medical;
                ResetPlayerSelection(2);
                rightImage.color = selected;
            }
        }
        else
        {
            // Program is in error state

            // If key pressed, set all error related GameObjects to inactive
            if (Input.anyKeyDown)
            {
                ErrorMessageCanvas.SetActive(false);
                Player1Error.SetActive(false);
                Player2Error.SetActive(false);
                BothPlayerError.SetActive(false);
                ContinueMessage.SetActive(false);

                // Set errorState to false
                isErrorShowing = false;
            }
        }
    }

    // Save players class choices
    public void SaveToPlayerPreferences()
    {
        PlayerPrefs.SetString("Player1Class", player1Choice.ToString());
        PlayerPrefs.SetString("Player2Class", player2Choice.ToString());
    }

    // Reset selection
    public void ResetPlayerSelection (int player)
    {
        // Reset All
        if (player == 0)
        {
            wImage.color = avaliable;
            aImage.color = avaliable;
            sImage.color = avaliable;
            dImage.color = avaliable;
            upImage.color = avaliable;
            downImage.color = avaliable;
            leftImage.color = avaliable;
            rightImage.color = avaliable;
        }

        // Reset Player 1 Choice
        if (player == 1)
        {
            wImage.color = avaliable;
            aImage.color = avaliable;
            sImage.color = avaliable;
            dImage.color = avaliable;
        }

        // Reset Player 2 Choice
        if (player == 2)
        {
            upImage.color = avaliable;
            downImage.color = avaliable;
            leftImage.color = avaliable;
            rightImage.color = avaliable;
        }
    }
    public void PlayGame()
    {
        // Check to make sure both players have made a selection. If not, show an appropriate message

        // Both players have made a selection, proceed
        if (player1Choice != PlayerChoice.notYetSelected && 
            player2Choice != PlayerChoice.notYetSelected) {
            SaveToPlayerPreferences();  // Save player preferences
            SceneManager.LoadScene("Game"); // Load into Game scene

        } else {
            // Set isErrorShowing to True
            isErrorShowing = true;

            // Show the error message
            ErrorMessageCanvas.SetActive(true);
            ContinueMessage.SetActive(true);

            // Check which player hasnt made a selection
            if (player1Choice == PlayerChoice.notYetSelected && 
                player2Choice == PlayerChoice.notYetSelected) {
                
                // If neither player has made a choice
                BothPlayerError.SetActive(true);
            }
            if (player1Choice == PlayerChoice.notYetSelected &&
                player2Choice != PlayerChoice.notYetSelected) {
                
                // Player 1 hasnt made a choice
                Player1Error.SetActive(true);
            }
            if (player1Choice != PlayerChoice.notYetSelected &&
                player2Choice == PlayerChoice.notYetSelected) {
                
                // Player 2 hasnt made a choice
                Player2Error.SetActive(true);
            }
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
