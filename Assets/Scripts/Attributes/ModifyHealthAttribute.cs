using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Diagnostics;

[AddComponentMenu("Playground/Attributes/Modify Health")]
public class ModifyHealthAttribute : MonoBehaviour
{
    public bool destroyWhenActivated = false;
    public int healthChange = -1;
    public float slowTarget = 0;
    public float slowTargetForSeconds = 0;

    public bool damageToPlayer = true;

    // This function gets called everytime this object collides with another
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        OnTriggerEnter2D(collisionData.collider);
    }

    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
        if (healthScript != null)
        {
            if (damageToPlayer || !colliderData.CompareTag("Player"))
            {
                // subtract health from the player
                healthScript.ModifyHealth(healthChange);

                if (destroyWhenActivated)
                {
                    Destroy(gameObject);
                }
            }
        }

        //TODO pull out speed out of FollowPlayer and Player into parent class
        var speedScriptEnemy = colliderData.gameObject.GetComponent<FollowPlayer>();
        if (speedScriptEnemy != null)
        {
            speedScriptEnemy.ModifySpeed(slowTarget, slowTargetForSeconds);
        }
    }
}
