using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace MapTools.Helper
{
    /// <summary>
    /// Generates a new map. This map will be smooth.
    /// </summary>
    public class MapMatrixGenerator
    {
        private (int x, int y) _mapSize;
        private readonly List<List<bool>> _map = new List<List<bool>>();
        private int _randomFillPercent;

        /// <summary>
        /// Generates a new map, with the given size and fill percentage.
        /// </summary>
        /// <param name="mapSize">X and Y size of the map</param>
        /// <param name="randomFillPercent">Floor fill percentage of the map</param>
        /// <returns>Map matrix, true if it is a Wall</returns>
        public List<List<bool>> GetMapMatrix((int x, int y) mapSize, int randomFillPercent)
        {
            if (_map.Count > 0)
            {
                _map.ForEach(s => s.Clear());
                _map.Clear();
            }
            
            _mapSize = mapSize;
            _randomFillPercent = randomFillPercent;

            RandomFillMap();
            
            for (var i = 0; i < 5; i++)
            {
                SmoothMap();
            }
            new SmallFloorConnector().ConnectSmallFloors(_map);
            
            return  _map;
        }

        private void RandomFillMap()
        {
            for (var x = 0; x < _mapSize.x; x++)
            {
                _map.Add(new List<bool>());
                for (var y = 0; y < _mapSize.y; y++)
                {
                    if (x == 0 || x == _mapSize.x - 1 ||
                        y == 0 || y == _mapSize.y - 1)
                    {
                        _map[x].Add(true);
                    }
                    else
                    {
                        _map[x].Add((int) (Random.value * 100) < _randomFillPercent);
                    }

                }
            }
        }

        private void SmoothMap()
        {
            for (var x = 0; x < _mapSize.x; x++)
            {
                for (var y = 0; y < _mapSize.y; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount((x, y));

                    if (neighbourWallTiles > 4)
                    {
                        _map[x][y] = true;
                    }
                    else if (neighbourWallTiles < 4)
                    {
                        _map[x][y] = false;
                    }
                }
            }
        }

        private int GetSurroundingWallCount((int x, int y) coordinate)
        {
            var wallCount = 0;
            var (x, y) = coordinate;
            for (var neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
            {
                for (var neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < _mapSize.x && neighbourY >= 0 && neighbourY < _mapSize.y)
                    {
                        if (neighbourX != x || neighbourY != y)
                        {
                            wallCount += _map[neighbourX][neighbourY] ? 1 : 0;
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }
            
            return wallCount;
        }
    }
}
