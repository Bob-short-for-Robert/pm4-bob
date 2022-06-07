using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.MapTools
{
    public class MapGeneratorTests : MapTestSetUp
    {
        [UnityTest]
        public IEnumerator TestPlayerPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("Player").transform.position;
            Assert.AreEqual(new Vector3(19, 37, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestSpawnPointPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("EnemySpawnPointX5Y68").transform.position;
            Assert.AreEqual(new Vector3(5, 68, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestDoorPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("PFB_WallDoorX19Y72").transform.position;
            Assert.AreEqual(new Vector3(19, 72, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestCornerWallPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("TileX37Y45").transform.position;
            Assert.AreEqual(new Vector3(37, 45, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestWall_DTRPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("TileX7Y29").transform.position;
            Assert.AreEqual(new Vector3(7, 29, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestFloorPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("TileX3Y54").transform.position;
            Assert.AreEqual(new Vector3(3, 54, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestWallPos()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var pos = GameObject.Find("TileX2Y27").transform.position;
            Assert.AreEqual(new Vector3(2, 27, 0), new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestCornerWallSprite()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var name = GameObject.Find("TileX37Y45").GetComponent<SpriteRenderer>().sprite.name;
            Assert.AreEqual("TEX_WallBlack_Corner", name);
        }

        [UnityTest]
        public IEnumerator TestWall_DTRSprite()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var name = GameObject.Find("TileX7Y29").GetComponent<SpriteRenderer>().sprite.name;
            Assert.AreEqual("TEX_WallBlack_DTR", name);
        }

        [UnityTest]
        public IEnumerator TestFloorSprite()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var name = GameObject.Find("TileX3Y54").GetComponent<SpriteRenderer>().sprite.name;
            Assert.AreEqual("TEX_Floor_Plates", name);
        }

        [UnityTest]
        public IEnumerator TestWallSprite()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var name = GameObject.Find("TileX2Y27").GetComponent<SpriteRenderer>().sprite.name;
            Assert.AreEqual("TEX_WallBlack", name);
        }

        [UnityTest]
        public IEnumerator TestWallCount()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            Assert.AreEqual(543, GameObject.FindGameObjectsWithTag("Wall").Length);
        }

        [UnityTest]
        public IEnumerator TestFloorCount()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            Assert.AreEqual(2382, GameObject.FindGameObjectsWithTag("Floor").Length);
        }

        [UnityTest]
        public IEnumerator TestSpawnPointCount()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            Assert.AreEqual(6, GameObject.FindGameObjectsWithTag("SpawnPoint").Length);
        }
    }
}
