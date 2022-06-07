using System.Collections.Generic;
using System.Linq;
using MapTools;
using Stockpile;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Player
{
    public static class ResourceManager
    {
        private static readonly Dictionary<string, int> Collected = new Dictionary<string, int>()
        {
            {"Stone", 0},
            {"Wood", 0}
        };

        public static int GetResource(string name)
        {
            return Collected[name];
        }

        public static Dictionary<string, int> GetCollected()
        {
            return Collected;
        }

        public static bool HasResources(Dictionary<string, int> compare)
        {
            return compare.Keys.Aggregate(true, (current, compareKey) => current & compare[compareKey] <= Collected[compareKey]);
        }

        public static void CollectResource(GameObject o)
        {
            var res = o.GetComponent<Resource>();
            Collected[res.GetName()] += res.GetQuantity();
            Object.Destroy(o);
        }

        public static void DropResource(GameObject[] possibleDrops, int dropCycles, int dropLikelihood, Vector3 location)
        {
            for (var i = 0; i < dropCycles; i++)
            {
                if (Random.Range(0, 101) <= dropLikelihood)
                {
                    SpawnObject.Spawn(possibleDrops[Random.Range(0, possibleDrops.Length)], location, 0);
                }
            }
        }

        public static void UseResource(Dictionary<string, int> useResources)
        {
            foreach (var use in useResources)
            {
                Collected[use.Key] -= use.Value;
            }
        }
    }
}
