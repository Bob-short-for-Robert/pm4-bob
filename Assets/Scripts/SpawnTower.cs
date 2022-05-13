using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnTower : MonoBehaviour
{
    
    [SerializeField]
    public GameObject objToSpawn;
    [SerializeField]
    private float placementRate = 1F;
    [SerializeField]
    private float displacementDistance = 3F;
    
    private Transform objSpawnPlace;
    private float myTime = 0F;
    private float nextPlacement;
    private Vector3 displacement;
    
    // Start is called before the first frame update
    private void Start()
    {
        objSpawnPlace = GetComponent<Transform>();
        nextPlacement = placementRate;
    }

    private void FixedUpdate()
    {
        //TODO make this only available after selecting correct Tower
        myTime += Time.deltaTime;
        // waits for 1 Second before allowing to spawn another Tower
        if (Input.GetKey(KeyCode.E) && CheckResources() && AllowedToSpawn() && myTime > nextPlacement)
        {
            SetDisplacement();
            nextPlacement = myTime + placementRate;
            Instantiate(objToSpawn, objSpawnPlace.position + displacement, objSpawnPlace.rotation);
            nextPlacement -= myTime;
            myTime = 0F;
        }
    }

    private void SetDisplacement()
    {
        displacement.x = Input.GetAxis("Horizontal") * displacementDistance;
        displacement.y = Input.GetAxis("Vertical") * displacementDistance;
        if (displacement == Vector3.zero)
        {
            // default displacement to the left if player is not moving
            displacement.x = -3;
        }
    }

    private bool AllowedToSpawn()
    {
        // TODO add check for wall and other obj which might block the spawning of the obj
        return true;
    }
    
    private bool CheckResources()
    {
        //TODO add check if enough resources are available before placing
        return true;
    }
}
