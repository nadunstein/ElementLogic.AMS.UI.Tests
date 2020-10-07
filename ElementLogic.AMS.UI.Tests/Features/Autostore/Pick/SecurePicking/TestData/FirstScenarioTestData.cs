using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SecurePicking.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASPSPP01",
                ProductName = "ASPickSecurePickingProduct01",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASPSPP02",
                ProductName = "ASPickSecurePickingProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };

        public static readonly List<PicklistLine> PickOrderLines = new List<PicklistLine>
        {
            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 1,
                SpeditorId = "73",
                OrderTypeId = "430",
                OrderTypeText = "Internet",
                ExtProductId = "ASPSPP01",
                ProductName = "ASPickSecurePickingProduct01",
                Quantity = 2
            },

            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 2,
                SpeditorId = "73",
                OrderTypeId = "430",
                OrderTypeText = "Internet",
                ExtProductId = "ASPSPP02",
                ProductName = "ASPickSecurePickingProduct02",
                Quantity = 2
            }
        };
    }
}
