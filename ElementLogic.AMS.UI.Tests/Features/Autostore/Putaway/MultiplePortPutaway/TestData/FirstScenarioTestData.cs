using System.Collections.Generic;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultiplePortPutaway.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<GoodsReceivalLine> GoodsReceivalOrderLines = new List<GoodsReceivalLine>
        {
            new GoodsReceivalLine
            {
                Action = "A",
                PurchaseOrderLineId = "1",
                ExtProductId = "PMPP01",
                ProductName = "PutawayMultiplePortProduct01",
                Quantity = 15,
                Returned = false
            }
        };
    }
}
