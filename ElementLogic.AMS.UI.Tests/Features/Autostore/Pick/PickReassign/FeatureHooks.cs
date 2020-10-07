using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickReassign.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickReassign
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_Reassign")]
        public void BeforeScenario01()
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
