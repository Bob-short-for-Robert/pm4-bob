using System;
using UnityEditor.PackageManager;
using UnityEngine;
using static BOB_Logger;

public class AutoShooter : MonoBehaviour
{
    [SerializeField]
    private bool shootsPlayer;
    [SerializeField]
    private Shooter shooter;
    [SerializeField]
    private Rotate toBeRotated;
    
    private GameObject toBeShot;
    
    // Update is called once per frame
    private void Update()
    {
        toBeShot = shootsPlayer ? SearchPlayer() : FindClosest(gameObject, "Enemy");

        if (toBeShot != null)
        {
            if (gameObject.CompareTag("Tower"))
            {
                toBeRotated.RotateTowards(toBeShot.transform);
            }
            shooter.Shoot(toBeShot.transform.position);
            return;
        }

        Log("No Enemy found to shoot at", LogLevel.Silly);
    }

    private GameObject FindClosest(GameObject origin, String find)
    {
        GameObject closest = null;
        float distanceToClosest = Mathf.Infinity;
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag(find);
        foreach (var currentEmeny in allEnemy)
        {
            float currentDistance = (currentEmeny.transform.position - origin.transform.position).sqrMagnitude;
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
