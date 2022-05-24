using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ResourceManager
{
    private static List<Resource> Inventory = new List<Resource>();

    private static readonly Dictionary<string, int> Collected = new Dictionary<string, int>()
    {
        {"Stone", 0},
        {"Wood", 0}
    };

    public static int GetResource(string name)
    {
        return Collected[name];
    }

    public static List<Resource> GetInventory()
    {
        return Inventory;
    }

    public static bool HasResources(Dictionary<string, int> compare)
    {
        bool enoughResources = true;
        foreach (var compareKey in compare.Keys)
        {
            enoughResources &= compare[compareKey] <= Collected[compareKey];
        }

        return enoughResources;
    }

    public static void CollectResource(GameObject o)
    {
        Resource res = o.GetComponent<Resource>();
        Collected[res.Name] += res.quantity;
        if (Inventory.Exists(resource => resource.Name == res.Name))
        {
            Inventory.Find(resource => resource.Name == res.Name).quantity += res.quantity;
        }
        else
        {
            Inventory.Add(res);
        }

        GameObject.Destroy(o);
    }

    public static void DropResource(GameObject[] possibleDrops, int dropCycles, int dropLikelihood, Vector3 location)
    {
        for (int i = 0; i < dropCycles; i++)
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
            Inventory.Find(resource => resource.Name == use.Key).quantity -= use.Value;
        }
    }
}