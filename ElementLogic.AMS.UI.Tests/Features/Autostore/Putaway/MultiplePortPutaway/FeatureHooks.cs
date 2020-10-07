using ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultiplePortPutaway.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultiplePortPutaway
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AutostorePutawayMultiPort")]
        public void GeneralPutawayBeforeScenario()
        {
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FirstScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
