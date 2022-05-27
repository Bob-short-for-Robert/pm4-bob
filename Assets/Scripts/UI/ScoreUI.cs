using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ScoreUI : MonoBehaviour
    {
        public Text score, highScore;

        // Start is called before the first frame update
        void Update()
        {
            score.text = GameController.Instance.Score.ToString();
            highScore.text = GameController.Instance.HighScore.ToString();
        }
    }
}
