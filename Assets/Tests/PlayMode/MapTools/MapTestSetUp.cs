using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


namespace Tests.PlayMode.MapTools
{
    public class MapTestSetUp
    {
        protected bool SceneLoaded;

        [SetUp]
        public void InitBookScene()
        {
            Random.InitState(100000);
            SceneLoaded = false;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("MapGeneratorTests", LoadSceneMode.Single);
        }
        
        

        [TearDown]
        public void TearDown()
        {
            Object.FindObjectsOfType<GameObject>().ToList()
                .ForEach(Object.DestroyImmediate);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneLoaded = true;
        }
    }
}