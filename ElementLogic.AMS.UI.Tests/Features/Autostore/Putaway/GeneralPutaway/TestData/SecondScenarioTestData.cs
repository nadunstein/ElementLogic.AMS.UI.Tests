using System.Collections.Generic;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.GeneralPutaway.TestData
{
    public class SecondScenarioTestData
    {
        public static readonly List<GoodsReceivalLine> GoodsReceivalOrderLines = new List<GoodsReceivalLine>
        {
            new GoodsReceivalLine
            {
                Action = "A",
                PurchaseOrderLineId = "1",
                ExtProductId = "ASVIP01",
                ProductName = "ASVerifyImageProduct01",
                Quantity = 10,
                ImageId = "Iphone_Image.jpeg",
                Returned = false
            }
        };
    }
}
