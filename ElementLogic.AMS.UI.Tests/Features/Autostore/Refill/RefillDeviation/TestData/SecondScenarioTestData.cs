using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.RefillDeviation.TestData
{
    public class SecondScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASRDP02",
                ProductName = "AutostoreRefillDeviationProduct02",
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
                ExtProductId = "ASRDP02",
                ProductName = "AutostoreRefillDeviationProduct02",
                ProductScancodes = "RefillDevProd02",
                Quantity = 40,
                Returned = false
            }
        };
    }
}
