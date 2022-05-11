using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

[TestFixture]
public class CollisionTest : MonoBehaviour
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();
    
    private const string SCENE_NAME = "CollisionTestScene";

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
    public void TestCollisionLeft()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "WallLeft").x;
        _altUnityDriver.PressKey(AltUnityKeyCode.A, 1F, 2F, true);
        Assert.GreaterOrEqual(_altUnityDriver.FindObject(By.NAME, "Player").x, start);
    }

    [Test]
    public void TestCollisionRight()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "WallRight").x;
        _altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 2F, true);
        Assert.LessOrEqual(_altUnityDriver.FindObject(By.NAME, "Player").x, start);
    }

    [Test]
    public void TestCollisionUp()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "WallUp").y;
        _altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 2F, true);
        Assert.LessOrEqual(_altUnityDriver.FindObject(By.NAME, "Player").y, start);
    }

    [Test]
    public void TestCollisionDown()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "WallDown").y;
        _altUnityDriver.PressKey(AltUnityKeyCode.S, 1F, 2F, true);
        Assert.GreaterOrEqual(_altUnityDriver.FindObject(By.NAME, "Player").y, start);
    }
}
