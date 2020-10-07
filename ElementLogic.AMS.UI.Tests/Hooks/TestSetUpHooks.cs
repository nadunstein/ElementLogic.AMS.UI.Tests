using System.Linq;
using ElementLogic.AMS.UI.Tests.Configuration;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Integration;
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
            var databaseName = ConfigFileReader.Instance.ConfigurationKeyValue("DatabaseSettings:DatabaseName");
            Database.Instance.DeleteDatabase(databaseName);

            if (!bool.Parse(ConfigFileReader.Instance.ConfigurationKeyValue("DatabaseSettings:UseEmptyDatabase")))
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
            if (bool.Parse(ConfigFileReader.Instance.ConfigurationKeyValue("DatabaseSettings:UseEmptyDatabase")))
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

            if (!bool.Parse(ConfigFileReader.Instance.ConfigurationKeyValue("DatabaseSettings:UseEmptyDatabase"))
                && _scenarioContext.ScenarioInfo.Tags.Contains("WarehouseImplementationTest"))
            {
                Assert.Ignore("Ignored the execution of warehouse preTest-data creation tests");
            }
        }

        [AfterScenario("Pick", Order = 3)]
        public void FinishUnfinishedPickOrders()
        {
            FlushPickOrders.Instance.FinishUnfinishedPickOrders();
        }

        [AfterScenario(Order = 5)]
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
