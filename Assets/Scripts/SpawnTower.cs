using System.Collections.Generic;
using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    [SerializeField] private float placementRate = 1F;
    [SerializeField] private float displacementDistance = 3F;

    private GameObject _towerToSpawn;
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
        PlaceTower();
    }

    public void PlaceTower()
    {
        _myTime += Time.deltaTime;
        // waits for 1 Second before allowing to spawn another Tower
        SetDisplacement();
        var neededResources = createDic(_towerToSpawn.GetComponent<NecessaryResources>());

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("E");
            if (canPlaceTower())
            {
                Debug.Log("placeTower");
                ResourceManager.UseResource(neededResources);
                _nextPlacement = _myTime + placementRate;
                SpawnObject.Spawn(_towerToSpawn, _objSpawnPlace.position + _displacement, _objSpawnPlace.rotation);
                _nextPlacement -= _myTime;
                _myTime = 0F;
            }
        }
    }

    private bool canPlaceTower()
    {
        var neededResources = createDic(_towerToSpawn.GetComponent<NecessaryResources>());
        return SpawnObject.AllowedToSpawn(_towerToSpawn, _objSpawnPlace.position + _displacement) && ResourceManager.HasResources(neededResources) && _myTime > _nextPlacement;
    }

    public void setTower(GameObject tower)
    {
        _towerToSpawn = tower;
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
}