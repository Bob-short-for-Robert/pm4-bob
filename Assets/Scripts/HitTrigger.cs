using System;
using System.Collections;
using System.Collections.Generic;
using MapTools;
using UnityEngine;
using Random = UnityEngine.Random;

public class HitTrigger : MonoBehaviour
{
    public GameObject[] Effects;
    public float iframes = 0.5f;
    private float _invincibilityTimer = 0f;

    private void Update()
    {
        _invincibilityTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        if (_invincibilityTimer > 0) return;
        _invincibilityTimer = iframes;
        var map = GameObject.Find("Map");
        var mapController = (MapGenerator) map.GetComponent(typeof(MapGenerator));

        if (colliderData.CompareTag("Projectile") && gameObject.CompareTag("Enemy")) // enemy hit projectile
        {
            mapController.AddGameObject(Effects[Random.Range(0, Effects.Length)], transform.position,
                Random.Range(0, 360));
        }

        if (colliderData.CompareTag("Player") && gameObject.CompareTag("Enemy")) //enemy hit player)
        {
            mapController.AddGameObject(Effects[Random.Range(0, Effects.Length)], colliderData.gameObject.transform.position,
                Random.Range(0, 360));
        }
    }
}