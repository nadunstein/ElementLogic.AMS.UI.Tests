using ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.GeneralPutaway.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.GeneralPutaway
{
    [Binding]
    public class FeatureHooks
    {
        private readonly ScenarioContext _scenarioContext;

        [BeforeScenario("AS_Putaway_GeneralPutaway")]
        public void GeneralPutawayBeforeScenario()
        {
            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(FirstScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [BeforeScenario("AS_Putaway_VerifyProductImage")]
        public void VerifyProductImageBeforeScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("ProductImageServiceEndpoint",
                "https://testdatabasebackups.blob.core.windows.net/uitests/{0}");
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Putaway.Scanning.ValidateProduct",
                "1");

            GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(SecondScenarioTestData.GoodsReceivalOrderLines,
                _scenarioContext);
        }

        [AfterScenario("AS_Putaway_VerifyProductImage", Order = 2)]
        public void AfterScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("AutoStore.Putaway.Scanning.ValidateProduct",
                "0");
        }

        private FeatureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
