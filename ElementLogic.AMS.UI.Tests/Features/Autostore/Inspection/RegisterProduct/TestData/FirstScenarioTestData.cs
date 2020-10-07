using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.RegisterProduct.TestData
{
    public class FirstScenarioTestData
    {
        public static readonly List<ProductLocationLine> ProductToBeCreated = new List<ProductLocationLine>
        {
            new ProductLocationLine
            {
                ExtProductId = "ASIRP01",
                ProductName = "AutostoreInspectionRegisterProduct01",
                LocationType = "A 1/1 AutoStore Bin",
                Quantity = 20
            }
        };
    }
}
