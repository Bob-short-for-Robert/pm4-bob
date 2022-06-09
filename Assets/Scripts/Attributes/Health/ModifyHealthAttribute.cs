using UnityEngine;

namespace Attributes.Health
{
    [AddComponentMenu("Playground/Attributes/Modify Health")]
    public class ModifyHealthAttribute : MonoBehaviour
    {
        [SerializeField] private bool destroyWhenActivated;
        [SerializeField] private int healthChange = -1;
        [SerializeField] private bool damageToPlayer = true;

        // This function gets called everytime this object collides with another
        private void OnCollisionEnter2D(Collision2D collisionData)
        {
            OnTriggerEnter2D(collisionData.collider);
        }

        private void OnTriggerEnter2D(Collider2D colliderData)
        {
            var healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
            if (healthScript == null) return;
            if (!damageToPlayer && colliderData.CompareTag("Player")) return;
            if (colliderData.CompareTag("Enemy") && CompareTag("Enemy")) return;
            // subtract health from the player
            healthScript.ModifyHealth(healthChange);

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}
