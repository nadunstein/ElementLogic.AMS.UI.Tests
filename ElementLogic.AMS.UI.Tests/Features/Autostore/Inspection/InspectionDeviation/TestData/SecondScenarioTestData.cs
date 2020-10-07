using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.InspectionDeviation.TestData
{
    public class SecondScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASIDP02",
                ProductName = "AutostoreInspectionDeviationProduct02",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };
    }
}
