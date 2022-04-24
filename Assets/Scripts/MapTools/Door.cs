using UnityEngine;

namespace MapTools
{
    public class Door : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var map = GameObject.Find("Map");
                var mapController = (MapGenerator) map.GetComponent(typeof(MapGenerator));
                mapController.NewMap();
            }
        }
    }
}