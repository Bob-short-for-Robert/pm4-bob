using System.Collections.Generic;
using System.Linq;
using MapTools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject[] trash;
        [SerializeField] private GameObject[] bosses;
        public int WaveCount { private set; get; }

        private bool _spawnBoss;
        private int _bossCount;
        private int _minTrashCount;
        private int _randomTrashModifier;
        private float _spawnInterval;
        private float _spawnTimer;

        public void InitPoint( bool spawnBoss, float spawnInterval, int waveCount, int bossCount, int minTrashCount, int randomTrashModifier)
        {
            _spawnBoss = spawnBoss;
            _spawnInterval = spawnInterval;
            _bossCount = bossCount;
            _minTrashCount = minTrashCount;
            _randomTrashModifier = randomTrashModifier;
            WaveCount = waveCount;
            _spawnTimer = _spawnInterval;
        }

        private void Update()
        {
            if (_spawnInterval == 0) return;
            if (WaveCount == 0) return;

            _spawnTimer -= Time.deltaTime;
            if (!(_spawnTimer <= 0)) return;

            if (WaveCount == 1 && _spawnBoss)
            {
                SpawnEnemy(bosses, _bossCount);
            }
            else
            {
                SpawnEnemy(trash, (int) (Random.value * _minTrashCount + _randomTrashModifier));  
            }
            
            WaveCount--;
            _spawnTimer = _spawnInterval;
        }

        private void SpawnEnemy(IReadOnlyList<GameObject> enemies, int count)
        {
            var position = transform.position;
            var index = (int) (Random.value * enemies.Count);
            index = index >= enemies.Count ? enemies.Count : index;
            foreach (var value in Enumerable.Range(1, count))
            {
                SpawnObject.Spawn(enemies[index], position, 0); 
            }
        }
    }
}
