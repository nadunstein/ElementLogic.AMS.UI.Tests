using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickDeviation.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickDeviation
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_PickDeviation_LastMissionDeviation")]
        public void BeforeScenarioOne()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(FirstScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Pick_PickDeviation_LastMissionDeviationResultingEmptyLocation")]
        public void BeforeScenarioTwo()
        {
            ProductData.Instance.PrepareProductData(SecondScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(SecondScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
