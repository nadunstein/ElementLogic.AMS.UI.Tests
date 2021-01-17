using System.IO;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Integration;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using NUnit.Framework;
using SeleniumEssential;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Hooks
{
    [Binding]
    public class TestSetUpHooks
    {
        private static bool _testRunTerminated;
        private static bool _recordScreen = true;
        private static ScenarioContext _scenarioContext;

        private static readonly bool IsUsingEmptyDatabase = bool.Parse(JsonFileReader.Instance
            .GetJsonKeyValue("Configuration/Environment.json", "DatabaseSettings:UseEmptyDatabase"));

        private static readonly bool IsBrowserHeadlessMode =
            bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                "BrowserSettings:ChromeBrowser:HeadlessMode"));

        [BeforeTestRun(Order = 0)]
        public static void CreateDatabase()
        {
            var databaseName = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "DatabaseSettings:DatabaseName");
            Database.Instance
                .DeleteDatabase(databaseName);

            if (!IsUsingEmptyDatabase)
            {
                Database.Instance
                    .RestoreDatabase(databaseName);
                return;
            }

            Database.Instance
                .CreateDatabase(databaseName);
        }

        [BeforeTestRun(Order = 1)]
        public static void UpdateMegaparamTable()
        {
            var context = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "Application:context");
            Parameter.Instance
                .UpdateContext(context);
            var autostoreUrl = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "Application:AutostoreUrl");
            Parameter.Instance
                .UpdateParameterValue("AutostoreUrl", autostoreUrl);
        }

        [BeforeTestRun(Order = 2)]
        public static void RestartInternetInformationServices()
        {
            WindowsServices.Instance
                .DoIisReset();
        }

        [BeforeTestRun(Order = 3)]
        public static void RestartServices()
        {
            WindowsServices.Instance
                .RestartAutostoreEmulatorService();
        }

        [BeforeTestRun(Order = 6)]
        public static void SynchronizeAsBins()
        {
            if (IsUsingEmptyDatabase)
            {
                return;
            }

            SynchronizeAutostoreBins.Instance
                .DoAutostoreBinSync();
        }

        [BeforeTestRun(Order = 7)]
        public static void DeleteOldVideos()
        {
            var pathToVideoDirectory = Path
                .Combine(FileHelper.Instance.GetProjectBinPath(), "ScreenCaptureVideos\\");
            FileHelper.Instance.DeleteFiles(pathToVideoDirectory);
        }

        [BeforeScenario(Order = 1)]
        public void IgnoreTests()
        {
            if (_testRunTerminated.Equals(true))
            {
                Assert.Ignore("Failure in warehouse Test data Creation tests");
            }

            if (!IsUsingEmptyDatabase && _scenarioContext.ScenarioInfo.Tags.Contains("WarehouseImplementationTest"))
            {
                _recordScreen = false;
                Assert.Ignore("Ignored the execution of warehouse preTest-data creation tests");
            }
        }

        [BeforeScenario(Order = 3)]
        public void CreateScenarioTestData()
        {
            TestDataFactory.Instance
                .PrepareTestDataSet(_scenarioContext);
        }

        [BeforeScenario(Order = 4)]
        public void StartVideoRecorder()
        {
            if (_recordScreen && !IsBrowserHeadlessMode)
            {
                ScreenRecorder.Instance.StartScreenRecording(_scenarioContext);
            }
        }

        [AfterScenario(Order = 2)]
        public void StopVideoRecorder()
        {
            if (_recordScreen && !IsBrowserHeadlessMode)
            {
                ScreenRecorder.Instance.StopScreenRecording(_scenarioContext);
                _recordScreen = false;
            }
        }

        [AfterScenario(Order = 3)]
        public void ResetSystemParametersAfterTestRun()
        {
            if (!_scenarioContext.ScenarioInfo.Tags.Contains("WarehouseImplementationTest"))
            {
                var parametersToBeChanged = SetUpParameters.Instance
                    .GetParametersToBeReset();
                foreach (var parameterToBeChanged in parametersToBeChanged)
                {
                    SetUpParameters.Instance
                        .ChangeTheParameterValue(parameterToBeChanged.ParameterName,
                        parameterToBeChanged.ParameterValue);
                }
            }

            SetUpParameters.Instance.FlushParametersToBeReset();
        }

        [AfterScenario("Pick", Order = 4)]
        public void FinishUnfinishedPickOrders()
        {
            FlushPickOrders.Instance
                .FinishUnfinishedPickOrders();
        }

        [AfterScenario("Inventory", Order = 5)]
        public void FinishUnfinishedInventoryOrders()
        {
            FlushInventoryOrders.Instance
                .FinishUnfinishedInventoryOrders();
        }

        [AfterScenario(Order = 7)]
        public void TerminateTestRun()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("WarehouseImplementationTest")
                && _scenarioContext.TestError != null)
            {
                _testRunTerminated = true;
            }
        }

        private TestSetUpHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
