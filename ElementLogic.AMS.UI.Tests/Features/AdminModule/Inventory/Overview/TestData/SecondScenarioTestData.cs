using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Inventory.Overview.TestData
{
    public class SecondScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASINVP02",
                ProductName = "AutostoreInventoryProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASINVP02",
                ProductName = "AutostoreInventoryProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASINVP02",
                ProductName = "AutostoreInventoryProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };
    }
}
