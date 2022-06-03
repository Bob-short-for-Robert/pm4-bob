using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Name of Game Scene")]
    private const string GAME_SCENE = "Main";
        
    public void playGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
