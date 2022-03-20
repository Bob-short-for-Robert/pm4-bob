using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2.0f;
    public float lifeTime = 2.0f;
    private Rigidbody2D _mRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _mRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _mRigidbody.velocity = (Vector2) (transform.rotation * Vector3.left) * speed;

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

        if (col.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}