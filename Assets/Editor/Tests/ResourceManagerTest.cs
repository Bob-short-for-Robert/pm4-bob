using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

public class ResourceManagerTest
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

    private const string SCENE_NAME = "ResourceMangerTestScene";

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
    public void CollectResources()
    {
        
        int resNr = _altUnityDriver.FindObjects(By.TAG, "Resources").Count;
        _altUnityDriver.PressKey(AltUnityKeyCode.A, 1f, 2f, true);
        Assert.LessOrEqual(_altUnityDriver.FindObjects(By.TAG, "Resources").Count, resNr);
    }


    [Test]
    public void TestMonsterDrops()
    {
        int resNr = _altUnityDriver.FindObjects(By.TAG, "Resources").Count;
        _altUnityDriver.Click(new AltUnityVector2(-1, 0), 500, 0.01f, true);
        Assert.Greater(_altUnityDriver.FindObjects(By.TAG, "Resources").Count, resNr);
    }
}
