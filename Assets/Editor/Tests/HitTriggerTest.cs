using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

public class HitTriggerTest : MonoBehaviour
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

    private const string SCENE_NAME = "HitTriggerTestScene";

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


    [Test]
    public void TestSpillBlood()
    {
        _altUnityDriver.MoveMouse(new AltUnityVector2(100, 100), 1F, true);
        Assert.NotNull(_altUnityDriver.FindObject(By.TAG, "Environment"));
        
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        _altUnityDriver.Stop();
    }
}
