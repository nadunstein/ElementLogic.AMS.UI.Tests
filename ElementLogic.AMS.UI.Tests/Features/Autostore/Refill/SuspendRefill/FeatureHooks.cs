using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.SuspendRefill
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Refill_SuspendTaskgroup")]
        public void RefillSuspendTaskgroupBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 10";
            ProductData.Instance.PrepareProductData(TestData.FirstScenarioTestData.ProductsToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(
                TestData.FirstScenarioTestData.GoodsReceivalOrderLines, _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
