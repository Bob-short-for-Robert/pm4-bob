using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnObj : MonoBehaviour
{
    
    public GameObject objToSpawn;
    public Transform objSpawnPlace;
    
    private float myTime = 0F;
    private float nextPlacement = 1F;
    private float placementRate = 1F;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //TODO make this only available after selecting correct Obj
        myTime += Time.deltaTime;
        // waits for 1 Second before allowing to spawn another obj
        if (Input.GetKey(KeyCode.E) && checkResources() && allowedToSpawn() && myTime > nextPlacement)
        {
            nextPlacement = myTime + placementRate;
            Instantiate(objToSpawn, objSpawnPlace.position, objSpawnPlace.rotation);
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
