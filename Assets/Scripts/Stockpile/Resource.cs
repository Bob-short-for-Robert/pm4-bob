using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stockpile
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private new string name = "resource";
        [SerializeField] private int quantity = 1;

        public string GetName()
        {
            return name;
        }

        public int GetQuantity()
        {
            return quantity;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                ResourceManager.CollectResource(gameObject);
            }
        }
    }
}
