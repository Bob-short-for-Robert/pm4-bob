using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class CameraTest : MonoBehaviour
{
    private AltUnityDriver altUnityDriver = new AltUnityDriver();
    private string SceneName = "Main";

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver.LoadScene(SceneName);
    }

    [SetUp]
    public void BeforeEach()
    {
        altUnityDriver.LoadScene(SceneName);
    }

    [Test]
    public void TestMoveCamera()
    {
        float startX = altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().x;
        float startY = altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().y;
        altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 5F);
        altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 5F);
        Assert.GreaterOrEqual(altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().x, startX);
        Assert.GreaterOrEqual(altUnityDriver.FindObject(By.TAG, "MainCamera").getWorldPosition().y, startY);
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }
}