using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private RaycastHit2D _raycasthit;

    private Vector3 _moveDelta;

    public GameObject[] projectile;
    public float shootInterval = 0.2f;
    private float _shootTimer = 0f;
    
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
        if (_moveDelta.x < 0)
            transform.localScale = Vector3.one;
        else if (_moveDelta.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);

        var collisionMasks = LayerMask.GetMask("Actor", "Blocking");
        _raycasthit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
            Math.Abs(_moveDelta.y * Time.deltaTime), collisionMasks);
        if (_raycasthit.collider == null)
        {
            transform.Translate(0, _moveDelta.y * Time.deltaTime, 0);
        }

        _raycasthit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
            Math.Abs(_moveDelta.x * Time.deltaTime), collisionMasks);
        if (_raycasthit.collider == null)
        {
            transform.Translate(_moveDelta.x * Time.deltaTime, 0, 0);
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