using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BOB_Logger;

namespace UI
{
    public class BookUI : MonoBehaviour
    {
        [Header("Name of Game Scene")] private const string GAME_SCENE = "Main";

        public void NextRun()
        {
            GameController.Instance.ResetScore();
            SceneManager.LoadScene(GAME_SCENE);
            Log("NEW RUN STARTED", LogLevel.Info);
        }
    }
}
