using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    [SerializeField] public BuildingSO objToSpawn;
    [SerializeField] private float placementRate = 1F;
    [SerializeField] private float displacementDistance = 3F;

    private Transform _objSpawnPlace;
    private float _myTime = 0F;
    private float _nextPlacement;
    private Vector3 _displacement;

    // Start is called before the first frame update
    private void Start()
    {
        _objSpawnPlace = GetComponent<Transform>();
        _nextPlacement = placementRate;
    }

    private void FixedUpdate()
    {
        PlaceTower(objToSpawn.pref.gameObject);
    }

    public void PlaceTower(GameObject tower)
    {
        _myTime += Time.deltaTime;
        // waits for 1 Second before allowing to spawn another Tower
        SetDisplacement();
        var neededResources = createDic(tower.GetComponent<NecessaryResources>());

        if (Input.GetKey(KeyCode.E) && ResourceManager.HasResources(neededResources)
                                    && SpawnObject.AllowedToSpawn(tower, _objSpawnPlace.position + _displacement)
                                    && _myTime > _nextPlacement)
        {
            ResourceManager.UseResource(neededResources);
            _nextPlacement = _myTime + placementRate;
            SpawnObject.Spawn(tower, _objSpawnPlace.position + _displacement, _objSpawnPlace.rotation);
            _nextPlacement -= _myTime;
            _myTime = 0F;
        }
    }

    //TODO solve in NecessaryResources
    private Dictionary<string, int> createDic(NecessaryResources neededResources)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < neededResources.type.Count; i++)
        {
            dic.Add(neededResources.type[i], neededResources.count[i]);
        }

        return dic;
    }

    private void SetDisplacement()
    {
        _displacement.x = Input.GetAxis("Horizontal") * displacementDistance;
        _displacement.y = Input.GetAxis("Vertical") * displacementDistance;
        if (_displacement == Vector3.zero)
        {
            // default displacement to the left if player is not moving
            _displacement.x = -3;
        }
    }
    
    public void SetObjToSpawn(BuildingSO obj)
    {
        objToSpawn = obj;
    }
    
    public BuildingSO GetObjToSpawn()
    {
        return objToSpawn;
    }
}
