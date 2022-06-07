using MapTools;
using MapTools.Helper;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MapTools
{
    public class SpawnLocationPlayerTests : TestMaps
    {
        [Test]
        public void TestPlayerSpawnRectangleMap()
        {
            var spawnLocation = new SpawnLocation(GetRectangleMap());
            Assert.AreEqual(new Vector3(4f, 4f, 0f), spawnLocation.PlayerSpawn());
        }
        
        [Test]
        public void TestPlayerSpawnTwoFloorFixedOMap()
        {
            var spawnLocation = new SpawnLocation(GetTwoFloorFixedOMap());
            Assert.AreEqual(new Vector3(4f, 4f, 0f), spawnLocation.PlayerSpawn());
        }
        
        [Test]
        public void TestPlayerSpawnTwoFloorFixedLMap()
        {
            var spawnLocation = new SpawnLocation(GetTwoFloorFixedLMap());
            Assert.AreEqual(new Vector3(4f, 4f, 0f), spawnLocation.PlayerSpawn());
        }
        
        [Test]
        public void TestPlayerSpawnThreeFloorFixedMap()
        {
            var spawnLocation = new SpawnLocation(GetThreeFloorFixedMap());
            Assert.AreEqual(new Vector3(1f, 4f, 0f), spawnLocation.PlayerSpawn());
        }
        
        [Test]
        public void TestPlayerSpawnComplexFixedMap()
        {
            var spawnLocation = new SpawnLocation(GetComplexFixedMap());
            Assert.AreEqual(new Vector3(21f, 12f, 0f), spawnLocation.PlayerSpawn());
        }
        
        [Test]
        public void TestPlayerOnFloorComplexFixedMap()
        {
            {
                var map = GetComplexFixedMap();
                var spawnLocation = new SpawnLocation(map);
                var spawnerLocation = spawnLocation.PlayerSpawn();
                Assert.False( map[(int)spawnerLocation.x][(int)spawnerLocation.y]);
            }
        }
    }
}