using Altom.AltUnityDriver;
using NUnit.Framework;
using UnityEngine;

namespace AltUnityTester.Editor.Tests
{
    public class TowerTest
    {
        
        public AltUnityDriver altUnityDriver;
        
        //Before any test it connects with the socket
        [OneTimeSetUp]
        public void SetUp()
        {
            altUnityDriver = new AltUnityDriver();
            altUnityDriver.LoadScene("Main");
        }

        //At the end of the test closes the connection with the socket
        [OneTimeTearDown]
        public void TearDown()
        {
            altUnityDriver.Stop();
        }

        [Test]
        public void TestSpawn()
        {
            altUnityDriver.PressKey(AltUnityKeyCode.E);
            Assert.True(altUnityDriver.FindObject(By.TAG, "Tower").enabled);
        }
    }
}