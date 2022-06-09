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
                Log($"generating new seed {seed.ToString()}", LogType.Log);
            }
            else
            {
                seed = userSeed;
                Log($"using seed {seed.ToString()}", LogType.Log);
            }

            Random.InitState(seed);
        }
    }
}
