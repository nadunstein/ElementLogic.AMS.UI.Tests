using ElementLogic.AMS.UI.Tests.Features.AdminModule.Inventory.Overview.TestData;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Inventory.Overview
{
    [Binding]
    public class FeatureHooks
    {
        [BeforeScenario("Admin_InventoryOrderList_MaxLocationInTaskgroup_Scenario01")]
        public void BeforeScenario01()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductToBeCreated);
        }

        [BeforeScenario("Admin_InventoryOrderList_MaxLocationInTaskgroup_Scenario02")]
        public void BeforeScenario02()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("Inventory.MaxLocationsInTaskgroup", "2");
            ProductData.Instance.PrepareProductData(SecondScenarioTestData.ProductToBeCreated);
        }

        [AfterScenario("Admin_InventoryOrderList_MaxLocationInTaskgroup_Scenario02", Order = 2)]
        public void AfterScenario()
        {
            SetUpParameters.Instance.ChangeTheParameterValue("Inventory.MaxLocationsInTaskgroup", "10");
        }
    }
}
