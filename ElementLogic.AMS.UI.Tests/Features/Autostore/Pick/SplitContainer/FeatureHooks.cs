using ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SplitContainer.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SplitContainer
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Pick_SplitContainer")]
        public void BeforeScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.UseTwoStepOnLastMission", "1");
            SetUpParameters.Instance.ChangeTheParameterValue("Picking.AutoStore.CloseCurrentContainer", "1");
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer", "1");
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductsToBeCreated);
            PickData.Instance.PreparePickTestData(FirstScenarioTestData.PickOrderLines,
                _scenarioContext);
        }

        [AfterScenario("AS_Pick_SplitContainer", Order = 2)]
        public void AfterScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.UseTwoStepOnLastMission", "0");
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Picking.Scanning.ValidateContainer", "0");
        }
        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
