using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.Search.TestData
{
    public class ThirdScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASRP03",
                ProductName = "ASRefillProduct03",
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
                ExtProductId = "ASRP03",
                ProductName = "ASRefillProduct03",
                Quantity = 1,
                VendorProductId = "VPID123",
                Returned = true
            }
        };
    }
}
