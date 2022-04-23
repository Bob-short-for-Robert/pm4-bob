using System.Collections.Generic;
using Random = UnityEngine.Random;

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
            (int x, int y) spawnPoint = (0, 0);
            
            while (_mapMatrix[spawnPoint.x][spawnPoint.y])
            {
                var xModifier = Random.value > 0.5 ? 1 : -1;
                var yModifier = Random.value > 0.5 ? 1 : -1;
            
                spawnPoint = ((int) (Random.value * (_mapMatrix.Count - 1)), (int) (Random.value * (_mapMatrix[0].Count - 1)));

                while (!_mapMatrix[spawnPoint.x][spawnPoint.y])
                {
                    spawnPoint.x += xModifier;
                    spawnPoint.y += yModifier;
                }

                spawnPoint.x -= xModifier;
                spawnPoint.y -= yModifier;
            }
            return spawnPoint;
        }
    }
}