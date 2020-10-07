using System.Linq;
using BoDi;
using ElementLogic.AMS.UI.Tests.Configuration;
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
        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;
        private static string _currentFeatureName;
        private static string _previousFeatureName;
        private static bool _isPreviousBrowserOpen;
        private readonly IObjectContainer _objectContainer;

        public WebDriverHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeScenario(Order = 0)]
        public void StartBrowser()
        {
            _currentFeatureName = _featureContext.FeatureInfo.Title;
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                _previousFeatureName.Equals(_currentFeatureName))
            {
                _scenarioContext["RunTestsInline"] = true;
                _objectContainer.RegisterInstanceAs(_driver);
                return;
            }

            _scenarioContext["RunTestsInline"] = false;
            var browserMode =
                bool.Parse(ConfigFileReader.Instance.ConfigurationKeyValue("BrowserSettings:ChromeBrowser:HeadlessMode"));
            _driver = WebDriverHelper.Instance.InitializeChromeDriver("Drivers/ChromeDriver", browserMode);
            _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario(Order = 4)]
        public void CloseBrowser()
        {
            _currentFeatureName = _featureContext.FeatureInfo.Title;
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline"))
            {
                if (_isPreviousBrowserOpen && !_previousFeatureName.Equals(_currentFeatureName))
                {
                    WebDriverHelper.Instance.QuitDriver(_previousDriver);
                    _isPreviousBrowserOpen = false;
                }

                if (!_isPreviousBrowserOpen)
                {
                    _previousDriver = _driver;
                    _isPreviousBrowserOpen = true;
                }

                _previousFeatureName = _currentFeatureName;
                return;
            }

            if (_isPreviousBrowserOpen)
            {
                WebDriverHelper.Instance.QuitDriver(_previousDriver);
                _isPreviousBrowserOpen = false;
            }

            if (_scenarioContext.ScenarioInfo.Tags.Contains("OpenBrowser_Browser01"))
            {
                _previousDriver = _driver;
                return;
            }

            if (_scenarioContext.ScenarioInfo.Tags.Contains("OpenBrowser_Browser02"))
            {
                WebDriverHelper.Instance.QuitDriver(_previousDriver);
            }

            _previousFeatureName = _currentFeatureName;
            WebDriverHelper.Instance.QuitDriver();
        }

        [AfterTestRun]
        public static void KillChromeDriverProcess()
        {
            WebDriverHelper.Instance.KillProcess("ChromeDriver");
        }
    }
}
