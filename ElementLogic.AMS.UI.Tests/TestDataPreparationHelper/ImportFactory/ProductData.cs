using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Commands;
using ElementLogic.Integration.Import.Contracts.Types;
using NUnit.Framework;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class ProductData
    {
        public static ProductData Instance => Singleton.Value;

        public void PrepareProductData(IList<ProductLocationLine> productLocationsToBeCreated)
        {
            foreach (var productLocationToBeCreated in productLocationsToBeCreated)
            {
                GenerateGoodsReceivalOrder(productLocationToBeCreated);
                CreateAutostoreProductLocations.Instance.DoAutostorePutaway(productLocationToBeCreated.LocationType,
                    productLocationToBeCreated.ExtProductId);
            }
        }

        private static void GenerateGoodsReceivalOrder(ProductLocationLine productLocationsToBeCreated)
        {
            var picklistId = Guid.NewGuid().ToString().Substring(0, 8);
            var putawayLines = new List<GoodsReceivalLine>
            {
                new GoodsReceivalLine
                {
                    Action = "A",
                    PurchaseOrderLineId = "1",
                    ExtPicklistId = picklistId,
                    ExtOrderId = picklistId,
                    PurchaseOrderId = picklistId,
                    ExtProductId = productLocationsToBeCreated.ExtProductId,
                    ProductName = productLocationsToBeCreated.ProductName,
                    Quantity = productLocationsToBeCreated.Quantity,
                    Returned = false
                }
            };

            var goodsReceivalData = new ImportGoodsReceival
            {
                UniqueMessageId = Guid.NewGuid().ToString(),
                Lines = putawayLines
            };

            var grData = ApiDataFactory.ApiDataFactory.Instance.CreateGoodsReceivalAsync(goodsReceivalData).Result;
            if (!grData.IsSuccessStatusCode)
            {
                Assert.Fail($"The Test data preparation GR order {picklistId} is not created");
            }
        }

        private ProductData() { }

        private static readonly Lazy<ProductData> Singleton = new Lazy<ProductData>(() => new ProductData());
    }
}
