using UnityEngine;
using MapTools;

public class Projectile : MonoBehaviour
{
    public float speed = 2.0f;
    public float lifeTime = 2.0f;
    private Rigidbody2D _mRigidbody;

    private void Start()
    {
        _mRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _mRigidbody.velocity = (Vector2) (transform.rotation * Vector3.left) * speed;

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            SpawnEffect(4);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            SpawnEffect(2);
            Destroy(gameObject);
        }
        if (col.CompareTag("Enemy"))
        {
            SpawnEffect(3);
            Destroy(gameObject);
        }
    }
    
    private void SpawnEffect(int effect)
    {
        var map = GameObject.Find("Map");
        var mapController = (MapGenerator) map.GetComponent(typeof(MapGenerator));
        var transform1 = transform;
        mapController.AddEffect(transform1.position,effect, transform1.rotation);
    }
}
