using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

public class ShooterTest : MonoBehaviour
{
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

    private const string SCENE_NAME = "ShooterTestScene";

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
    public void TestMoveCrosshair()
    {
        float crosshairX = _altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().x;
        float crosshairY = _altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().y;
        _altUnityDriver.MoveMouse(new AltUnityVector2(100, 100), 0.5F, true);

        Assert.AreNotEqual(crosshairX, _altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().x);
        Assert.AreNotEqual(crosshairY, _altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().y);
    }

    [Test]
    public void TestShootEnemy()
    {
        Assert.NotNull(_altUnityDriver.FindObject(By.NAME, "Enemy"));
        _altUnityDriver.Click(new AltUnityVector2(0, 1), 10, 0.3F, true);
        try
        {
            _altUnityDriver.FindObject(By.NAME, "Enemy");
            Assert.IsTrue(false);
        }
        catch (Altom.AltUnityDriver.NotFoundException e)
        {
            Assert.Equals(7, _altUnityDriver.FindObjects(By.TAG, "Projectile").Count);
        }
    }

    [Test]
    public void TestShootWall()
    {
        var wall = _altUnityDriver.FindObject(By.TAG, "Wall");
        Assert.NotNull(wall);
        _altUnityDriver.Click(new AltUnityVector2(wall.x, wall.y), 10, 0.3F, true);
        Assert.Equals(2, _altUnityDriver.FindObjects(By.TAG, "Projectile").Count);
    }


    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        _altUnityDriver.Stop();
    }
}
