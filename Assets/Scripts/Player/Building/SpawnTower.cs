using System;
using System.Collections.Generic;
using MapTools;
using UnityEngine;
using static BoBLogger.Logger;
using Log = NLog.Fluent.Log;

namespace Player.Building
{
    public class SpawnTower : MonoBehaviour
    {
        public BuildingSO ObjToSpawn { set; get; }
        [SerializeField] private float placementRate = 1F;
        [SerializeField] private float displacementDistance = 3F;

        private Transform _objSpawnPlace;
        private float _myTime;
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
            try
            {
                PlaceTower(ObjToSpawn.pref.gameObject);
            }
            catch (NullReferenceException e)
            {
                Log($"{e}", LogType.Log);
            }
        }

        private void PlaceTower(GameObject tower)
        {
            _myTime += Time.deltaTime;
            // waits for 1 Second before allowing to spawn another Tower
            SetDisplacement();
            var neededResources = CreateDic(tower.GetComponent<NecessaryResources>());

            if (!Input.GetKey(KeyCode.E) || !ResourceManager.HasResources(neededResources) ||
                !SpawnObject.AllowedToSpawn(tower, _objSpawnPlace.position + _displacement) ||
                !(_myTime > _nextPlacement)) return;

            ResourceManager.UseResource(neededResources);
            _nextPlacement = _myTime + placementRate;
            SpawnObject.Spawn(tower, _objSpawnPlace.position + _displacement, _objSpawnPlace.rotation);
            _nextPlacement -= _myTime;
            _myTime = 0F;
        }
        
        private static Dictionary<string, int> CreateDic(NecessaryResources neededResources)
        {
            var dic = new Dictionary<string, int>();
            for (var i = 0; i < neededResources.type.Count; i++)
            {
                dic.Add(neededResources.type[i], neededResources.count[i]);
            }

            return dic;
        }

        private void SetDisplacement()
        {
            _displacement.x = Input.GetAxis("Horizontal") * displacementDistance;
            _displacement.y = Input.GetAxis("Vertical") * displacementDistance;
            if (_displacement != Vector3.zero) return;
            // default displacement to the left if player is not moving
            _displacement.x = -3;
            Log("displace Tower", LogType.Log);
        }
    }
}
