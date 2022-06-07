using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool _isGamePaused;

        [SerializeField] private GameObject pauseMenu;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (_isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        private void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _isGamePaused = false;
        }

        private void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isGamePaused = true;
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
