using MapTools;
using MapTools.Helper;
using NUnit.Framework;
using Random = UnityEngine.Random;

namespace Tests.EditMode.MapTools
{
    public class MapMatrixGeneratorTests : TestMaps
    {
        private MapMatrixGenerator _generator;
        
        [SetUp]
        public void Init()
        {
            _generator = new MapMatrixGenerator();
            Random.InitState(100000);
        }

        [Test]
        public void TestMapSize()
        {
            var mapSize = (50, 50);
            var mapMatrix = _generator.GetMapMatrix(mapSize, 50);
            Assert.AreEqual(mapSize, (mapMatrix.Count, mapMatrix[0].Count));
        }

        [Test]
        public void TestFillPercentage()
        {
            var mapMatrix = _generator.GetMapMatrix((50, 50), 50);
            var count = 0;
            mapMatrix.ForEach(a => count += a.FindAll(s => s == false).Count);
            Assert.AreEqual(318, count);
        }

        [Test]
        public void TestMap()
        {
            var (matrix, size, randomFillPrecent) = GeneratorTestMap();
            Assert.AreEqual(matrix, _generator.GetMapMatrix(size, randomFillPrecent));
        }
    }
}