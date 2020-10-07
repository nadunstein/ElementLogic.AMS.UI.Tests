using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.TwoStepOnLastMission.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.TwoStepOnLastMission
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_TwoStepsOnLastMission")]
        public void BeforeScenario()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.UseTwoStepOnLastMission",
                "1");

            PickData.Instance.PreparePickTestData(FirstScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [AfterScenario("AS_Pick_TwoStepsOnLastMission", Order = 2)]
        public void AfterScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.UseTwoStepOnLastMission",
                "0");
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
