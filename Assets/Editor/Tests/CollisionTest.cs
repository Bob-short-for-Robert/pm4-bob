using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

[TestFixture]
public class CollisionTest : MonoBehaviour
{
    private AltUnityDriver altUnityDriver = new AltUnityDriver();

    private AltUnityObject player;

    private string SceneName = "CollisionTestScene";

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver.LoadScene(SceneName);
        player = altUnityDriver.FindObject(By.NAME, "Player");
    }

    [SetUp]
    public void BeforeEach()
    {
        altUnityDriver.LoadScene(SceneName);
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void TestCollisionLeft()
    {
        float start = altUnityDriver.FindObject(By.NAME, "WallLeft").x;
        altUnityDriver.PressKey(AltUnityKeyCode.A, 1F, 2F, true);
        Assert.GreaterOrEqual(altUnityDriver.FindObject(By.NAME, "Player").x, start);
    }

    [Test]
    public void TestCollisionRight()
    {
        float start = altUnityDriver.FindObject(By.NAME, "WallRight").x;
        altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 2F, true);
        Assert.LessOrEqual(altUnityDriver.FindObject(By.NAME, "Player").x, start);
    }

    [Test]
    public void TestCollisionUp()
    {
        float start = altUnityDriver.FindObject(By.NAME, "WallUp").y;
        altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 2F, true);
        Assert.LessOrEqual(altUnityDriver.FindObject(By.NAME, "Player").y, start);
    }

    [Test]
    public void TestCollisionDown()
    {
        float start = altUnityDriver.FindObject(By.NAME, "WallDown").y;
        altUnityDriver.PressKey(AltUnityKeyCode.S, 1F, 2F, true);
        Assert.GreaterOrEqual(altUnityDriver.FindObject(By.NAME, "Player").y, start);
    }
}