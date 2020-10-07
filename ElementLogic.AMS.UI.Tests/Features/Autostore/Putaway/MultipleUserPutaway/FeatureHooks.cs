using ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultipleUserPutaway.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultipleUserPutaway
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Putaway_MultipleUsers")]
        public void CreateGoodsReceivalOrder()
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
