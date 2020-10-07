using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickDeviation.TestData
{
    public class SecondScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASPDP02",
                ProductName = "ASPickDeviationProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASPDP02",
                ProductName = "ASPickDeviationProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASPDP02",
                ProductName = "ASPickDeviationProduct02",
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
                SpeditorId = "75",
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPDP02",
                ProductName = "ASPickDeviationProduct02",
                Quantity = 40
            }
        };
    }
}
