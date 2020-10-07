using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickPlaceScanField.TestData
{
    public class ThirdScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASPPSFP03",
                ProductName = "ASPickPlaceScanFieldProduct03",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASPPSFP04",
                ProductName = "ASPickPlaceScanFieldProduct04",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };

        public static readonly List<PicklistLine> FirstPickOrderLines = new List<PicklistLine>
        {
            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 1,
                SpeditorId = "73",
                CustId = "EWMS-000001",
                CustName = "Rose-Marie",
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPPSFP03",
                ProductName = "ASPickPlaceScanFieldProduct03",
                Quantity = 2
            },

            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 2,
                SpeditorId = "73",
                CustId = "EWMS-000001",
                CustName = "Rose-Marie",
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPPSFP04",
                ProductName = "ASPickPlaceScanFieldProduct04",
                Quantity = 2
            }
        };

        public static readonly List<PicklistLine> SecondPickOrderLines = new List<PicklistLine>
        {
            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 1,
                SpeditorId = "73",
                CustId = "EWMS-000002",
                CustName = "Louise Roth",
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPPSFP03",
                ProductName = "ASPickPlaceScanFieldProduct03",
                Quantity = 2
            },

            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 2,
                SpeditorId = "73",
                CustId = "EWMS-000002",
                CustName = "Louise Roth",
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPPSFP04",
                ProductName = "ASPickPlaceScanFieldProduct04",
                Quantity = 2
            }
        };
    }
}