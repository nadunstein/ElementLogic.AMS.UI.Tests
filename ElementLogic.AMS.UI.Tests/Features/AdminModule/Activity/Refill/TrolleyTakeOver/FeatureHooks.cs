using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.TrolleyTakeOver
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("Admin_Refill_TakeOverTrolley")]
        public void RefillVerifyByProductIdBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 06";
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
