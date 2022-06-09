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
            Log("START NEW GAME", LogType.Log);
        }

        public void Quit()
        {
            Log("QUIT GAME", LogType.Log);
            Application.Quit();
        }
    }
}
