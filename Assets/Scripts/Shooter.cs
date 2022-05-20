using MapTools;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float shootInterval;

    private float _shootTimer;
    
    [SerializeField] private GameObject projectile;

    [SerializeField] private GameObject firePoint;
    private void Update()
    {
        _shootTimer -= Time.deltaTime;
    }

    public void Shoot(Vector3 mousePos)
    {
        if (!CanShoot()) return;
        
        var position = firePoint.transform.position;
        var angle = AngleBetweenTwoPoints(position, mousePos);
        
        SpawnObject.Spawn(projectile, position, angle);
    }

    private bool CanShoot()
    {
        if (!(_shootTimer < 0)) return false;
        _shootTimer = shootInterval;
        return true;

    }

    private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
