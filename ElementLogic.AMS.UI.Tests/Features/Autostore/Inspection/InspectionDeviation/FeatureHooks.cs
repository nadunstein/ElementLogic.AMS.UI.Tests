using ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.InspectionDeviation.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.InspectionDeviation
{
    [Binding]
    public class FeatureHooks
    {
        [BeforeScenario("AS_Inspection_InspectionDeviation")]
        public void BeforeScenarioOne()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductToBeCreated);
        }

        [BeforeScenario("AS_Inspection_InspectionDeviationWithReasonCode")]
        public void BeforeScenarioTwo()
        {
            ProductData.Instance.PrepareProductData(SecondScenarioTestData.ProductToBeCreated);
        }
    }
}
