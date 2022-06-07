using UnityEditor.PackageManager;
using UnityEngine;
using static BoBLogger.Logger;

namespace Controller
{
    public class SetRandomSeed : MonoBehaviour
    {
        [SerializeField] private int userSeed = 10;
        [SerializeField] private int seed;
        [SerializeField] private bool randomizeSeed;

        private void Awake()
        {
            if (randomizeSeed)
            {
                seed = Random.Range(0, 99999);
                Log($"generating new seed {seed.ToString()}", LogLevel.Info);
            }
            else
            {
                seed = userSeed;
                Log($"using seed {seed.ToString()}", LogLevel.Info);
            }

            Random.InitState(seed);
        }
    }
}
