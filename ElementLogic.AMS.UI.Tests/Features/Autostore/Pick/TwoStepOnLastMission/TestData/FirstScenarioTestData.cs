using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.TwoStepOnLastMission.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductsToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASPTSLMP01",
                ProductName = "ASPickTwoStepsOnLastMissionProduct01",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            },

            new ProductLocationLine
            {
                ExtProductId = "ASPTSLMP02",
                ProductName = "ASPickTwoStepsOnLastMissionProduct02",
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
                ExtProductId = "ASPTSLMP01",
                ProductName = "ASPickTwoStepsOnLastMissionProduct01",
                Quantity = 10
            },

            new PicklistLine
            {
                Action = "A",
                ExtOrderlineId = 2,
                SpeditorId = "73",
                OrderTypeId = "25",
                OrderTypeText = "Normal AS",
                ExtProductId = "ASPTSLMP02",
                ProductName = "ASPickTwoStepsOnLastMissionProduct02",
                Quantity = 10
            }
        };
    }
}
