using UnityEngine;

namespace Attributes.Speed
{
    [AddComponentMenu("Playground/Attributes/Modify Speed")]
    public class ModifySpeedAttribute : MonoBehaviour
    {
        [SerializeField] private float slowTarget;
        [SerializeField] private float slowTargetForSeconds;
        [SerializeField] private bool damageToPlayer = true;
    
        private void OnTriggerEnter2D(Collider2D colliderData)
        {
            if (colliderData.CompareTag("Enemy") && CompareTag("Enemy")) return;
            var speedScript = colliderData.gameObject.GetComponent<SpeedSystemAttribute>();
            if (speedScript == null) return;
            if (damageToPlayer || colliderData.CompareTag("Enemy"))
            {
                speedScript.ApplySlow(new SlowEffect(slowTarget, slowTargetForSeconds));
            }
        }
    }
}
