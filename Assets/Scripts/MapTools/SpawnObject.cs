using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public static void Spawn(GameObject obj, Vector3 vector, float angle)
    {
        var spawned = Instantiate(obj, obj.transform);
        
        spawned.name = $"{obj.tag}X{vector.x}Y{vector.y}";
        spawned.transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
        spawned.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
