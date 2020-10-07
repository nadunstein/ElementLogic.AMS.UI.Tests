using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SecurePicking.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SecurePicking
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_SecurePicking")]
        public void BeforeScenario()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(FirstScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
