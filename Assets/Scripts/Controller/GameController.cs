using UnityEditor.PackageManager;
using UnityEngine;
using static BoBLogger.Logger;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        private static GameController _instance;

        public static GameController Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = new GameObject().AddComponent<GameController>();
                    // name it for easy recognition
                    _instance.name = _instance.GetType().ToString();
                    // mark root as DontDestroyOnLoad();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                else
                {
                    Log("GameController missing", LogLevel.Error);
                }

                return _instance;
            }
        }

        public void AddPoints(int amount = 1)
        {
            Score += amount;
            if (HighScore < Score)
            {
                HighScore = Score;
            }
        }

        public void ResetScore()
        {
            Score = 0;
        }
    }
}
