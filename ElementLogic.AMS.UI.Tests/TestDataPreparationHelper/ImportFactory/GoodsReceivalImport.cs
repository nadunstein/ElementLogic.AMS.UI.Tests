using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Commands;
using ElementLogic.Integration.Import.Contracts.Types;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class GoodsReceivalImport
    {
        public static GoodsReceivalImport Instance => Singleton.Value;

        public void ImportGoodsReceival(IList<GoodsReceivalLine> putawayLines, ScenarioContext scenarioContext)
        {
            var retryCount = 0;
            while (true)
            {
                var picklistId = Guid.NewGuid().ToString().Substring(0, 8);
                foreach (var putawayLine in putawayLines)
                {
                    putawayLine.ExtPicklistId = picklistId;
                    putawayLine.ExtOrderId = picklistId;
                    putawayLine.PurchaseOrderId = picklistId;
                }

                CreateScenarioContextsForPutaway(putawayLines, scenarioContext);
                var goodsReceivalData = new ImportGoodsReceival {UniqueMessageId = Guid.NewGuid().ToString(), Lines = putawayLines};

                var grData = ApiDataFactory.ApiDataFactory.Instance.CreateGoodsReceivalAsync(goodsReceivalData).Result;
                if (grData.IsSuccessStatusCode)
                {
                    return;
                }

                if (retryCount == 2)
                {
                    Assert.Fail($"The putaway order is not created");
                }

                retryCount++;
            }
        }

        public void ImportGoodsReceival(ProductLocationLine productLocationsToBeCreated)
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

        private static void CreateScenarioContextsForPutaway(IList<GoodsReceivalLine> putawayLines, ScenarioContext scenarioContext)
        {
            if (scenarioContext.ContainsKey("ExtProductId"))
            {
                scenarioContext["ExtProductId01"] = scenarioContext["ExtProductId"];
                scenarioContext["ExtProductId02"] = putawayLines[0].ExtProductId;
            }

            scenarioContext["ExtProductId"] = putawayLines[0].ExtProductId;
            scenarioContext["Quantity"] = putawayLines[0].Quantity;
            scenarioContext["Supplier"] = putawayLines[0].Vendor;
            scenarioContext["Scancode"] = putawayLines[0].ProductScancodes;
            scenarioContext["Invoice"] = putawayLines[0].Invoice;
            scenarioContext["ProducerProductId"] = putawayLines[0].ProducerProductId;
            scenarioContext["EANId"] = putawayLines[0].EanId;
            scenarioContext["VenderProductId"] = putawayLines[0].VendorProductId;
            scenarioContext["ExtOrderId"] = putawayLines[0].ExtOrderId;
            scenarioContext["PONumber"] = putawayLines[0].ExtOrderId;
            scenarioContext["PurchaseId"] = putawayLines[0].PurchaseOrderId;
        }

        private GoodsReceivalImport() { }

        private static readonly Lazy<GoodsReceivalImport> Singleton =
            new Lazy<GoodsReceivalImport>(() => new GoodsReceivalImport());
    }
}
