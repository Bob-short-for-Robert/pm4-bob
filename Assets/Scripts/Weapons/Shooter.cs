using MapTools;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private float shootInterval;
    
    [SerializeField]
    private Transform _firePoint;

    private float _shootTimer;

    private void Update()
    {
        _shootTimer -= Time.deltaTime;
    }

    public void Shoot(Vector3 mousePos)
    {
        if (!CanShoot()) return;
        
        var position = _firePoint.position;
        var angle = AngleBetweenTwoPoints(position, mousePos);
        var map = GameObject.Find("Map");
        var mapController = (MapGenerator) map.GetComponent(typeof(MapGenerator));
        mapController.AddProjectile(position, angle);
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
