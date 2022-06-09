using System.Collections.Generic;
using MapTools.Helper;
using NUnit.Framework;

namespace Tests.EditMode.MapTools
{
    [TestFixture]
    public class SmallFloorConnectorTests : TestMaps
    {
        private List<List<bool>> _mapMatrix = new List<List<bool>>();
        private SmallFloorConnector _connector;

        [SetUp]
        public void Init()
        {
            _connector = new SmallFloorConnector();
        }

        [Test]
        public void TestOneFloorMap()
        {
            _mapMatrix = GetRectangleMap();
            _connector.ConnectSmallFloors(_mapMatrix);
            Assert.AreEqual(GetRectangleMap(), _mapMatrix);
        }

        [Test]
        public void TestTwoFloorLMap()
        {
            _mapMatrix = GetTwoFloorLMap();
            _connector.ConnectSmallFloors(_mapMatrix);
            Assert.AreEqual(GetTwoFloorFixedLMap(), _mapMatrix);
        }

        [Test]
        public void TestTwoFloorOMap()
        {
            _mapMatrix = GetTwoFloorOMap();
            _connector.ConnectSmallFloors(_mapMatrix);
            Assert.AreEqual(GetTwoFloorFixedOMap(), _mapMatrix);
        }

        [Test]
        public void TestThreeFloorMap()
        {
            _mapMatrix = GetThreeFloorMap();
            _connector.ConnectSmallFloors(_mapMatrix);
            Assert.AreEqual(GetThreeFloorFixedMap(), _mapMatrix);
        }

        [Test]
        public void TestComplexMap()
        {
            _mapMatrix = GetComplexMap();
            _connector.ConnectSmallFloors(_mapMatrix);
            Assert.AreEqual(GetComplexFixedMap(), _mapMatrix);
        }
    }
}
