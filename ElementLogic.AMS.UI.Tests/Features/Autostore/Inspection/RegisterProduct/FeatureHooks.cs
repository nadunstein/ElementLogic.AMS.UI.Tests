using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.RegisterProduct
{
    [Binding]
    public class FeatureHooks
    {
        [BeforeScenario("AS_Inspection_RegisterProduct")]
        public void BeforeScenario()
        {
            ProductData.Instance.PrepareProductData(TestData.FirstScenarioTestData.ProductToBeCreated);
        }
    }
}
