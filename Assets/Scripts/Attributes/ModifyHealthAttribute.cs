using UnityEngine;

[AddComponentMenu("Playground/Attributes/Modify Health")]
public class ModifyHealthAttribute : MonoBehaviour
{
    public bool destroyWhenActivated = false;
    public int healthChange = -1;

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
    }
}