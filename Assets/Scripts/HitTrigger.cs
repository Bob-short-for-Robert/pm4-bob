using System.Collections;
using System.Collections.Generic;
using MapTools;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    public GameObject[] Effects;

    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        if (colliderData.tag == "Projectile")
        {
            var map = GameObject.Find("Map");
            var mapController = (MapGenerator) map.GetComponent(typeof(MapGenerator));
            mapController.AddGameObject(Effects[Random.Range(0, Effects.Length)], transform.position, Random.Range(0, 360));
        }
    }
}
