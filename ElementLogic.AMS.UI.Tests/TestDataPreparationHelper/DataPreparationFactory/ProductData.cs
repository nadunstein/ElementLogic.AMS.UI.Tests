using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory;
using ElementLogic.Integration.Import.Contracts.Types;
using System;
using System.Collections.Generic;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataPreparationFactory
{
    public class ProductData
    {
        public static ProductData Instance => Singleton.Value;

        public void PrepareProductData(IList<ProductLine> productLines)
        {
            ProductImport.Instance.ImportProduct(productLines);
        }

        private ProductData() { }

        private static readonly Lazy<ProductData>
            Singleton = new Lazy<ProductData>(() => new ProductData());
    }
}
