using System;
using System.Collections;
using System.Collections.Generic;
using NLog.Fluent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapTools
{
    public class MapMatrixGenerator
    {
        private (int x, int y) mapSize;
        private List<List<bool>> map = new List<List<bool>>();


        private int randomFillPercent;


        public List<List<bool>> GetMapMatrix((int x, int y) mapSize, int randomFillPercent)
        {
            this.mapSize = mapSize;
            this.randomFillPercent = randomFillPercent;

            RandomFillMap();
            
            
            
            for (int i = 0; i < 5; i++)
            {
                SmoothMap();
            }

            return new SmallFloorConnector().ConnectSmallFloors(map);;
        }

        private void RandomFillMap()
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                map.Add(new List<bool>());
                for (int y = 0; y < mapSize.y; y++)
                {
                    if (x == 0 || x == mapSize.x - 1 ||
                        y == 0 || y == mapSize.y - 1)
                    {
                        map[x].Add(true);
                    }
                    else
                    {
                        map[x].Add((int) (Random.value * 100) < randomFillPercent ? true : false);
                    }

                }
            }
        }

        private void SmoothMap()
        {
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    int neighbourWallTiles = GetSurroundingWallCount((x, y));

                    if (neighbourWallTiles > 4)
                    {
                        map[x][y] = true;
                    }
                    else if (neighbourWallTiles < 4)
                    {
                        map[x][y] = false;
                    }
                }
            }
        }

        int GetSurroundingWallCount((int x, int y) coordinate)
        {
            int wallCount = 0;
            for (int neighbourX = coordinate.x - 1; neighbourX <= coordinate.x + 1; neighbourX++)
            {
                for (int neighbourY = coordinate.y - 1; neighbourY <= coordinate.y + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < mapSize.x && neighbourY >= 0 && neighbourY < mapSize.y)
                    {
                        if (neighbourX != coordinate.x || neighbourY != coordinate.y)
                        {
                            wallCount += map[neighbourX][neighbourY] ? 1 : 0;
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            Console.WriteLine(wallCount);
            return wallCount;
        }
    }
}
