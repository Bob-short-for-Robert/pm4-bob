using System.Collections.Generic;
using MapTools;
using UnityEngine;
using Random = System.Random;

public class SpawnPoint : MonoBehaviour
{
    [Header("Spawn Interval in Seconds")] public float spawnInterval;
    public GameObject[] enemies;

    private float _spawnTimer;

    private Random _random;

    private void Start()
    {
        _random = new Random();
    }

    private void Update()
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
        //keep method for later wraping of wave logic
        Vector3 position = transform.position;
        SpawnObject.Spawn(enemies[0], position, 0);
    }
}
