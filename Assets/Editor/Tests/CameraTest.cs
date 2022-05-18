using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraTest : MonoBehaviour
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();
    private const string SCENE_NAME = "Main";

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
    public void TestMoveCamera()
    {
        float startX = _altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().x;
        float startY = _altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().y;
        _altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 5F);
        _altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 5F);
        Assert.GreaterOrEqual(_altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().x, startX);
        Assert.GreaterOrEqual(_altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().y, startY);
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        _altUnityDriver.Stop();
    }
}
