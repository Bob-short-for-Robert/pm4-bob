using Controller;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using static BoBLogger.Logger;

namespace UI.Menu
{
    public class BookUI : MonoBehaviour
    {
        [Header("Name of Game Scene")] private const string GameScene = "Main";

        public void NextRun()
        {
            GameController.Instance.ResetScore();
            SceneManager.LoadScene(GameScene);
            Log("NEW RUN STARTED", LogLevel.Info);
        }
    }
}
