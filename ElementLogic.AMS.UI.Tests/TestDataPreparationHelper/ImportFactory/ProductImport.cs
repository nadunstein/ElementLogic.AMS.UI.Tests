using NUnit.Framework;
using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class ProductImport
    {
        public static ProductImport Instance => Singleton.Value;

        public async void ImportProduct(IList<ProductLine> productLines)
        {
            var productData = new ImportProductInformation
            {
                UniqueMessageId = Guid.NewGuid().ToString(),
                Lines = productLines
            };

            var grData = await ApiDataFactory.ApiDataFactory.Instance.CreateProductAsync(productData);
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
