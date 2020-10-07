using System.Collections.Generic;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.DirectPutaway.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<GoodsReceivalLine> GoodsReceivalOrderLines = new List<GoodsReceivalLine>
        {
            new GoodsReceivalLine
            {
                Action = "A",
                PurchaseOrderLineId = "1",
                ExtProductId = "ASDPP01",
                ProductName = "AsDirectPutawayProduct01",
                Quantity = 10,
                Returned = false
            }
        };
    }
}
