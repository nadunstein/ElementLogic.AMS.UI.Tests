using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using NUnit.Framework;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class InventoryCountImport
    {
        public static InventoryCountImport Instance => Singleton.Value;

        public async void ImportInventoryCount(IList<InventoryLine> inventoryLines)
        {
            var inventoryCountData = new ImportInventoryCount()
            {
                ReferenceName = Guid.NewGuid().ToString(),
                Items = inventoryLines
            };

            var icData = await ApiDataFactory.ApiDataFactory.Instance.CreateInventoryCountAsync(inventoryCountData);
            if (icData.IsSuccessStatusCode)
            {
                return;
            }

            Assert.Fail("The inventory count(s) are not Imported");
        }

        private InventoryCountImport() { }

        private static readonly Lazy<InventoryCountImport> Singleton =
            new Lazy<InventoryCountImport>(() => new InventoryCountImport());
    }
}
