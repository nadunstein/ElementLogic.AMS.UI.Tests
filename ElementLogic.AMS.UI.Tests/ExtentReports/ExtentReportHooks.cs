using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using ElementLogic.AMS.UI.Tests.Integration;
using OpenQA.Selenium;
using SeleniumEssential;
using TechTalk.SpecFlow;
using Feature = AventStack.ExtentReports.Gherkin.Model.Feature;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

namespace ElementLogic.AMS.UI.Tests.ExtentReports
{
    [Binding]
    public class ExtentReportHooks
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReport _extent;
        private string _stepType;
        private string _stepName;

        public ExtentReportHooks(ScenarioContext scenarioContext, FeatureContext featureContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            _driver = driver;
        }

        [BeforeTestRun(Order = 3)]
        public static void InitializeReport()
        {
            var extentReportPath = Directory.GetParent(WebDriverHelper.Instance.GetProjectPath()).ToString();
            var reportHtmlName = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                "ExtentReportSettings:reportHtmlName");
            var htmlReporter =
                new ExtentHtmlReporter(Path.Combine(extentReportPath, reportHtmlName));
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = JsonFileReader.Instance.GetJsonKeyValue(
                "Configuration/Environment.json",
                "ExtentReportSettings:DocumentTitle");
            htmlReporter.Config.ReportName = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                "ExtentReportSettings:ReportName");

            _extent = new ExtentReport();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario()
        {
            if (_featureName is null)
            {
                _featureName = _extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            }

            _scenario = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            _stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            _stepName = ScenarioStepContext.Current.StepInfo.Text;
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            if (_scenarioContext.TestError == null)
            {
                switch (_stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>("<b>" + _stepType + "</b>" + " " + _stepName);
                        break;
                    case "When":
                        _scenario.CreateNode<When>("<b>" + _stepType + "</b>" + " " + _stepName);
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>("<b>" + _stepType + "</b>" + " " + _stepName);
                        break;
                }
            }

            else if (_scenarioContext.TestError != null)
            {
                var ss = ((ITakesScreenshot)_driver).GetScreenshot();
                var screenshots = ss.AsBase64EncodedString;

                switch (_stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>("<b>" + _stepType + "</b>" + " " + _stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                MediaEntityBuilder
                                    .CreateScreenCaptureFromBase64String(screenshots)
                                    .Build());
                        break;
                    case "When":
                        _scenario.CreateNode<When>("<b>" + _stepType + "</b>" + " " + _stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                MediaEntityBuilder
                                    .CreateScreenCaptureFromBase64String(screenshots)
                                    .Build());
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>("<b>" + _stepType + "</b>" + " " + _stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                MediaEntityBuilder
                                    .CreateScreenCaptureFromBase64String(screenshots)
                                    .Build());
                        break;
                }
            }
        }

        [AfterScenario(Order = 1)]
        public void AfterScenario()
        {
            var pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus",
                BindingFlags.Instance | BindingFlags.Public);
            if (pInfo == null)
            {
                return;
            }

            var getter = pInfo.GetGetMethod(nonPublic: true);
            var testResult = getter.Invoke(_scenarioContext, null);

            if (!testResult.ToString().Equals("UndefinedStep") && !testResult.ToString().Equals("BindingError"))
            {
                return;
            }

            switch (_stepType)
            {
                case "Given":
                    _scenario.CreateNode<Given>("<b>" + _stepType + "</b>" + " " + _stepName)
                        .Skip("Step Definition Pending");
                    break;
                case "When":
                    _scenario.CreateNode<When>("<b>" + _stepType + "</b>" + " " + _stepName)
                        .Skip("Step Definition Pending");
                    break;
                case "Then":
                    _scenario.CreateNode<Then>("<b>" + _stepType + "</b>" + " " + _stepName)
                        .Skip("Step Definition Pending");
                    break;
                case null:
                    _scenario.CreateNode<Given>("The First step of the scenario is Undefined")
                        .Skip("");
                    break;
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _featureName = null;
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }
    }
}
