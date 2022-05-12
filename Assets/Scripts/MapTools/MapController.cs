using System;
using System.Collections;
using System.Collections.Generic;
using MapTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    private MapGenerator _mapGenerator = new MapGenerator();

    public void NewMap()
    {
        SceneManager.LoadScene("Main");
    }

    public void AddProjectile(GameObject projectile, Vector3 v, float angle)
    {
        _mapGenerator.AddProjectile(projectile, v, angle);
    }

    public void AddEnemy(GameObject enemy, int positionX, int positionY)
    {
        _mapGenerator.AddEnemy(enemy, positionX, positionY);
    }
}