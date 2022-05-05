using NUnit.Framework;
using Altom.AltUnityDriver;

public class DoorTest
{
    private bool _first;
    private AltUnityVector2 _startPos;
    private AltUnityDriver _altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        _altUnityDriver =new AltUnityDriver();
        _altUnityDriver.LoadScene("Main");
        var player = _altUnityDriver.FindObject(By.NAME, "Player");
        _first = true;
        _startPos = _altUnityDriver.FindObject(By.NAME, "Player").getScreenPosition();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        _altUnityDriver.Stop();
    }

    [SetUp]
    public void Reset()
    {
        _first = true;
    }
}
