using ElementLogic.AMS.UI.Tests.Features.Autostore.Inventory.GeneralInventory.TestData;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inventory.GeneralInventory
{
    [Binding]
    public class FeatureHooks
    {
        [BeforeScenario("AS_Inventory_GeneralInventory")]
        public void BeforeScenario01()
        {
            ProductData.Instance.PrepareProductData(FirstScenarioTestData.ProductToBeCreated);
        }
    }
}
