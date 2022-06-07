using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BoBLogger.Logger;

namespace UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Name of Game Scene")] private const string GameScene = "Main";

        public void PlayGame()
        {
            SceneManager.LoadScene(GameScene);
            Log("START NEW GAME", LogLevel.Info);
        }

        public void Quit()
        {
            Log("QUIT GAME", LogLevel.Info);
            Application.Quit();
        }
    }
}
