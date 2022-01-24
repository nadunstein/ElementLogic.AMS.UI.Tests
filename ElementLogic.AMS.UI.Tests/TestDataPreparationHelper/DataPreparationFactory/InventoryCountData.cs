using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataPreparationFactory
{
    public class InventoryCountData
    {
        public static InventoryCountData Instance => Singleton.Value;

        public void PrepareInventoryCountData(IList<InventoryLine> inventoryCountsToBeCreated)
        {
            InventoryCountImport.Instance.ImportInventoryCount(inventoryCountsToBeCreated);
        }

        private InventoryCountData() { }

        private static readonly Lazy<InventoryCountData> Singleton =
            new Lazy<InventoryCountData>(() => new InventoryCountData());
    }
}
