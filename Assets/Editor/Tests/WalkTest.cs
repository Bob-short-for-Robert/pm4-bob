using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

[TestFixture]
public class WalkTest : MonoBehaviour
{
    private AltUnityDriver altUnityDriver = new AltUnityDriver();

    private AltUnityObject player;

    private string SceneName = "WalkTestScene";

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

    [Test]
    public void TestWalkLeft()
    {
        float start = altUnityDriver.FindObject(By.NAME, "Player").x;
        altUnityDriver.PressKey(AltUnityKeyCode.A, 1F, 0.2F);
        Assert.Less(altUnityDriver.FindObject(By.NAME, "Player").x, start);
        altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 0.2F);
    }

    [Test]
    public void TestWalkRight()
    {
        float start = altUnityDriver.FindObject(By.NAME, "Player").x;

        altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 0.2F, true);
        Assert.Greater(altUnityDriver.FindObject(By.NAME, "Player").x, start);

        //return to default position
        altUnityDriver.PressKey(AltUnityKeyCode.A, 1F, 0.2F, true);
    }

    [Test]
    public void TestWalkUp()
    {
        float start = altUnityDriver.FindObject(By.NAME, "Player").y;
        altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 0.2F, true);
        Assert.Greater(altUnityDriver.FindObject(By.NAME, "Player").y, start);

        //return to default position
        altUnityDriver.PressKey(AltUnityKeyCode.S, 1F, 0.2F, true);
    }

    [Test]
    public void TestWalkDown()
    {
        var start = altUnityDriver.FindObject(By.NAME, "Player").y;
        altUnityDriver.PressKey(AltUnityKeyCode.S, 1F, 0.2F, true);
        Assert.Less(altUnityDriver.FindObject(By.NAME, "Player").y, start);

        //return to default position
        altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 0.2F, true);
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }
}