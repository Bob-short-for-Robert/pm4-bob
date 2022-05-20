using Altom.AltUnityDriver;
using NUnit.Framework;
using UnityEngine;

public class SpawnTowerTest : MonoBehaviour
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

    private const string SCENE_NAME = "PlaceTowerTestScene";

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
    public void TestSpawn()
    {
        _altUnityDriver.PressKey(AltUnityKeyCode.D, 1, 3);
        _altUnityDriver.PressKey(AltUnityKeyCode.E);
        Assert.True(_altUnityDriver.FindObject(By.TAG, "Tower").enabled);
    }


    [Test]
    public void TestSpawnFail()
    {
        _altUnityDriver.PressKey(AltUnityKeyCode.E);
        try
        {
            _altUnityDriver.FindObject(By.NAME, "Tower");
            Assert.IsTrue(false);
        }
        catch
        {
            // ignored
        }
    }
}
