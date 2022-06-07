using System;
using UnityEngine;
using static BoBLogger.Logger;

namespace MapTools
{
    public class SpawnObject : MonoBehaviour
    {
        public static void Spawn(GameObject obj, Vector3 location, float angle)
        {
            Log($"Generating new GameObject: {obj.name}", LogType.Log);
            try
            {
                var spawned = GetNewObject(obj, location);
                spawned.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            }
            catch (NullReferenceException e)
            {
                Log($"{e}", LogType.Log);
            }
        }

        public static void Spawn(GameObject obj, Vector3 location, Quaternion rotation)
        {
            Log($"Generating new GameObject: {obj.name}", LogType.Log);
            try
            {
                var spawned = GetNewObject(obj, location);
                spawned.transform.rotation = rotation;
            }
            catch (NullReferenceException e)
            {
                Log($"{e}", LogType.Log);
            }
        }

        public static void Spawn(GameObject obj, Vector3 location)
        {
            Log($"Generating new GameObject: {obj.name}", LogType.Log);
            try
            {
                GetNewObject(obj, location);
            }
            catch (NullReferenceException e)
            {
                Log($"{e}", LogType.Log);
            }
        }

        public static bool AllowedToSpawn(GameObject obj, Vector3 position)
        {
            //currently assuming that everything is about a sphere
            return !Physics.CheckSphere(position, obj.transform.lossyScale.magnitude);
        }

        private static GameObject GetNewObject(GameObject obj, Vector3 location)
        {
            Transform map;
            try
            {
                map = GameObject.Find("Map").transform;
            }
            catch
            {
                throw new NullReferenceException("Map not found");
            }
            var spawned = Instantiate(obj, map);
            spawned.transform.localPosition = location;
            spawned.name = $"{obj.name}X{location.x}Y{location.y}";
            return spawned;
        }
    }
}
