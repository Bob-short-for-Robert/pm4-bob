using System.Collections.Generic;
using UnityEngine;
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

        public Vector3 PlayerSpawn()
        {
            (int x, int y) spawnPoint = (_mapMatrix.Count / 2, _mapMatrix[0].Count / 2);

            while (_mapMatrix[spawnPoint.x][spawnPoint.y])
            {
                spawnPoint.x--;
            }

            return new Vector3(spawnPoint.x, spawnPoint.y, 0);
        }

        public Vector3 DoorLocation()
        {
            (int x, int y) spawnPoint = (_mapMatrix.Count / 2, _mapMatrix[0].Count - 1);
            while (_mapMatrix[spawnPoint.x][spawnPoint.y])
            {
                spawnPoint.y--;
            }

            return new Vector3(spawnPoint.x, spawnPoint.y, 0);
        }

        public Vector3 SpawnerLocation()
        {
            (int x, int y) spawnPoint = (0, 0);

            while (_mapMatrix[spawnPoint.x][spawnPoint.y])
            {
                var xModifier = Random.value > 0.5 ? 1 : -1;
                var yModifier = Random.value > 0.5 ? 1 : -1;

                spawnPoint = ((int) (Random.value * (_mapMatrix.Count - 1)),
                    (int) (Random.value * (_mapMatrix[0].Count - 1)));

                while (!_mapMatrix[spawnPoint.x][spawnPoint.y])
                {
                    spawnPoint.x += xModifier;
                    spawnPoint.y += yModifier;
                }

                spawnPoint.x -= xModifier;
                spawnPoint.y -= yModifier;

                if (spawnPoint.x <= 0)
                {
                    spawnPoint.x = 0;
                }

                if (spawnPoint.x > _mapMatrix.Count)
                {
                    spawnPoint.x = 0;
                }

                if (spawnPoint.y <= 0)
                {
                    spawnPoint.y = 0;
                }

                if (spawnPoint.y > _mapMatrix[0].Count)
                {
                    spawnPoint.y = 0;
                }
            }

            return new Vector3(spawnPoint.x, spawnPoint.y, 0);
        }
    }
}
