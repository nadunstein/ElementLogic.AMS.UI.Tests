using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;
using FirstScenarioTestData = ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.RefillDeviation.TestData.FirstScenarioTestData;
using SecondScenarioTestData = ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.RefillDeviation.TestData.SecondScenarioTestData;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.RefillDeviation
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Refill_Deviation_ExistingLocations")]
        public void BeforeScenarioOne()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 08";
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FirstScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Refill_Deviation_EmptyLocations")]
        public void BeforeScenarioTwo()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 09";
            ProductData.Instance.PrepareProductData(SecondScenarioTestData.ProductToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(SecondScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
