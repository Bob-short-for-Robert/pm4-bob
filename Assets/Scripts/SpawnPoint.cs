using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnPoint : MonoBehaviour
{
    private readonly List<GameObject> _enemyObjects = new List<GameObject>();

    [Header("Spawn Interval in Seconds")] public float spawnInterval;
    public GameObject[] enemies;
    
    private float _spawnTimer;

    private Random _random;

    private void Start()
    {
        _random = new Random();
    }

    void Update()
    {
        if (spawnInterval == 0)
        {
            return;
        }
        
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            SpawnEnemy();
            _spawnTimer = spawnInterval;
        }
    }


    private void SpawnEnemy()
    {
        Vector3 position = transform.position;
        var enemyObject = Instantiate(enemies[_random.Next(enemies.Length - 1)], position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
        
        enemyObject.name = string.Format("EnemyC{0}", _enemyObjects.Count);
   
        _enemyObjects.Add(enemyObject); 
    }

    ~SpawnPoint()
    {
        foreach (var enemy in _enemyObjects)
        {
            Destroy(enemy.gameObject);
        }
    }
}