using System.Collections;
using MapTools;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.MapTools
{
    public class SpawnObjectTests : MapTestSetUp
    {
        private readonly GameObject _gameObject =
            (GameObject) Resources.Load("TestPrefabs/TestPrefab", typeof(GameObject));

        [UnityTest]
        public IEnumerator TestSpawnObjectPosOnly()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var posToSet = new Vector3(20, 30, 0);
            SpawnObject.Spawn(_gameObject, posToSet);
            var pos = GameObject.FindGameObjectWithTag("Tower").transform.position;
            Assert.AreEqual(posToSet, new Vector3((int) pos.x, (int) pos.y, 0));
        }

        [UnityTest]
        public IEnumerator TestSpawnObjectAngle()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var posToSet = new Vector3(20, 30, 0);
            const float angle = 2f;
            SpawnObject.Spawn(_gameObject, posToSet, angle);
            var rotation = GameObject.FindGameObjectWithTag("Tower").transform.rotation;
            Assert.AreEqual(Quaternion.Euler(new Vector3(0f, 0f, angle)), rotation);
        }

        [UnityTest]
        public IEnumerator TestSpawnObjectRotation()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var posToSet = new Vector3(20, 30, 0);
            var rotationToTest = Quaternion.Euler(new Vector3(0f, 0f, 3));
            SpawnObject.Spawn(_gameObject, posToSet, rotationToTest);
            var rotation = GameObject.FindGameObjectWithTag("Tower").transform.rotation;
            Assert.AreEqual(rotationToTest, rotation);
        }

        [UnityTest]
        public IEnumerator TestSpawnObjectName()
        {
            yield return new WaitWhile(() => SceneLoaded == false);

            var posToSet = new Vector3(20, 30, 0);
            SpawnObject.Spawn(_gameObject, posToSet);
            var name = GameObject.FindGameObjectWithTag("Tower").name;
            Assert.AreEqual("TestPrefabX20Y30", name);
        }
    }
}
