using System;
using System.Collections.Generic;
using System.Linq;
using Enemy;
using MapTools.Helper;
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

        private List<List<bool>> _mapMatrix;
        private int _randomFillPercent = 35;

        //config
        [SerializeField] [Range(40, 50)] private int mapMinSize = 45;
        [SerializeField] [Range(10, 60)] private int randomMapSize = 40;
        [SerializeField] [Range(10, 20)] private int minFillPercent = 12;
        [SerializeField] [Range(20, 40)] private int randomFillPercent = 30;
        [SerializeField] [Range(50, 500)] private int minFloorTiles = 200;
        [SerializeField] [Range(1, 10)] private int spawnerMinCount = 2;
        [SerializeField] [Range(0, 10)] private int spawnerRandomCount = 3;

        //Prefabs
        [SerializeField] private GameObject prefabWallBlack;
        [SerializeField] private GameObject prefabWallBlackCorner;
        [SerializeField] private GameObject prefabWallBlackDtr;
        [SerializeField] private GameObject prefabFloor;


        //Objects
        [SerializeField] private GameObject prefabSpawner;
        [SerializeField] private GameObject prefabDoor;
        
        //Wave
        [SerializeField] [Range(3, 10)] private int waveMinCount = 3;
        [SerializeField] [Range(0, 20)] private int randomWaveCount = 5;
        [SerializeField] [Range(5, 20)] private int waveInterval = 10;
        public void Start()
        {
            SetMapValue();
            CreateTileSet();
            CreateTileGroups();
            GenerateMap();
            SetMapObjects();
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


        private void GenerateMap()
        {
            var mapMatrixGenerator = new MapMatrixGenerator();
            _mapMatrix = mapMatrixGenerator.GetMapMatrix((_mapSize.x, _mapSize.y), _randomFillPercent);
            while (_mapMatrix.Sum(e => e.Count(i => i)) < minFloorTiles)
            {
                _mapMatrix = mapMatrixGenerator.GetMapMatrix((_mapSize.x, _mapSize.y), _randomFillPercent);
            }


            for (var x = 0; x < _mapSize.x; x++)
            {
                _tileGrid.Add(new List<GameObject>());
                for (var y = 0; y < _mapSize.y; y++)
                {
                    var tileId = _mapMatrix[x][y] ? 0 : 2;
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

            switch (wallVersion)
            {
                case WallVersions.CornerBL:
                case WallVersions.CornerBR:
                case WallVersions.CornerTL:
                case WallVersions.CornerTR:
                    tileId = 1;
                    break;
                case WallVersions.DiagonalBL:
                case WallVersions.DiagonalBR:
                case WallVersions.DiagonalTL:
                case WallVersions.DiagonalTR:
                    tileId = 3;
                    break;
                case WallVersions.Square:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
                    case WallVersions.Square:
                        break;
                    case WallVersions.CornerTL:
                        break;
                    case WallVersions.CornerTR:
                        break;
                    case WallVersions.CornerBL:
                        break;
                    case WallVersions.CornerBR:
                        break;
                    case WallVersions.DiagonalTR:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var tile = Instantiate(tilePrefab, tileGroup.transform);

            tile.name = $"TileX{coordinate.x}Y{coordinate.y}";
            tile.transform.localPosition = new Vector3(coordinate.x, coordinate.y, 0);

            _tileGrid[coordinate.x].Add(tile);

            tilePrefab.transform.eulerAngles = new Vector3(0, 0, 0);

            void Rotate(int degree) => tilePrefab.transform.eulerAngles = Vector3.forward * degree;
        }

        private void SetMapObjects()
        {
            var spawn = new SpawnLocation(_mapMatrix);

            //spawn Player
            var player = GameObject.Find("Player");
            player.name = "Player";
            player.transform.localPosition = spawn.PlayerSpawn();

            //spawn SpawnerPoint
            for (var i = 0; i < (int) Random.value * spawnerMinCount + spawnerRandomCount; i++)
            {
                SpawnObject.Spawn(prefabSpawner, spawn.SpawnerLocation(), 0);
            }

            var spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            foreach (var spawnPoint in spawnPoints)
            {
                spawnPoint.GetComponent<SpawnPoint>().InitPoint(
                    Random.value > 0.5, 
                    waveInterval, 
                    (int) (Random.value * waveMinCount + randomWaveCount));
            }
            
            //spawn Door
            SpawnObject.Spawn(prefabDoor, spawn.DoorLocation(), 0);
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

            if (SurroundingFits(new[] {2, 6}, new[] {1, 4, 7, 8, 9}))
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
                if (walls.Select(GetPrefix)
                    .Any(prefix => !_mapMatrix[coordinate.x + prefix.x][coordinate.y + prefix.y]))
                {
                    return false;
                }

                foreach (var field in floors)
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
    }
}
