using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Player GameObjects")]
    public GameObject player1;
    public GameObject player2;

    [Header("High Score UI")]
    public GameObject highScoreUI;
    public GameObject playerName;

    private TextMeshProUGUI playerNameText;

    private Player p1Object;
    private Player p2Object;

    private Player winningPlayer;
    private bool gameWon = false;

    void Start()
    {
        playerNameText = playerName.GetComponent<TextMeshProUGUI>();

        // Reset the gameWon at each new game
        gameWon = false;

        // Make sure game timeScale
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Get Player objects from GameObject
        p1Object = player1.GetComponent<Player>();
        p2Object = player2.GetComponent<Player>();

        GameWatcher();
    }

    private void GameWatcher()
    {
        // Check if either player has won
        if (p1Object.controller.hasWon || p2Object.controller.hasWon)
        {
            // Record winner
            if (p1Object.controller.hasWon) winningPlayer = p1Object;
            else if (p2Object.controller.hasWon) winningPlayer = p2Object;

            EndGame();
        }
    }

    void EndGame()
    {
        playerNameText.text = winningPlayer.name.ToString();
        highScoreUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

        gameWon = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
