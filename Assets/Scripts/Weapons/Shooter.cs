using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private float shootInterval;
    
    [SerializeField]
    private GameObject[] projectile;

    [SerializeField]
    private Transform _firePoint;

    private float _shootTimer;

    void Update()
    {
        _shootTimer -= Time.deltaTime;
    }

    public void Shoot(Vector3 mousePos)
    {
        if (CanShoot())
        {
            Vector3 position = transform.position;
            float angle = AngleBetweenTwoPoints(position, mousePos);
            Instantiate(projectile[0], _firePoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
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
