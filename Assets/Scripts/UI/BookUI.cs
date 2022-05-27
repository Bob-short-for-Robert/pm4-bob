using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class BookUI : MonoBehaviour
    {
        [Header("Name of Game Scene")] private const string GAME_SCENE = "Main";

        public void NextRun()
        {
            GameController.Instance.ResetScore();
            SceneManager.LoadScene(GAME_SCENE);
        }
    }
}
