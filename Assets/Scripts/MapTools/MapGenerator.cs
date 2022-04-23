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
        private List<List<bool>> _mapMatrix;
        private int _randomFillPercent = 35;

        //Prefabs
        public GameObject prefabWallBlack;
        public GameObject prefabWallBlackCorner;
        public GameObject prefabWallBlackDtr;
        public GameObject prefabFloor;
        
        //Objects
        public GameObject spawner;

        private void Start()
        {
            SetMapValue();
            CreateTileSet();
            CreateTileGroups();
            DynamicObjectsSet();
            DynamicObjectsGroups();
            GenerateMap();
            SetMapObjects();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(1)) return;
            ClearMap();
            SetMapValue();
            GenerateMap();
            SetMapObjects();
        }

        private void ClearMap()
        {
            foreach (var tile in _tileGrid.SelectMany(mapY => mapY))
            {
                Destroy(tile.gameObject);
            }

            foreach (var dynamicObjects in _dynamicObjects)
            {
                Destroy(dynamicObjects.gameObject);
            }

            _tileGrid.Clear();

        }

        private void SetMapValue()
        {
            _randomFillPercent = (int) (Random.value * 10 + 35);
            _mapSize.x = (int) (Random.value * 20 + 20);
            _mapSize.y = (int) (Random.value * 20 + 20);
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
                GameObject tileGroup = new GameObject(keyValuePair.Value.name);
                tileGroup.transform.parent = gameObject.transform;
                tileGroup.transform.localPosition = new Vector3(0, 0, 0);
                _tileGroups.Add(keyValuePair.Key, tileGroup);
            }
        }

        private void DynamicObjectsSet()
        {
            _dynamicObjectsSet = new Dictionary<int, GameObject>()
                {
                    {0, spawner},
                };
        }

        private void DynamicObjectsGroups()
        {
            _dynamicObjectsGroups = new Dictionary<int, GameObject>();
            foreach (var keyValuePair in _dynamicObjectsSet)
            {
                GameObject dynamicObject = new GameObject(keyValuePair.Value.name);
                dynamicObject.transform.parent = gameObject.transform;
                dynamicObject.transform.localPosition = new Vector3(0, 0, 0);
                _dynamicObjectsGroups.Add(keyValuePair.Key, dynamicObject);
            }
        }

        private void GenerateMap()
        {
            _mapMatrix = new MapMatrixGenerator().GetMapMatrix((_mapSize.x, _mapSize.y), _randomFillPercent);

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

            GameObject tile = Instantiate(tilePrefab, tileGroup.transform);

            tile.name = string.Format("TileX{0}Y{1}", coordinate.x, coordinate.y);
            tile.transform.localPosition = new Vector3(coordinate.x, coordinate.y, 0);

            _tileGrid[coordinate.x].Add(tile);

            tilePrefab.transform.eulerAngles = new Vector3(0, 0, 0);
            
            void Rotate(int degree) => tilePrefab.transform.eulerAngles = Vector3.forward * degree;
        }

        private void SetMapObjects()
        {
            var spawn = new SpawnLocation(_mapMatrix);

            var playerSpawnLocation = spawn.PlayerSpawn();

            var player = GameObject.Find("Player");
            player.name = "Player";
            player.transform.localPosition = new Vector3(playerSpawnLocation.x, playerSpawnLocation.y);

            var dynamicPrefab = _dynamicObjectsSet[0];
            var dynamicGroup = _dynamicObjectsGroups[0];

            for (var i = 0; i < (int) Random.value * 2 + 3; i++)
            {
               var spawnerLocation = spawn.SpawnerLocation();
               var dynamicObject = Instantiate(dynamicPrefab, dynamicGroup.transform);
   
               dynamicObject.name = string.Format("SparnPointX{0}Y{1}", spawnerLocation.x, spawnerLocation.y);
               dynamicObject.transform.localPosition = new Vector3(spawnerLocation.x, spawnerLocation.y, 0);
   
               _dynamicObjects.Add(dynamicObject); 
            }
            
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
                foreach (int field in walls)
                {
                    (int x, int y) prefix = GetPrefix(field);
                    if (!_mapMatrix[coordinate.x + prefix.x][coordinate.y + prefix.y])
                    {
                        return false;
                    }
                }

                foreach (int field in floors)
                {
                    (int x, int y) prefix = GetPrefix(field);
                    if (_mapMatrix[coordinate.x + prefix.x][coordinate.y + prefix.y])
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

        public enum WallVersions
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
    }
}
