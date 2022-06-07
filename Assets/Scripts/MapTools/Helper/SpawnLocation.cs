using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapTools.Helper
{
    /// <summary>
    /// Calculate the spawn position of an object.
    /// </summary>
    public class SpawnLocation
    {
        private readonly List<List<bool>> _mapMatrix;

        public SpawnLocation(List<List<bool>> mapMatrix)
        {
            _mapMatrix = mapMatrix;
        }

        /// <summary>
        /// Calculate the Player spawn position.
        /// </summary>
        /// <returns>Spawn position</returns>
        public Vector3 PlayerSpawn()
        {
            var (x, y) = (_mapMatrix.Count / 2, _mapMatrix[0].Count / 2);

            while (_mapMatrix[x][y])
            {
                x--;
            }

            return new Vector3(x, y, 0);
        }

        /// <summary>
        /// Calculate the Door spawn position.
        /// </summary>
        /// <returns>Spawn position</returns>
        public Vector3 DoorLocation()
        {
            var (x, y) = (_mapMatrix.Count / 2, _mapMatrix[0].Count - 1);
            while (_mapMatrix[x][y])
            {
                y--;
            }

            return new Vector3(x, y, 0);
        }

        /// <summary>
        /// Calculate the Spawner spawn position.
        /// </summary>
        /// <returns>Spawn position</returns>
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
