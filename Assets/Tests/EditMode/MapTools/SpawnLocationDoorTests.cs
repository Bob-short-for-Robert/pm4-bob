using MapTools;
using MapTools.Helper;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.MapTools
{
    public class SpawnLocationDoorTests : TestMaps
    {
        [Test]
        public void TestDoorSpawnRectangleMap()
        {
            var spawnLocation = new SpawnLocation(GetRectangleMap());
            Assert.AreEqual(new Vector3(4.0f, 6.0f, 0.0f), spawnLocation.DoorLocation());
        }
        
        [Test]
        public void TestDoorSpawnTwoFloorFixedOMap()
        {
            var spawnLocation = new SpawnLocation(GetTwoFloorFixedOMap());
            Assert.AreEqual(new Vector3(4f, 6f, 0f), spawnLocation.DoorLocation());
        }
        
        [Test]
        public void TestDoorSpawnTwoFloorFixedLMap()
        {
            var spawnLocation = new SpawnLocation(GetTwoFloorFixedLMap());
            Assert.AreEqual(new Vector3(4f, 6f, 0f), spawnLocation.DoorLocation());
        }
        
        [Test]
        public void TestDoorSpawnThreeFloorFixedMap()
        {
            var spawnLocation = new SpawnLocation(GetThreeFloorFixedMap());
            Assert.AreEqual(new Vector3(4f, 3f, 0f), spawnLocation.DoorLocation());
        }
        
        [Test]
        public void TestDoorSpawnComplexFixedMap()
        {
            var spawnLocation = new SpawnLocation(GetComplexFixedMap());
            Assert.AreEqual(new Vector3(21f, 17f, 0f), spawnLocation.DoorLocation());
        }
        
        [Test]
        public void TestDoorOnFloorComplexFixedMap()
        {
            {
                var map = GetComplexFixedMap();
                var spawnLocation = new SpawnLocation(map);
                var spawnerLocation = spawnLocation.DoorLocation();
                Assert.False( map[(int)spawnerLocation.x][(int)spawnerLocation.y]);
            }
        }
    }
}