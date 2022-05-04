using System;
using NUnit.Framework;
using Altom.AltUnityDriver;
using UnityEngine;

public class FirstTest
{
    private bool first;
    private AltUnityVector2 startPos;
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
        //altUnityDriver.LoadScene("Main");
        var player = altUnityDriver.FindObject(By.TAG, "Player");
        first = true;
        startPos = player.getScreenPosition();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [SetUp]
    public void Reset()
    {
        first = true;
    }
    
    [Test]
    public void TestA()
    {
        altUnityDriver.PressKey(AltUnityKeyCode.A);

        if (!Input.anyKey && first)
        {
            Assert.IsTrue(startPos.x > altUnityDriver.FindObject(By.NAME, "Player").x);
            first = false;
        }
    }
    
    [Test]
    public void TestD()
    {
        altUnityDriver.PressKey(AltUnityKeyCode.D);

        if (!Input.anyKey && first)
        {
            Assert.IsTrue(startPos.x < altUnityDriver.FindObject(By.NAME, "Player").x);
            first = false;
        }
    }
    
    [Test]
    public void TestW()
    {
        altUnityDriver.PressKey(AltUnityKeyCode.W);

        if (!Input.anyKey && first)
        {
            Assert.IsTrue(startPos.y < altUnityDriver.FindObject(By.NAME, "Player").y);
            first = false;
        }
    }
    
    [Test]
    public void TestS()
    {
        altUnityDriver.PressKey(AltUnityKeyCode.S);

        if (!Input.anyKey && first)
        {
            Assert.IsTrue(startPos.y > altUnityDriver.FindObject(By.NAME, "Player").y);
            first = false;
        }
    }
}