using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace PlayMode
{
    public class BookUITests
    {
        private bool _sceneLoaded;
        private Button _newRunButton;
        private Text _scoreDisplay;
        private bool _clicked;

        [SetUp]
        public void InitBookScene()
        {
            _sceneLoaded = false;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Book", LoadSceneMode.Single);
        }

        [TearDown]
        public void TearDown()
        {
            Object.FindObjectsOfType<GameObject>().ToList()
                .ForEach(go => GameObject.DestroyImmediate(go));
        }

        [UnityTest]
        public IEnumerator TestTransitionToMain()
        {
            yield return new WaitWhile(() => _sceneLoaded == false);
            var nextRunButton = GameObject.Find("NextRunButton");
            _newRunButton = nextRunButton.GetComponent<Button>();
            Assert.IsNotNull(_newRunButton);
            _clicked = false;
            _newRunButton.onClick.AddListener(Clicked);
            _newRunButton.onClick.Invoke();
            Assert.True(_clicked);
            yield return null;
            yield return new WaitForSeconds(1);
            Assert.AreEqual("Main", SceneManager.GetActiveScene().name);
        }

        [UnityTest]
        public IEnumerator TestCurrentScoreIsUpdated()
        {
            yield return new WaitWhile(() => _sceneLoaded == false);
            var scoreDisplay = GameObject.Find("ScoreDisplay");
            _scoreDisplay = scoreDisplay.GetComponent<Text>();
            Assert.IsNotNull(_scoreDisplay);
            yield return null;
            Assert.AreEqual("0", _scoreDisplay.text);
            GameController.Instance.AddPoints(10);
            yield return null;
            yield return new WaitForSeconds(1);
            Assert.AreEqual("10", _scoreDisplay.text);
        }

        private void Clicked()
        {
            _clicked = true;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _sceneLoaded = true;
        }
    }
}
