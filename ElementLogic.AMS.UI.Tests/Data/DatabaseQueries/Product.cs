using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ElementLogic.AMS.UI.Tests.Data.Manager;

namespace ElementLogic.AMS.UI.Tests.Data.DatabaseQueries
{
    public class Product
    {
        public static Product Instance => Singleton.Value;

        public ProductData GetProductData(string extProductId)
        {
            var productDetails = ProductData(extProductId);
            return productDetails.FirstOrDefault();
        }

        public bool IsProductExists(string extProductId)
        {
            var productDetails = ProductData(extProductId);
            return productDetails.Count().Equals(1);
        }

        private static IEnumerable<ProductData> ProductData(string extProductId)
        {
            const string mainSql = @"SELECT PRODUCTID AS productId,
                                            EXTPRODUCTID AS ExtProductId,
                                            IMAGEID AS ImageId
                                       FROM PRODUCT
                                      WHERE EXTPRODUCTID = @extProductId";

            var productDetails = ConnectionManager.Instance.ExecuteReturn(connection =>
                connection.Query<ProductData>(mainSql, new { extProductId }).ToList());
            return productDetails;
        }

        private Product() { }

        private static readonly Lazy<Product> Singleton = new Lazy<Product>(() => new Product());
    }

    public class ProductData
    {
        public int ProductId { get; set; }
        public string ExtProductId { get; set; }
        public string ImageId { get; set; }
    }
}
