using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

[TestFixture]
public class WalkTest : MonoBehaviour
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

    private const string SCENE_NAME = "WalkTestScene";

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
    public void TestWalkLeft()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "Player").x;
        _altUnityDriver.PressKey(AltUnityKeyCode.A, 1F, 0.2F);
        Assert.Less(_altUnityDriver.FindObject(By.NAME, "Player").x, start);
        _altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 0.2F);
    }

    [Test]
    public void TestWalkRight()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "Player").x;

        _altUnityDriver.PressKey(AltUnityKeyCode.D, 1F, 0.2F, true);
        Assert.Greater(_altUnityDriver.FindObject(By.NAME, "Player").x, start);

        //return to default position
        _altUnityDriver.PressKey(AltUnityKeyCode.A, 1F, 0.2F, true);
    }

    [Test]
    public void TestWalkUp()
    {
        float start = _altUnityDriver.FindObject(By.NAME, "Player").y;
        _altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 0.2F, true);
        Assert.Greater(_altUnityDriver.FindObject(By.NAME, "Player").y, start);

        //return to default position
        _altUnityDriver.PressKey(AltUnityKeyCode.S, 1F, 0.2F, true);
    }

    [Test]
    public void TestWalkDown()
    {
        var start = _altUnityDriver.FindObject(By.NAME, "Player").y;
        _altUnityDriver.PressKey(AltUnityKeyCode.S, 1F, 0.2F, true);
        Assert.Less(_altUnityDriver.FindObject(By.NAME, "Player").y, start);

        //return to default position
        _altUnityDriver.PressKey(AltUnityKeyCode.W, 1F, 0.2F, true);
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        _altUnityDriver.Stop();
    }
}
