using System.Collections.Generic;

namespace MapTools
{

    public class SpawnLocation
    {
        private readonly List<List<bool>> _mapMatrix;

        public SpawnLocation(List<List<bool>> mapMatrix)
        {
            _mapMatrix = mapMatrix;
        }

        public (int x, int y) PlayerSpawn()
        {
            (int x, int y) spawnPoint = (_mapMatrix.Count / 2 , _mapMatrix[0].Count / 2);

            while (_mapMatrix[spawnPoint.x][spawnPoint.y])
            {
                spawnPoint.x--;
            }

            return spawnPoint;
        }

        public (int x, int y) SpawnerLocation()
        {
            
            (int x, int y) spawnPoint = (_mapMatrix.Count / 2 , _mapMatrix[0].Count / 2);

            while (!_mapMatrix[spawnPoint.x][spawnPoint.y])
            {
                spawnPoint.y--;
            }

            spawnPoint.y++;

            return spawnPoint;
        }
    }
}