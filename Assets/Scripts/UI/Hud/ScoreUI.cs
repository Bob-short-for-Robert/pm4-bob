using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public class ScoreUI : MonoBehaviour
    {
        public Text score, highScore;

        private void Update()
        {
            score.text = GameController.Instance.Score.ToString();
            highScore.text = GameController.Instance.HighScore.ToString();
        }
    }
}
