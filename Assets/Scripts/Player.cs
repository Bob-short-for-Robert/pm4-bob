using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static System.Console;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public GameObject tower;
    public Transform towerSpawn;
    
    private BoxCollider2D boxCollider;
    private RaycastHit2D raycasthit;
    private Camera camera;

    private Vector3 moveDelta;

    private float myTime = 0F;
    private float nextPlacement = 1F;
    private float placementRate = 1F;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        myTime += Time.deltaTime;
        if (Input.GetButton("Jump") && checkResources() && myTime > nextPlacement)
        {
            nextPlacement = myTime + placementRate;
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0F;
            Instantiate(tower, mousePos, towerSpawn.rotation);
            nextPlacement -= myTime;
            myTime = 0F;
        }
    }
    
    private bool checkResources()
    {
        //TODO add check if enough resources are available before placing
        return true;
    }
    
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // reset moveDelta 
        moveDelta = new Vector3(x, y, 0);

        // swap Sprite direction
        // TODO change to animation
        if (moveDelta.x < 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);

        var collisionMasks = LayerMask.GetMask("Actor", "Blocking");
        raycasthit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
            Math.Abs(moveDelta.y * Time.deltaTime), collisionMasks);
        if (raycasthit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        raycasthit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
            Math.Abs(moveDelta.x * Time.deltaTime), collisionMasks);
        if (raycasthit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}