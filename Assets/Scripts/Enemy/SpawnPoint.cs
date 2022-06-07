using MapTools;
using UnityEngine;

namespace Enemy
{
    public class SpawnPoint : MonoBehaviour
    {
        [Header("Spawn Interval in Seconds")] public float spawnInterval;
        [SerializeField] private GameObject[] enemies;

        private float _spawnTimer;

        private void Update()
        {
            if (spawnInterval == 0)
            {
                return;
            }

            _spawnTimer -= Time.deltaTime;
            if (!(_spawnTimer <= 0)) return;
            SpawnEnemy();
            _spawnTimer = spawnInterval;
        }

        private void SpawnEnemy()
        {
            //keep method for later wrapping of wave logic
            var position = transform.position;
            SpawnObject.Spawn(enemies[0], position, 0);
        }
    }
}
