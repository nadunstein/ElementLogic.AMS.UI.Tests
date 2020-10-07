using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;
using FirstScenarioTestData = ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData.FirstScenarioTestData;
using SecondScenarioTestData = ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData.SecondScenarioTestData;
using ThirdScenarioTestData = ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData.ThirdScenarioTestData;
using FifthScenarioTestData = ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData.FifthScenarioTestData;
using FourthScenarioTestData = ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData.FourthScenarioTestData;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("Admin_Refill_VerifyByProductId")]
        public void RefillVerifyByProductIdBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 01";
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FirstScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("Admin_Refill_VerifyByProducerProductId")]
        public void RefillVerifyByProducerProductIdBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 02";
            ProductData.Instance.PrepareProductData(SecondScenarioTestData.ProductsToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(SecondScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("Admin_Refill_VerifyByVendorProductId")]
        public void RefillVerifyByVendorProductIdBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 03";
            ProductData.Instance.PrepareProductData(ThirdScenarioTestData.ProductsToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(ThirdScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("Admin_Refill_VerifyByEANId")]
        public void RefillVerifyByEanIdBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 04";
            ProductData.Instance.PrepareProductData(FourthScenarioTestData.ProductsToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FourthScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("Admin_Refill_VerifyByPurchaseId")]
        public void RefillVerifyByPurchaseIdBeforeScenario()
        {
            _scenarioContext["RefillTrolley"] = "Refill Trolley 05";
            ProductData.Instance.PrepareProductData(FifthScenarioTestData.ProductsToBeCreated);
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FifthScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
