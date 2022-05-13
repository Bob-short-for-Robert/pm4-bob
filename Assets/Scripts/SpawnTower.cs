using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnTower : MonoBehaviour
{
    
    public GameObject objToSpawn;
    
    private Transform objSpawnPlace;
    private float myTime = 0F;
    private float nextPlacement = 1F;
    private float placementRate = 1F;
    
    // Start is called before the first frame update
    void Start()
    {
        objSpawnPlace = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        //TODO make this only available after selecting correct Tower
        myTime += Time.deltaTime;
        // waits for 1 Second before allowing to spawn another Tower
        if (Input.GetKey(KeyCode.E) && checkResources() && allowedToSpawn() && myTime > nextPlacement)
        {
            nextPlacement = myTime + placementRate;
            Instantiate(objToSpawn, objSpawnPlace.position, objSpawnPlace.rotation);
            Debug.Log("tower placed");
            nextPlacement -= myTime;
            myTime = 0F;
        }
    }
    
    private bool allowedToSpawn()
    {
        // TODO add check for wall and other obj which might block the spawning of the obj
        return true;
    }
    
    private bool checkResources()
    {
        //TODO add check if enough resources are available before placing
        return true;
    }
}
