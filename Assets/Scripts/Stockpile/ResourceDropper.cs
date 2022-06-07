using Player;
using UnityEngine;

namespace Stockpile
{
    public class ResourceDropper : MonoBehaviour
    {
        [SerializeField] private GameObject[] possibleDrops;
        [SerializeField] private int dropCycles = 3;
        [SerializeField] private int dropLikelihood = 30;
    
        private void OnDestroy()
        {
            ResourceManager.DropResource(possibleDrops, dropCycles, dropLikelihood, gameObject.transform.position);
        }
    }
}
