using MapTools;
using UnityEngine;

namespace Effects
{
    public class SpawnParticleEffect : MonoBehaviour
    {
        [SerializeField] private GameObject spawnParticleEffect;
        [SerializeField] private bool onDestroy;
        [SerializeField] private bool onCollision;
        [SerializeField] private bool useTag;
        [SerializeField] private new string tag = string.Empty;

        private void OnDestroy()
        {
            if (onDestroy)
            {
                SpawnEffect();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!onDestroy && onCollision && !useTag)
            {
                SpawnEffect();
            }

            if (onDestroy || !onCollision || !useTag) return;
            if (col.CompareTag(tag))
            {
                SpawnEffect();
            }
        }

        private void SpawnEffect()
        {
            if (!spawnParticleEffect.CompareTag("Circle"))
            {
                var tempTransform = transform;
                SpawnObject.Spawn(spawnParticleEffect, tempTransform.localPosition, tempTransform.rotation);
            }
            else
            {
                SpawnObject.Spawn(spawnParticleEffect, transform.localPosition);
            }
        }
    }
}
