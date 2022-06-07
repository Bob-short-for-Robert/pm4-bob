using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Hud
{
    [AddComponentMenu("")]
    public class UIScript : MonoBehaviour
    {
        [SerializeField] private GameType gameType = GameType.Score;
        [SerializeField] private Text health, version;

        private int _playersHealth = 12;
        private bool _gameOver = false; //this gets changed when the game is won OR lost

        private void Start()
        {
            version.text = Application.version;
        }

        private static void GameOver()
        {
            SceneManager.LoadScene("Book");
        }

        public void SetHealth(int amount)
        {
            _playersHealth = amount;
            health.text = _playersHealth.ToString();
        }

        public void ChangeHealth(int change)
        {
            SetHealth(_playersHealth + change);

            if (gameType != GameType.Endless
                && _playersHealth <= 0)
            {
                GameOver();
            }
        }

        private enum GameType
        {
            Score = 0,
            Life,
            Endless
        }
    }
}