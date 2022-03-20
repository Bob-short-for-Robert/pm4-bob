using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static System.Console;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public float shootInterval;
    public GameObject[] projectile;
    public float playerSpeed = 2.0f;  
    
    private BoxCollider2D boxCollider;
    private RaycastHit2D raycasthit;
    private Vector3 moveDelta;
    private float _shootTimer;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // reset moveDelta 
        moveDelta = new Vector3(x, y, 0);

        // swap Sprite direction
        if (moveDelta.x < 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);

        var collisionMasks = LayerMask.GetMask("Actor", "Blocking");
        raycasthit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
            Math.Abs(moveDelta.y * Time.deltaTime), collisionMasks);
        if (raycasthit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime * playerSpeed, 0);
        }

        raycasthit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
            Math.Abs(moveDelta.x * Time.deltaTime), collisionMasks);
        if (raycasthit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime *playerSpeed, 0, 0);
        }

        _shootTimer -= Time.deltaTime;
    }


    public void Shoot(Vector3 mousePos)
    {
        if (CanShoot())
        {
            Vector3 position = transform.position;
            float angle = AngleBetweenTwoPoints(position, mousePos);
            Instantiate(projectile[0], position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
    }

    private bool CanShoot()
    {
        if (_shootTimer < 0)
        {
            _shootTimer = shootInterval;
            return true;
        }

        return false;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}