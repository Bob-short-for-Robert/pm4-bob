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
        Vector3 position = transform.position;
        var mapController = (MapController) GameObject.Find("MapController").GetComponent(typeof(MapController));
        mapController.AddEnemy(enemies[0], (int)position.x, (int)position.y);
    }
}