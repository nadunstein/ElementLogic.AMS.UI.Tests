using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.MaxQuantityPopup.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.MaxQuantityPopup
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_MaxQuantityPopup")]
        public void BeforeScenario()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            
            SetUpParameters.Instance.ChangeTheParameterValue("SystemQuantityMaxInputValueThreshold",
                "10000");

            PickData.Instance.PreparePickTestData(FirstScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
