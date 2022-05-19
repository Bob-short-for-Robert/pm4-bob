using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceDropper : MonoBehaviour
{
    public GameObject[] possibleDrops;
    public int dropCycles = 3;
    public int dropLikelihood = 30;
    
    private void OnDestroy()
    {
        ResourceManager.DropResource(possibleDrops, dropCycles, dropLikelihood, gameObject.transform.position);
    }
}
