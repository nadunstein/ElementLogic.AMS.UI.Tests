using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.GeneralRefill.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASRP01",
                ProductName = "AutostoreRefillProduct01",
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
                ExtProductId = "ASRP01",
                ProductName = "AutostoreRefillProduct01",
                ProductScancodes = "RefillProd01",
                Quantity = 2,
                Returned = false
            }
        };
    }
}
