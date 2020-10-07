using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickPlaceScanField.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASPPSFP01",
                ProductName = "ASPickPlaceScanFieldProduct01",
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
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPPSFP01",
                ProductName = "ASPickPlaceScanFieldProduct01",
                Quantity = 2,
                Scancode = "scancode01"
            }
        };
    }
}
