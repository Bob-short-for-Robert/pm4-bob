using Altom.AltUnityDriver;
using NUnit.Framework;

public class MenuTest
{
    private AltUnityDriver _altUnityDriver;

    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        _altUnityDriver = new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        _altUnityDriver.Stop();
    }

    [Test]
    public void TestSettings()
    {
        _altUnityDriver.LoadScene("Menu");
        // check initial state
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);

        //switch to options menu and check if it is set as active
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "SettingsButton").getScreenPosition());
        Assert.True(_altUnityDriver.FindObject(By.NAME, "SettingsMenu").enabled);

        // return to main menu
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "BackButton").getScreenPosition());
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
    }

    [Test]
    public void TestStatistics()
    {
        _altUnityDriver.LoadScene("Menu");
        // check initial state
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);

        //switch to options menu and check if it is set as active
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "StatisticsButton").getScreenPosition());
        Assert.True(_altUnityDriver.FindObject(By.NAME, "StatisticsMenu").enabled);

        // return to main menu
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "BackButton").getScreenPosition());
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
    }

    [Test]
    public void TestControls()
    {
        _altUnityDriver.LoadScene("Menu");
        // check initial state
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);

        //switch to options menu and check if it is set as active
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "ControlsButton").getScreenPosition());
        Assert.True(_altUnityDriver.FindObject(By.NAME, "ControlsMenu").enabled);

        // return to main menu
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "BackButton").getScreenPosition());
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
    }

    [Test]
    public void TestStart()
    {
        _altUnityDriver.LoadScene("Menu");
        // check initial state
        Assert.True(_altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);

        // press new game and check if the scene has changed
        _altUnityDriver.Click(_altUnityDriver.FindObject(By.NAME, "StartButton").getScreenPosition());
        Assert.True(_altUnityDriver.GetCurrentScene().Equals("Main"));
    }
}