using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("")]
public class UIScript : MonoBehaviour
{
    public GameType gameType = GameType.Score;

    // If the scoreToWin is -1, the game becomes endless (no win conditions, but you could do game over)
    public int scoreToWin = 5;

    public Text health, score, finalscore;
    public Text winLabel;
    public GameObject statsPanel, gameOverPanel, winPanel;

    // Internal variables to keep track of score, health, and resources, win state
    private int scores = 0;
    private int playersHealth = 12;

    private bool gameOver = false; //this gets changed when the game is won OR lost

    private void Start()
    {
        scores = 0;
        score.text = scores.ToString();
        finalscore.text = scores + "/" + scoreToWin;
    }

    //version of the one below with one parameter to be able to connect UnityEvents
    public void AddOnePoint()
    {
        AddPoints(1);
    }

    public void AddPoints(int amount = 1)
    {
        scores += amount;

        score.text = scores.ToString();
        finalscore.text = scores + "/" + scoreToWin;

        if (gameType == GameType.Score
            && scores >= scoreToWin)
        {
            GameWon();
        }
    }

    public void GameWon()
    {
        // only set game over UI if game is not over
        if (!gameOver)
        {
            gameOver = true;
            winLabel.text = "You win!";
            statsPanel.SetActive(false);
            winPanel.SetActive(true);
        }
    }

    public void GameOver()
    {
        // only set game over UI if game is not over
        if (!gameOver)
        {
            gameOver = true;
            statsPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }

    public void SetHealth(int amount)
    {
        playersHealth = amount;
        health.text = playersHealth.ToString();
    }

    public void ChangeHealth(int change)
    {
        SetHealth(playersHealth + change);

        if (gameType != GameType.Endless
            && playersHealth <= 0)
        {
            GameOver();
        }
    }

    public enum GameType
    {
        Score = 0,
        Life,
        Endless
    }
}