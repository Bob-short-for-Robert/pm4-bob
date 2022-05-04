using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

namespace Altom.AltUnityTesterEditor.Tests.MapTools
{
    public class DoorTest
    {
        private bool first;
        private AltUnityVector2 startPos;
        public AltUnityDriver.AltUnityDriver altUnityDriver;
        //Before any test it connects with the socket
        [OneTimeSetUp]
        public void SetUp()
        {
            altUnityDriver =new AltUnityDriver.AltUnityDriver();
            altUnityDriver.LoadScene("Main");
            var player = altUnityDriver.FindObject(By.NAME, "Player");
            first = true;
            startPos = altUnityDriver.FindObject(By.NAME, "Player").getScreenPosition();
        }

        //At the end of the test closes the connection with the socket
        [OneTimeTearDown]
        public void TearDown()
        {
            altUnityDriver.Stop();
        }

        [SetUp]
        public void Reset()
        {
            first = true;
        }
    }
}