using System.Linq;
using System.Collections.Generic;

namespace MapTools
{
    /// <summary>
    /// Removes all smale floors on the given map
    /// </summary>
    public class SmallFloorConnector
    {
        private (bool wall, int floorID)[,] _floorMatrix;
        private readonly List<int> _floorCounts = new List<int>();
        private List<List<bool>> _mapMatrix;

        /// <summary>
        /// Removes all smale floors
        /// </summary>
        /// <param name="mapMatrix">Map in which the smale floor should be removed</param>
        public void ConnectSmallFloors(List<List<bool>> mapMatrix)
        {
            _mapMatrix = mapMatrix;
            _floorCounts.Clear();
            if (mapMatrix?[0] is null)
            {
                return;
            }

            _floorMatrix = new (bool wall, int floorID)[mapMatrix.Count , mapMatrix[0].Count];
            
            for (var x = 0; x < mapMatrix.Count; x++)
            {
                if (mapMatrix[x] is null)
                {
                    continue;
                }
                var mapY = mapMatrix[x];
                for (var y = 0; y < mapY.Count; y++)
                {
                    _floorMatrix[x,y] = (mapMatrix[x][y], 0);
                }
            }
            
            IndexFloors();
 
            FillSmaleFloors();
        }

        private void IndexFloors()
        {
            for (var x = 0; x < _floorMatrix.GetLength(0); x++)
            {
                for (var y = 0; y < _floorMatrix.GetLength(1); y++)
                {
                    if (_floorMatrix[x, y].wall) continue;
                    var surroundingFloorId = CheckSurroundingFloors(x, y);
                    if (surroundingFloorId == 0)
                    {
                        _floorCounts.Add(1);
                        _floorMatrix[x, y].floorID = _floorCounts.Count;
                    }
                    else
                    {
                        _floorMatrix[x, y].floorID = surroundingFloorId;
                        _floorCounts[surroundingFloorId - 1]++;
                    }
                }
            }
        }

        private int CheckSurroundingFloors(int x, int y)
        {
            var ids = new List<int>();

            if (!_floorMatrix[x - 1, y].wall)
            {
                ids.Add(_floorMatrix[x - 1, y].floorID);
            }
            if (!_floorMatrix[x,y - 1].wall)
            {
                ids.Add(_floorMatrix[x ,y - 1].floorID);
            }
 
            ids.Sort();

            if (ids.Count < 1)
            {
                return 0;
            }

            if (ids.Count == 1)
            {
                return ids[0];
            }

            if (ids[0] == ids[1])
            {
                return ids[0];
            }

            for (var ix = 0; ix < _floorMatrix.GetLength(0); ix++)
            {
                for (var iy = 0; iy < _floorMatrix.GetLength(1); iy++)
                {
                    if (_floorMatrix[ix, iy].floorID == ids[1])
                    {
                        _floorMatrix[ix, iy].floorID = ids[0];
                    }
                }
            }

            if (ids.Count != 2) return 0;
            _floorCounts[ids[0] - 1] += _floorCounts[ids[1] - 1];
            _floorCounts[ids[1] - 1] = 0;
            return ids[0];

        }

        private void FillSmaleFloors()
        {
            if (_floorCounts.Count == 1)
            {
                return;
            }

            var floorIds = new List<int>();
            var biggest = GetMaxIndex(_floorCounts) + 1;
            

            for (var i = 0; i < _floorCounts.Count; i++)
            {
                if (_floorCounts[i] != 0)
                {
                    floorIds.Add(i + 1);
                }
            }

            foreach (var floorId in floorIds.Where(floorId => floorId != biggest))
            {
                for (var x = 0; x < _floorMatrix.GetLength(0); x++)
                {
                    for (var y = 0; y < _floorMatrix.GetLength(1); y++)
                    {
                        if (_floorMatrix[x,y].floorID == floorId)
                        {
                            _mapMatrix[x][y] = true;
                        }
                    }
                }
            }
        }

        private static int GetMaxIndex(List<int> list)
        {
            var numbers = list.ToArray();
            var biggestNumber = numbers.Max();
            return list.IndexOf(biggestNumber);
        }
    }
}
