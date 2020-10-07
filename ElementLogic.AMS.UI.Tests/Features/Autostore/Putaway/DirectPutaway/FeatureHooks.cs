using ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.DirectPutaway.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.DirectPutaway
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Putaway_DirectPutaway")]
        public void GeneralPutawayBeforeScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("Import.Transport", "Fileshare");
            SetUpParameters.Instance.ChangeTheParameterValue("SYS_ALWAYS_ASK_MAXBINQTY", "1");
            SetUpParameters.Instance.ChangeTheParameterValue("AllowAutomaticOrderCreation", "1");

            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FirstScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
