using ElementLogic.Integration.Import.Contracts.Commands;
using ElementLogic.Integration.Import.Contracts.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class ProductImport
    {
        public static ProductImport Instance => Singleton.Value;

        public void ImportProduct(IList<ProductLine> productLines)
        {
            var productData = new ImportProductInformation
            {
                UniqueMessageId = Guid.NewGuid().ToString(),
                Lines = productLines
            };

            var grData = ApiDataFactory.ApiDataFactory.Instance.CreateProductAsync(productData).Result;
            if (grData.IsSuccessStatusCode)
            {
                return;
            }

            Assert.Fail("The product(s) are not Imported");
        }

        private ProductImport() { }

        private static readonly Lazy<ProductImport> Singleton =
            new Lazy<ProductImport>(() => new ProductImport());
    }
}
