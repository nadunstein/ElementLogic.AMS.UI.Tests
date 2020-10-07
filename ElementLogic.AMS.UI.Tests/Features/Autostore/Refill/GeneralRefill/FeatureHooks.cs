using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;
using FirstScenarioTestData = ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.GeneralRefill.TestData.FirstScenarioTestData;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.GeneralRefill
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Refill_GeneralRefill")]
        public void BeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 07";
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FirstScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
