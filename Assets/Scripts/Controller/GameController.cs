using UnityEngine;
using static BoBLogger.Logger;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        private static GameController instance;

        public static GameController Instance
        {
            get
            {
                if (!instance)
                {
                    instance = new GameObject().AddComponent<GameController>();
                    // name it for easy recognition
                    instance.name = instance.GetType().ToString();
                    // mark root as DontDestroyOnLoad();
                    DontDestroyOnLoad(instance.gameObject);
                }
                else
                {
                    Log("GameController missing", LogType.Error);
                }

                return instance;
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
