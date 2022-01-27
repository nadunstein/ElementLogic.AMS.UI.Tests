using System.IO;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Integration;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.TestDataFactory;
using SeleniumEssential;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Hooks
{
    [Binding]
    public class TestSetUpHooks
    {
        private  bool _recordScreen = true;
        private  bool _failureInTestDataCreation = true;
        private static ScenarioContext _scenarioContext;

        private static readonly bool IsUsingEmptyDatabase = bool.Parse(JsonFileReader.Instance
            .GetJsonKeyValue("Configuration/Environment.json", "DatabaseSettings:UseEmptyDatabase"));

        private static readonly bool IsBrowserHeadlessMode =
            bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                "BrowserSettings:ChromeBrowser:HeadlessMode"));

        private static readonly bool IsTestRunInTeamCity = bool.Parse(JsonFileReader.Instance
            .GetJsonKeyValue("Configuration/Environment.json", "TestRun:TeamCity"));

        [BeforeTestRun(Order = 0)]
        public static void RestoreDatabase()
        {
            if (IsTestRunInTeamCity)
            {
                return;
            }

            var databaseName = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "DatabaseSettings:DatabaseName");
            Database.Instance
                .DeleteDatabase(databaseName);
            Database.Instance
                .RestoreDatabase(databaseName);
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
            if (IsTestRunInTeamCity)
            {
                return;
            }

            WindowsServices.Instance
                .DoIisReset();
        }

        [BeforeTestRun(Order = 3)]
        public static void RestartAutostoreEmulatorService()
        {
            if (IsTestRunInTeamCity)
            {
                return;
            }

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
                .Combine(FileHelper.GetProjectBinPath(), "ScreenCaptureVideos\\");
            FileHelper.DeleteFiles(pathToVideoDirectory);
        }

        [BeforeScenario(Order = 2)]
        public void CreateScenarioTestData()
        {
            TestDataFactory.Instance
                .PrepareTestDataSet(_scenarioContext);
            _failureInTestDataCreation = false;
        }

        [BeforeScenario(Order = 3)]
        public void StartVideoRecorder()
        {
            if (_recordScreen && !IsBrowserHeadlessMode && !_failureInTestDataCreation)
            {
                ScreenRecorder.Instance.StartScreenRecording(_scenarioContext);
            }
        }

        [AfterScenario(Order = 2)]
        public void StopVideoRecorder()
        {
            if (_recordScreen && !IsBrowserHeadlessMode && !_failureInTestDataCreation)
            {
                ScreenRecorder.Instance.StopScreenRecording(_scenarioContext);
            }
        }

        [AfterScenario(Order = 3)]
        public void ResetSystemParametersAfterTestRun()
        {
            var parametersToBeChanged = SetUpParameters.Instance
                .GetParametersToBeReset();
            foreach (var parameterToBeChanged in parametersToBeChanged)
            {
                SetUpParameters.Instance
                    .ChangeTheParameterValue(parameterToBeChanged.ParameterName,
                        parameterToBeChanged.ParameterValue);
            }

            SetUpParameters.Instance.FlushParametersToBeResetList();
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

        private TestSetUpHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
