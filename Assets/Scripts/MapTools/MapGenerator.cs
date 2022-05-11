using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapTools
{
    public class MapGenerator : MonoBehaviour
    {
        private (int x, int y) _mapSize = (50, 50);
        private Dictionary<int, GameObject> _tileSet;
        private Dictionary<int, GameObject> _tileGroups;
        private readonly List<List<GameObject>> _tileGrid = new List<List<GameObject>>();
        private Dictionary<int, GameObject> _dynamicObjectsSet;
        private Dictionary<int, GameObject> _dynamicObjectsGroups;
        private readonly List<GameObject> _dynamicObjects = new List<GameObject>();
        private Dictionary<int, GameObject> _projectileSet;
        private Dictionary<int, GameObject> _projectileGroups;
        private readonly List<GameObject> _projectile = new List<GameObject>();
        private Dictionary<int, GameObject> _effectSet;
        private Dictionary<int, GameObject> _effectGroups;
        private readonly List<GameObject> _effects = new List<GameObject>();
        private List<List<bool>> _mapMatrix;
        private int _randomFillPercent = 35;
        private const string WallTag = "Wall";

        //config
        [SerializeField]
        [Range(40,50)]
        private int mapMinSize = 45;
        [Range(10,60)]
        [SerializeField]
        private int randomMapSize = 40;
        [SerializeField]
        [Range(10,20)]
        private int minFillPercent = 12;
        [SerializeField]
        [Range(20,40)]
        private int randomFillPercent = 30;
        [SerializeField]
        [Range(50, 500)]
        private int minFloorTiles = 200;
        [SerializeField]
        [Range(1,10)]
        private int  spawnerMinCount = 2;
        [SerializeField]
        [Range(0, 10)]
        private int spawnerRandomCount = 3;

        //Prefabs
        [SerializeField]
        private GameObject prefabWallBlack;
        [SerializeField]
        private GameObject prefabWallBlackCorner;
        [SerializeField]
        private GameObject prefabWallBlackDtr;
        [SerializeField]
        private GameObject prefabFloor;
        
        
        //Objects
        [SerializeField]
        private GameObject prefabSpawner;
        [SerializeField]
        private GameObject prefabEnemy;
        [SerializeField]
        private GameObject prefabDoor;
        
        //Projectiles
        [SerializeField]
        private GameObject playerDefaultProjectile;
        
        //Effects
        [SerializeField]
        private GameObject effectGreenCircle;
        [SerializeField]
        private GameObject effectRedCircle;

        public void AddEnemy(int x, int y)
        {
            var dynamicPrefab = _dynamicObjectsSet[1];
            var dynamicGroup = _dynamicObjectsGroups[1];
            
            var dynamicObject = Instantiate(dynamicPrefab, dynamicGroup.transform);
   
            dynamicObject.name = $"EnemyX{x}Y{y}";
            dynamicObject.transform.localPosition = new Vector3(x, y, 0);
   
            _dynamicObjects.Add(dynamicObject);
        }
        
        public void AddProjectile(Vector3 vector, float angle)
        {
            var projectilePrefab = _projectileSet[0];
            var projectileGroup = _projectileGroups[0];
            
            var projectileObject = Instantiate(projectilePrefab, projectileGroup.transform);
   
            projectileObject.name = $"EnemyX{vector.x}Y{vector.y}";
            projectileObject.transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
            projectileObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
   
            _projectile.Add(projectileObject);
        }
        
        public void AddEffect(Vector3 vector, int effect)
        {
            if (effect >= _effectGroups.Count || effect >= _effectSet.Count)
            {
                return;
            }
            var effectPrefab = _effectSet[effect];
            var effectGroup = _effectGroups[effect];
            
            var effectObject = Instantiate(effectPrefab, effectGroup.transform);
   
            effectObject.name = $"EnemyX{vector.x}Y{vector.y}";
            effectObject.transform.localPosition = new Vector3(vector.x, vector.y, vector.z);
            _effects.Add(effectObject);
        }
        
        public void NewMap()
        {
            ClearMap();
            SetMapValue();
            GenerateMap();
            SetMapObjects();
        }
        
        private void Start()
        {
            SetMapValue();
            CreateTileSet();
            CreateTileGroups();
            DynamicObjectsSet();
            DynamicObjectsGroups();
            ProjectileSet();
            ProjectileGroups();
            EffectSet();
            EffectGroups();
            GenerateMap();
            SetMapObjects();
        }
        
        private void ClearMap()
        {
            _tileGrid.ForEach(l => l.ForEach(o => Destroy(o.gameObject)));
            _tileGrid.Clear();
            _dynamicObjects.ForEach(o => Destroy(o.gameObject));
            _projectile.ForEach(p => Destroy(p.gameObject));
            _effects.ForEach(e => Destroy(e.gameObject));
        }

        private void SetMapValue()
        {
            _randomFillPercent = (int) (Random.value * minFillPercent + randomFillPercent);
            _mapSize.x = (int) (Random.value * mapMinSize + randomMapSize);
            _mapSize.y = (int) (Random.value * mapMinSize + randomMapSize);
        }

        private void CreateTileSet()
        {
            _tileSet = new Dictionary<int, GameObject>()
            {
                {0, prefabWallBlack},
                {1, prefabWallBlackCorner},
                {2, prefabFloor},
                {3, prefabWallBlackDtr}
            };
        }

        private void CreateTileGroups()
        {
            _tileGroups = new Dictionary<int, GameObject>();
            foreach (var keyValuePair in _tileSet)
            {
                var tileGroup = new GameObject(keyValuePair.Value.name)
                {
                    transform =
                    {
                        parent = gameObject.transform,
                        localPosition = new Vector3(0, 0, 0)
                    }
                };
                _tileGroups.Add(keyValuePair.Key, tileGroup);
            }
        }

        private void DynamicObjectsSet()
        {
            _dynamicObjectsSet = new Dictionary<int, GameObject>()
                {
                    {0, prefabSpawner},
                    {1, prefabEnemy}, 
                    {2, prefabDoor}
                };
        }

        private void DynamicObjectsGroups()
        {
            _dynamicObjectsGroups = new Dictionary<int, GameObject>();
            foreach (var keyValuePair in _dynamicObjectsSet)
            {
                var dynamicObject = new GameObject(keyValuePair.Value.name)
                {
                    transform =
                    {
                        parent = gameObject.transform,
                        localPosition = new Vector3(0, 0, 0)
                    }
                };
                _dynamicObjectsGroups.Add(keyValuePair.Key, dynamicObject);
            }
        }
        
        private void ProjectileSet()
        {
            _projectileSet = new Dictionary<int, GameObject>()
            {
                {0, playerDefaultProjectile},
            };
        }

        private void ProjectileGroups()
        {
            _projectileGroups = new Dictionary<int, GameObject>();
            foreach (var keyValuePair in _projectileSet)
            {
                var projectile = new GameObject(keyValuePair.Value.name)
                {
                    transform =
                    {
                        parent = gameObject.transform,
                        localPosition = new Vector3(0, 0, 0)
                    }
                };
                _projectileGroups.Add(keyValuePair.Key, projectile);
            }
        }
        
        private void EffectSet()
        {
            _effectSet = new Dictionary<int, GameObject>()
            {
                {0, effectGreenCircle},
            };
        }

        private void EffectGroups()
        {
            _effectGroups = new Dictionary<int, GameObject>();
            foreach (var keyValuePair in _effectSet)
            {
                var effect = new GameObject(keyValuePair.Value.name)
                {
                    transform =
                    {
                        parent = gameObject.transform,
                        localPosition = new Vector3(0, 0, 0)
                    }
                };
                _effectGroups.Add(keyValuePair.Key, effect);
            }
        }

        private void GenerateMap()
        {
            var mapMatrixGenerator = new MapMatrixGenerator();
            _mapMatrix = mapMatrixGenerator.GetMapMatrix((_mapSize.x, _mapSize.y), _randomFillPercent);
            while (_mapMatrix.Sum(e => e.Count(i => i)) < minFloorTiles)
            {
                _mapMatrix = mapMatrixGenerator.GetMapMatrix((_mapSize.x, _mapSize.y), _randomFillPercent);
            }
            

            for (int x = 0; x < _mapSize.x; x++)
            {
                _tileGrid.Add(new List<GameObject>());
                for (int y = 0; y < _mapSize.y; y++)
                {
                    int tileId = _mapMatrix[x][y] ? 0 : 2;
                    CreateTile(tileId, (x, y));
                }
            }
        }

        private void CreateTile(int tileId, (int x, int y) coordinate)
        {
            var wallVersion = WallVersions.Square;
            if (tileId == 0)
            {
                wallVersion = GetWallVersion(coordinate);
            }

            if (wallVersion == WallVersions.CornerBL ||
                wallVersion == WallVersions.CornerBR ||
                wallVersion == WallVersions.CornerTL ||
                wallVersion == WallVersions.CornerTR)
            {
                tileId = 1;
            }

            if (wallVersion == WallVersions.DiagonalBL ||
                wallVersion == WallVersions.DiagonalBR ||
                wallVersion == WallVersions.DiagonalTL ||
                wallVersion == WallVersions.DiagonalTR)
            {
                tileId = 3;
            }

            var tilePrefab = _tileSet[tileId];
            var tileGroup = _tileGroups[tileId];

            if (tileId == 1)
            {
                switch (wallVersion)
                {
                    case WallVersions.CornerBL:
                        Rotate(180);
                        break;
                    case WallVersions.CornerBR:
                        Rotate(270);
                        break;
                    case WallVersions.CornerTL:
                        Rotate(90);
                        break;
                }
            }

            if (tileId == 3)
            {
                switch (wallVersion)
                {
                    case WallVersions.DiagonalBL:
                        Rotate(180);
                        break;
                    case WallVersions.DiagonalBR:
                        Rotate(270);
                        break;
                    case WallVersions.DiagonalTL:
                        Rotate(90);
                        break;
                }
            }

            var tile = Instantiate(tilePrefab, tileGroup.transform);

            tile.name = $"TileX{coordinate.x}Y{coordinate.y}";
            tile.transform.localPosition = new Vector3(coordinate.x, coordinate.y, 0);
            tile.tag = WallTag;

            _tileGrid[coordinate.x].Add(tile);

            tilePrefab.transform.eulerAngles = new Vector3(0, 0, 0);
            
            void Rotate(int degree) => tilePrefab.transform.eulerAngles = Vector3.forward * degree;
        }

        private void SetMapObjects()
        {
            var spawn = new SpawnLocation(_mapMatrix);
            GameObject dynamicObject;
            
            //spawn Player
            var playerSpawnLocation = spawn.PlayerSpawn();

            var player = GameObject.Find("Player");
            player.name = "Player";
            player.transform.localPosition = new Vector3(playerSpawnLocation.x, playerSpawnLocation.y);
            
            //spawn SpawnerPoint
            var dynamicPrefab = _dynamicObjectsSet[0];
            var dynamicGroup = _dynamicObjectsGroups[0];

            for (var i = 0; i < (int) Random.value * spawnerMinCount + spawnerRandomCount; i++)
            {
               var spawnerLocation = spawn.SpawnerLocation();
                dynamicObject = Instantiate(dynamicPrefab, dynamicGroup.transform);
   
               dynamicObject.name = $"SpawnerPointX{spawnerLocation.x}Y{spawnerLocation.y}";
               dynamicObject.transform.localPosition = new Vector3(spawnerLocation.x, spawnerLocation.y, 0);
   
               _dynamicObjects.Add(dynamicObject);
            }
            
            //spawn Door
             dynamicPrefab = _dynamicObjectsSet[2];
             dynamicGroup = _dynamicObjectsGroups[2];
             var doorLocation = spawn.DoorLocation();
             dynamicObject = Instantiate(dynamicPrefab, dynamicGroup.transform);
   
             dynamicObject.name = $"DoorX{doorLocation.x}Y{doorLocation.y}";
             dynamicObject.transform.localPosition = new Vector3(doorLocation.x, doorLocation.y, 0);
            // dynamicObject.tag = DoorTag;
   
             _dynamicObjects.Add(dynamicObject);
        }

        private WallVersions GetWallVersion((int x, int y) coordinate)
        {
            if (_mapMatrix is null)
            {
                return WallVersions.Square;
            }

            if (coordinate.x == 0 ||
                coordinate.x == _mapMatrix.Count - 1 ||
                coordinate.y == 0 ||
                coordinate.y == _mapMatrix[coordinate.x].Count - 1)
            {
                return WallVersions.Square;
            }

            //Corner
            if (SurroundingFits(new[] {4, 8}, new[] {1, 2, 3, 6, 9}))
            {
                return WallVersions.CornerTR;
            }

            if (SurroundingFits(new[] {6, 8}, new[] {1, 2, 3, 4, 7}))
            {
                return WallVersions.CornerTL;
            }

            if (SurroundingFits(new[] {2, 4}, new[] {3, 6, 7, 8, 9}))
            {
                return WallVersions.CornerBR;
            }

            if (SurroundingFits(new [] {2, 6}, new[] {1, 4, 7, 8, 9}))
            {
                return WallVersions.CornerBL;
            }

            if (SurroundingFits(new[] {1, 4, 8}, new[] {2, 3, 6, 9}))
            {
                return WallVersions.CornerTR;
            }

            if (SurroundingFits(new[] {4, 8, 9}, new[] {1, 2, 3, 6}))
            {
                return WallVersions.CornerTR;
            }

            if (SurroundingFits(new[] {3, 6, 8}, new[] {1, 2, 4, 7}))
            {
                return WallVersions.CornerTL;
            }

            if (SurroundingFits(new[] {6, 7, 8}, new[] {1, 2, 3, 4}))
            {
                return WallVersions.CornerTL;
            }

            if (SurroundingFits(new[] {2, 4, 7}, new[] {3, 6, 8, 9}))
            {
                return WallVersions.CornerBR;
            }

            if (SurroundingFits(new[] {3, 2, 4}, new[] {6, 7, 8, 9}))
            {
                return WallVersions.CornerBR;
            }

            if (SurroundingFits(new[] {2, 6, 9}, new[] {1, 4, 7, 8}))
            {
                return WallVersions.CornerBL;
            }

            if (SurroundingFits(new[] {1, 2, 6}, new[] {4, 7, 8, 9}))
            {
                return WallVersions.CornerBL;
            }

            //Diagonal
            if (SurroundingFits(new[] {1, 4, 8, 9}, new[] {2, 3, 6}))
            {
                return WallVersions.DiagonalTR;
            }

            if (SurroundingFits(new[] {3, 6, 7, 8}, new[] {1, 2, 4}))
            {
                return WallVersions.DiagonalTL;
            }

            if (SurroundingFits(new[] {2, 3, 4, 7}, new[] {6, 8, 9}))
            {
                return WallVersions.DiagonalBR;
            }

            if (SurroundingFits(new[] {1, 2, 6, 9}, new[] {4, 7, 8}))
            {
                return WallVersions.DiagonalBL;
            }

            return WallVersions.Square;

            bool SurroundingFits(int[] walls, int[] floors)
            {
                if (walls.Select(GetPrefix).Any(prefix => !_mapMatrix[coordinate.x + prefix.x][coordinate.y + prefix.y]))
                {
                    return false;
                }
                
                foreach (int field in floors)
                {
                    var (x, y) = GetPrefix(field);
                    if (_mapMatrix[coordinate.x + x][coordinate.y + y])
                    {
                        return false;
                    }
                }
                return true;
            }

            // Returns the prefix for the surrounding tiles
            //  1 # 2 # 3
            //  #########
            //  4 # 5 # 7
            //  #########
            //  6 # 8 # 9
            (int x, int y) GetPrefix(int a) => a switch
            {
                1 => (-1, 1),
                2 => (0, 1),
                3 => (1, 1),
                4 => (-1, 0),
                5 => (0, 0),
                6 => (1, 0),
                7 => (-1, -1),
                8 => (0, -1),
                9 => (1, -1),
                _ => (0, 0)
            };
        }

        private enum WallVersions
        {
            Square,
            CornerTL,
            CornerTR,
            CornerBL,
            CornerBR,
            DiagonalTL,
            DiagonalTR,
            DiagonalBL,
            DiagonalBR
        }

        ~MapGenerator()
        {
            ClearMap();
        }
    }
}
