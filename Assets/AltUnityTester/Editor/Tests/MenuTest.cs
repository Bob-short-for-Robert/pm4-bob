using Altom.AltUnityDriver;
using NUnit.Framework;

namespace AltUnityTester.Editor.Tests
{
    public class MenuTest
    {
        public AltUnityDriver altUnityDriver;
        //Before any test it connects with the socket
        [OneTimeSetUp]
        public void SetUp()
        {
            altUnityDriver = new AltUnityDriver();
        }

        //At the end of the test closes the connection with the socket
        [OneTimeTearDown]
        public void TearDown()
        {
            altUnityDriver.Stop();
        }
        
        [Test]
        public void TestSettings()
        {
            altUnityDriver.LoadScene("Menu");
            // check initial state
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
            
            //switch to options menu and check if it is set as active
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "SettingsButton").getScreenPosition());
            Assert.True(altUnityDriver.FindObject(By.NAME, "SettingsMenu").enabled);
            
            // return to main menu
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "BackButton").getScreenPosition());
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
        }

        [Test]
        public void TestStatistics()
        {
            altUnityDriver.LoadScene("Menu");
            // check initial state
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
            
            //switch to options menu and check if it is set as active
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "StatisticsButton").getScreenPosition());
            Assert.True(altUnityDriver.FindObject(By.NAME, "StatisticsMenu").enabled);
            
            // return to main menu
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "BackButton").getScreenPosition());
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
        }

        [Test]
        public void TestControls()
        {
            altUnityDriver.LoadScene("Menu");
            // check initial state
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
            
            //switch to options menu and check if it is set as active
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "ControlsButton").getScreenPosition());
            Assert.True(altUnityDriver.FindObject(By.NAME, "ControlsMenu").enabled);
            
            // return to main menu
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "BackButton").getScreenPosition());
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
        }

        [Test]
        public void TestStart()
        {
            altUnityDriver.LoadScene("Menu");
            // check initial state
            Assert.True(altUnityDriver.FindObject(By.NAME, "MainMenu").enabled);
            
            // press new game and check if the scene has changed
            altUnityDriver.Click(altUnityDriver.FindObject(By.NAME, "StartButton").getScreenPosition());
            Assert.True(altUnityDriver.GetCurrentScene().Equals("Main"));
        }

    }
}