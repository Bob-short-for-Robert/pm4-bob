using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D _mRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _mRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _mRigidbody.velocity = (Vector2)(transform.rotation * Vector3.left) * speed;
    }
}