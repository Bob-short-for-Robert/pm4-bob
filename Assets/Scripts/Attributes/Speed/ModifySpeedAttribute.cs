using UnityEngine;

namespace Attributes.Speed
{
    [AddComponentMenu("Playground/Attributes/Modify Speed")]
    public class ModifySpeedAttribute : MonoBehaviour
    {
        [SerializeField] private float slowTarget = 0;
        [SerializeField] private float slowTargetForSeconds = 0;
        [SerializeField] private bool damageToPlayer = true;
    
        private void OnTriggerEnter2D(Collider2D colliderData)
        {
            var speedScript = colliderData.gameObject.GetComponent<SpeedSystemAttribute>();

            if (speedScript == null) return;
            if (damageToPlayer || colliderData.CompareTag("Enemy"))
            {
                speedScript.ApplySlow(new SlowEffect(slowTarget, slowTargetForSeconds));
            }
        }
    }
}
