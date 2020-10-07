using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.TrolleyTakeOver.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASRP14",
                ProductName = "ASRefillProduct14",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASRP15",
                ProductName = "ASRefillProduct15",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };

        public static readonly List<GoodsReceivalLine> GoodsReceivalOrderLines = new List<GoodsReceivalLine>
        {
            new GoodsReceivalLine
            {
                Action = "A",
                PurchaseOrderLineId = "1",
                ExtProductId = "ASRP14",
                ProductName = "ASRefillProduct14",
                Quantity = 1,
                ProductScancodes = "RefillProd14",
                Returned = true
            }
        };
    }
}
