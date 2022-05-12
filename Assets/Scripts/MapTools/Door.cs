using UnityEngine;

namespace MapTools
{
    public class Door : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var mapController = (MapController) GameObject.Find("MapController").GetComponent(typeof(MapController));
                mapController.NewMap();
            }
        }
    }
}
