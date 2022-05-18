using MapTools;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private float shootInterval;
    
    [FormerlySerializedAs("_firePoint")] [SerializeField]
    private Transform firePoint;

    private float _shootTimer;

    public GameObject projectile;
    private void Update()
    {
        _shootTimer -= Time.deltaTime;
    }

    public void Shoot(Vector3 mousePos)
    {
        if (!CanShoot()) return;
        
        var position = firePoint.position;
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
