using System.Collections.Generic;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultipleUserPutaway.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<GoodsReceivalLine> GoodsReceivalOrderLines = new List<GoodsReceivalLine>
        {
            new GoodsReceivalLine
            {
                Action = "A",
                PurchaseOrderLineId = "1",
                ExtProductId = "ASPMUP01",
                ProductName = "AutostorePutawayMultipleUserProduct01",
                Quantity = 50,
                Returned = false
            }
        };
    }
}
