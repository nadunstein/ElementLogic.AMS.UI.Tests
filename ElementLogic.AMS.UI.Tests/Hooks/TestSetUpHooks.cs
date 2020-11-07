using System.Linq;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Integration;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Hooks
{
    [Binding]
    public class TestSetUpHooks
    {
        private static bool _testRunTerminated;
        private static ScenarioContext _scenarioContext;

        [BeforeTestRun(Order = 0)]
        public static void CreateDatabase()
        {
            var databaseName =
                JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json",
                    "DatabaseSettings:DatabaseName");
            Database.Instance.DeleteDatabase(databaseName);

            if (!bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", 
                "DatabaseSettings:UseEmptyDatabase")))
            {
                Database.Instance.RestoreDatabase(databaseName);
                WindowsServices.Instance.DoIisReset();
                return;
            }

            Database.Instance.CreateDatabase(databaseName);
            WindowsServices.Instance.DoIisReset();
        }

        [BeforeTestRun(Order = 1)]
        public static void RestartServices()
        {
            WindowsServices.Instance.RestartAutostoreEmulatorService();
        }

        [BeforeTestRun(Order = 2)]
        public static void SynchronizeAsBins()
        {
            if (bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", 
                "DatabaseSettings:UseEmptyDatabase")))
            {
                return;
            }

            SynchronizeAutostoreBins.Instance.DoAutostoreBinSync();
        }

        [BeforeScenario(Order = 1)]
        public void IgnoreTests()
        {
            if (_testRunTerminated.Equals(true))
            {
                Assert.Ignore("Failure in warehouse Test data Creation tests");
            }

            if (!bool.Parse(JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", 
                    "DatabaseSettings:UseEmptyDatabase"))
                && _scenarioContext.ScenarioInfo.Tags.Contains("WarehouseImplementationTest"))
            {
                Assert.Ignore("Ignored the execution of warehouse preTest-data creation tests");
            }
        }

        [BeforeScenario(Order = 3)]
        public void CreateScenarioTestData()
        {
            TestDataFactory.Instance.PrepareTestDataSet(_scenarioContext);
        }
        
        [AfterScenario(Order = 2)]
        public void ResetSystemParametersAfterTestRun()
        {
            if (!_scenarioContext.ScenarioInfo.Tags.Contains("WarehouseImplementationTest"))
            {
                var parametersToBeChanged = SetUpParameters.Instance.GetParametersToBeReset();
                foreach (var parameterToBeChanged in parametersToBeChanged)
                {
                    SetUpParameters.Instance.ChangeTheParameterValue(parameterToBeChanged.ParameterName,
                        parameterToBeChanged.ParameterValue);
                }
            }

            SetUpParameters.Instance.FlushParametersToBeReset();
        }

        [AfterScenario("Pick", Order = 3)]
        public void FinishUnfinishedPickOrders()
        {
            FlushPickOrders.Instance.FinishUnfinishedPickOrders();
        }

        [AfterScenario("Inventory", Order = 4)]
        public void FinishUnfinishedInventoryOrders()
        {
            FlushInventoryOrders.Instance.FinishUnfinishedInventoryOrders();
        }

        [AfterScenario(Order = 6)]
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
