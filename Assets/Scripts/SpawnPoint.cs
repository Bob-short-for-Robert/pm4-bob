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

    void Update()
    {
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
        Instantiate(enemies[_random.Next(enemies.Length - 1)], position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
    }
}