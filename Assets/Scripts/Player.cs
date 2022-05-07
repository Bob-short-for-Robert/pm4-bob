using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Console;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public float playerSpeed = 2.0f;  
    
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _raycastHit;
    private Vector3 _moveDelta;
    private bool _facingLeft;


    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // reset moveDelta 
        _moveDelta = new Vector3(x, y, 0);

        // swap Sprite direction
        if (_moveDelta.x < 0 && _facingLeft)
        {
            FlipPlayer();
        }
            
        else if (_moveDelta.x > 0 && !_facingLeft)
        {
            FlipPlayer();

        }
            
        var collisionMasks = LayerMask.GetMask("Actor", "Blocking");
        _raycastHit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
            Math.Abs(_moveDelta.y * Time.deltaTime), collisionMasks);
        if (_raycastHit.collider == null)
        {
            transform.Translate(0, _moveDelta.y * Time.deltaTime * playerSpeed, 0);
        }

        _raycastHit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Math.Abs(_moveDelta.x * Time.deltaTime), collisionMasks);
        if (_raycastHit.collider == null)
        {
            transform.Translate(
                _moveDelta.x * Time.deltaTime *playerSpeed * (_facingLeft ? -1 : 1),
                0,
                0);
        }
    }

    private void FlipPlayer()
    {
        _facingLeft = !_facingLeft;
        transform.Rotate(0f,180f, 0f);
    }
}
