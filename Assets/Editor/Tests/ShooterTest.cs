using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

public class ShooterTest : MonoBehaviour
{
    private AltUnityDriver altUnityDriver = new AltUnityDriver();

    private AltUnityObject player;

    private string SceneName = "ShooterTestScene";

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
    public void TestMoveCrosshair()
    {
        float crosshairX = altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().x;
        float crosshairY = altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().y;
        altUnityDriver.MoveMouse(new AltUnityVector2(100, 100), 0.5F, true);
        
        Assert.AreNotEqual(crosshairX, altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().x);
        Assert.AreNotEqual(crosshairY, altUnityDriver.FindObject(By.NAME, "Crosshair").getScreenPosition().y);
    }

    [Test]
    public void TestShootEnemy()
    {
        Assert.NotNull(altUnityDriver.FindObject(By.NAME, "Enemy"));
        altUnityDriver.Click(new AltUnityVector2(0, 1), 10, 0.3F, true);
        try
        {
            altUnityDriver.FindObject(By.NAME, "Enemy");
            Assert.IsTrue(false);
        }
        catch (Altom.AltUnityDriver.NotFoundException e)
        {
            Assert.IsTrue(true);
            Assert.IsTrue(7.Equals( altUnityDriver.FindObjects(By.TAG, "Projectile").Count));
        }
    }

    [Test]
    public void TestShootWall()
    {
        var wall = altUnityDriver.FindObject(By.TAG, "Wall");
        Assert.NotNull(wall);
        altUnityDriver.Click(new AltUnityVector2(wall.x, wall.y), 10, 0.3F, true);
        Assert.IsTrue(2.Equals( altUnityDriver.FindObjects(By.TAG, "Projectile").Count));
    }

    
    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }
}