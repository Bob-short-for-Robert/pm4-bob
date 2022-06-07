using MapTools.Helper;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MapTools
{
    public class SpawnLocationSpawnerTests : TestMaps
    {
        [SetUp]
        public void Init()
        {
            Random.InitState(100000);
        }

        [Test]
        public void TestSpawnerSpawnRectangleMap()
        {
            var spawnLocation = new SpawnLocation(GetRectangleMap());
            Assert.AreEqual(new Vector3(1f, 2f, 0f), spawnLocation.SpawnerLocation());
        }

        [Test]
        public void TestSpawnerSpawnTwoFloorFixedOMap()
        {
            var spawnLocation = new SpawnLocation(GetTwoFloorFixedOMap());
            Assert.AreEqual(new Vector3(1f, 2f, 0f), spawnLocation.SpawnerLocation());
        }

        [Test]
        public void TestSpawnerSpawnTwoFloorFixedLMap()
        {
            var spawnLocation = new SpawnLocation(GetTwoFloorFixedLMap());
            Assert.AreEqual(new Vector3(1f, 2f, 0f), spawnLocation.SpawnerLocation());
        }

        [Test]
        public void TestSpawnerSpawnThreeFloorFixedMap()
        {
            var spawnLocation = new SpawnLocation(GetThreeFloorFixedMap());
            Assert.AreEqual(new Vector3(1f, 2f, 0f), spawnLocation.SpawnerLocation());
        }

        [Test]
        public void TestSpawnerSpawnComplexFixedMap()
        {
            var spawnLocation = new SpawnLocation(GetComplexFixedMap());
            Assert.AreEqual(new Vector3(22f, 1f, 0f), spawnLocation.SpawnerLocation());
        }

        [Test]
        public void TestSpawnerOnFloorComplexFixedMap()
        {
            {
                var map = GetComplexFixedMap();
                var spawnLocation = new SpawnLocation(map);
                var spawnerLocation = spawnLocation.SpawnerLocation();
                Assert.False(map[(int) spawnerLocation.x][(int) spawnerLocation.y]);
            }
        }
    }
}
