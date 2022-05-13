using System.Collections;
using Altom.AltUnityDriver;
using NUnit.Framework;
using UnityEngine;

namespace Editor.Tests
{
    public class AutoShooterTest : MonoBehaviour
    {
        
        private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

        private const string SCENE_NAME = "AutoShooterTestScene";

        //Before any test it connects with the socket
        [OneTimeSetUp]
        public void SetUp()
        {
            _altUnityDriver.LoadScene(SCENE_NAME);
        }

        [SetUp]
        public void BeforeEach()
        {
            _altUnityDriver.LoadScene(SCENE_NAME);
        }

        //At the end of the test closes the connection with the socket
        [OneTimeTearDown]
        public void TearDown()
        {
            _altUnityDriver.Stop();
        }

        [Test]
        public void TestShooting()
        {
            Assert.True(_altUnityDriver.FindObjects(By.TAG, "Enemy").Count == 1);
            _altUnityDriver.WaitForObjectNotBePresent(By.TAG, "Enemy");
            Assert.That(() => _altUnityDriver.FindObject(By.TAG, "Enemy"),  
                Throws.Exception
                    .TypeOf<NotFoundException>());
        }

    }
}