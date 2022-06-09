using System.Collections;
using Altom.AltUnityDriver;
using MapTools;
using NUnit.Framework;
using UnityEngine;

public class AutoShooterTest : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private readonly AltUnityDriver _altUnityDriver = new AltUnityDriver();

    private const string SCENE_NAME = "AutoShooterTestScene";

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
    public void TestShooting()
    {
        SpawnObject.Spawn(enemy, Vector3.zero);
        _altUnityDriver.WaitForObject(By.TAG, "Enemy");
        Assert.True(_altUnityDriver.FindObjects(By.TAG, "Enemy").Count == 1);
        HelperClass.WaitForSeconds(3);
        try
        {
            _altUnityDriver.FindObject(By.NAME, "Enemy");
            Assert.IsTrue(false);
        }
        catch
        {
            // ignored
        }
    }
}
