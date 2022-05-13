using MapTools;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float shootInterval;

    private float _shootTimer;

    private void Update()
    {
        _shootTimer -= Time.deltaTime;
    }

    public void Shoot(Vector3 mousePos)
    {
        if (!CanShoot()) return;
        //TODO get appropriate position around obj to spawn bullet (so it does not shoot itself)
        var position = transform.position + mousePos.normalized;
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
