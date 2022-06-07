using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("")]
public class UIScript : MonoBehaviour
{
    public GameType gameType = GameType.Score;

    public Text health, version;
    public GameObject statsPanel;

    private int playersHealth = 12;

    private bool gameOver = false; //this gets changed when the game is won OR lost

    private void Start()
    {
        version.text = Application.version;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Book");
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