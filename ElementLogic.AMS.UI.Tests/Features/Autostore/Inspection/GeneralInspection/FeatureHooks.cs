using ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.GeneralInspection.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.GeneralInspection
{
    [Binding]
    public class FeatureHooks
    {
        [BeforeScenario("AS_Inspection_GeneralInspection")]
        public void BeforeScenario()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductToBeCreated);
        }
    }
}
