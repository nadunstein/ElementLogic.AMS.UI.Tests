using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inventory.GeneralInventory.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASGINVP01",
                ProductName = "AutostoreGeneralInventoryProduct01",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASGINVP01",
                ProductName = "AutostoreGeneralInventoryProduct01",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };
    }
}
