using System.Linq;
using BoDi;
using ElementLogic.AMS.UI.Tests.Integration;
using OpenQA.Selenium;
using SeleniumEssential;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private static IWebDriver _driver;
        private static IWebDriver _previousDriver;
        private static ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;

        public WebDriverHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 0)]
        public void StartBrowser()
        {
            var browserMode =
                bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", 
                    "BrowserSettings:ChromeBrowser:HeadlessMode"));
            _driver = WebDriverHelper.InitializeChromeDriver("Drivers/ChromeDriver", browserMode);
            _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario(Order = 6)]
        public void CloseBrowser()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("OpenBrowser_Browser01"))
            {
                _previousDriver = _driver;
                return;
            }

            if (_scenarioContext.ScenarioInfo.Tags.Contains("OpenBrowser_Browser02"))
            {
                WebDriverHelper.QuitDriver(_previousDriver);
            }

            WebDriverHelper.QuitDriver();
        }

        [AfterTestRun]
        public static void KillChromeDriverProcess()
        {
            WebDriverHelper.KillProcess("ChromeDriver");
        }
    }
}
