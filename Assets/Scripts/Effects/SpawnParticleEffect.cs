using System;
using UnityEngine;

namespace Effects
{
    public class SpawnParticleEffect : MonoBehaviour
    {
        [SerializeField]
        private GameObject spawnParticleEffect;
        [SerializeField]
        private bool onDestroy;
        [SerializeField]
        private bool onCollision;
        [SerializeField]
        private bool useTag;
        [SerializeField]
        private new string tag = string.Empty;
        
        
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
            if (!onDestroy && onCollision && useTag)
            {
                if (col.CompareTag(tag))
                {
                    SpawnEffect();   
                }
            }
        }

        private void SpawnEffect()
        {
            var effectObject = Instantiate(spawnParticleEffect, GameObject.Find("Map").transform);
            var locationsVector = transform.localPosition;
            effectObject.name = $"ParticleEffectX{locationsVector.x}Y{locationsVector.y}";
            effectObject.transform.localPosition = locationsVector;
            if (!spawnParticleEffect.CompareTag("Circle"))
            { 
                effectObject.transform.rotation = transform.rotation;  
            }
            effectObject.transform.SetParent(GameObject.Find("Map").GetComponent<RectTransform>(), false);
        }
    }
}