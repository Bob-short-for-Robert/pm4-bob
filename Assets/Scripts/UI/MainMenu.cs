using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BOB_Logger;
public class MainMenu : MonoBehaviour
{
    [Header("Name of Game Scene")]
    private const string GAME_SCENE = "Main";
        
    public void PlayGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
        Log("START NEW GAME", LogLevel.Info);
    }

    public void Quit()
    {
        Log("QUIT GAME", LogLevel.Info);
        Application.Quit();
    }
}
