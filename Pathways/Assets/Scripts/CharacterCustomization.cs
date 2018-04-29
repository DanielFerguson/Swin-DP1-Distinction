﻿using UnityEngine;
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
                // Update choiceSelection
                player1Choice = PlayerChoice.ComputerScience;

                // Reset all selections
                ResetPlayerSelection(1);

                // Change selection color
                wImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Update choiceSelection
                player1Choice = PlayerChoice.Teaching;

                // Reset all selections
                ResetPlayerSelection(1);

                // Change selection color
                aImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                // Update choiceSelection
                player1Choice = PlayerChoice.Accounting;

                // Reset all selections
                ResetPlayerSelection(1);

                // Change selection color
                sImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                // Update choiceSelection
                player1Choice = PlayerChoice.Accounting;

                // Reset all selections
                ResetPlayerSelection(1);

                // Change selection color
                dImage.color = selected;
            }

            // Player 2 Selections
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Update choiceSelection
                player2Choice = PlayerChoice.ComputerScience;

                // Reset all selections
                ResetPlayerSelection(2);

                // Change selection color
                upImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Update choiceSelection
                player2Choice = PlayerChoice.Accounting;

                // Reset all selections
                ResetPlayerSelection(2);

                // Change selection color
                downImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Update choiceSelection
                player2Choice = PlayerChoice.Teaching;

                // Reset all selections
                ResetPlayerSelection(2);

                // Change selection color
                leftImage.color = selected;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Update choiceSelection
                player2Choice = PlayerChoice.Medical;

                // Reset all selections
                ResetPlayerSelection(2);

                // Change selection color
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

    public void SaveToPlayerPreferences()   // Save players class choices
    {
        PlayerPrefs.SetString("Player1Class", player1Choice.ToString());
        PlayerPrefs.SetString("Player2Class", player2Choice.ToString());
    }   
    public void ResetPlayerSelection (int player)   // Reset selection
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
    public void PlayGame()  // Attached to Play Button to start game
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
                BothPlayerError.SetActive(true);                    // If neither player has made a choice

            }
            if (player1Choice == PlayerChoice.notYetSelected &&
                player2Choice != PlayerChoice.notYetSelected) {
                Player1Error.SetActive(true);                       // Player 1 hasnt made a choice
            }
            if (player1Choice != PlayerChoice.notYetSelected &&
                player2Choice == PlayerChoice.notYetSelected) {
                Player2Error.SetActive(true);                       // Player 2 hasnt made a choice
            }
        }
    }
    public void Back()  // Attached to Back Button to return to Main Menu
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()  // Attached to Quit Button to exit the application
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}