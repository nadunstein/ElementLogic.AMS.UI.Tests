using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData
{
    public class FifthScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASRP04",
                ProductName = "ASRefillProduct04",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 10
            }
        };

        public static readonly List<GoodsReceivalLine> GoodsReceivalOrderLines = new List<GoodsReceivalLine>
        {
            new GoodsReceivalLine
            {
                Action = "A",
                PurchaseOrderLineId = "1",
                ExtProductId = "ASRP04",
                ProductName = "ASRefillProduct04",
                Quantity = 1,
                Returned = true
            }
        };
    }
}
