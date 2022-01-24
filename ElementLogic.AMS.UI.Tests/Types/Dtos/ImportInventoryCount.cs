using System.Collections.Generic;

namespace ElementLogic.AMS.UI.Tests.Types.Dtos
{
    public class ImportInventoryCount
    {
        public string ReferenceName { get; set; }

        public IEnumerable<InventoryLine> Items { get; set; }
    }
}
