using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public bool shootsPlayer;
    public Shooter shooter;
    private GameObject toBeShot;
    
    // Update is called once per frame
    void Update()
    {
        toBeShot = shootsPlayer ? SearchPlayer() : FindClosestEnemy();

        if (toBeShot != null)
        {
            shooter.Shoot(toBeShot.transform.position);
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        float distanceToClosest = Mathf.Infinity;
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var currentEmeny in allEnemy)
        {
            float currentDistance = (currentEmeny.transform.position - this.transform.position).sqrMagnitude;
            if (currentDistance < distanceToClosest)
            {
                distanceToClosest = currentDistance;
                closest = currentEmeny;
            }
        }

        return closest;
    }

    private GameObject SearchPlayer()
    {
        return GameObject.FindWithTag("Player");
    }
}
