using System;
using UnityEditor.PackageManager;
using UnityEngine;
using static BoBLogger.Logger;

namespace ShooterController
{
    public class AutoShooter : MonoBehaviour
    {
        [SerializeField] private bool shootsPlayer;
        [SerializeField] private Shooter shooter;
        [SerializeField] private Rotate toBeRotated;
    
        private GameObject _toBeShot;
    
        // Update is called once per frame
        private void Update()
        {
            _toBeShot = shootsPlayer ? SearchPlayer() : FindClosest(gameObject, "Enemy");

            if (_toBeShot != null)
            {
                if (gameObject.CompareTag("Tower"))
                {
                    toBeRotated.RotateTowards(_toBeShot.transform);
                }
                shooter.Shoot(_toBeShot.transform.position);
                return;
            }

            Log("No Enemy found to shoot at", LogLevel.Silly);
        }

        private static GameObject FindClosest(GameObject origin, string find)
        {
            GameObject closest = null;
            var distanceToClosest = Mathf.Infinity;
            var allEnemy = GameObject.FindGameObjectsWithTag(find);
            foreach (var currentEnemy in allEnemy)
            {
                var currentDistance = (currentEnemy.transform.position - origin.transform.position).sqrMagnitude;
                if (!(currentDistance < distanceToClosest)) continue;
                distanceToClosest = currentDistance;
                closest = currentEnemy;
            }

            return closest;
        }

        private static GameObject SearchPlayer()
        {
            return GameObject.FindWithTag("Player");
        }
    }
}
