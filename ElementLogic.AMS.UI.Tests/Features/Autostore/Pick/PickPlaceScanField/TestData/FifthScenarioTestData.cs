﻿using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickPlaceScanField.TestData
{
    public class FifthScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASPPSFP06",
                ProductName = "ASPickPlaceScanFieldProduct06",
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
                ExtProductId = "ASPPSFP06",
                ProductName = "ASPickPlaceScanFieldProduct06",
                Quantity = 2
            }
        };
    }
}
