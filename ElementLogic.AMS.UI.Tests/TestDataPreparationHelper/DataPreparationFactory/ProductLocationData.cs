using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataPreparationFactory
{
    public class ProductLocationData
    {
        public static ProductLocationData Instance => Singleton.Value;

        public void PrepareProductLocationData(IList<ProductLocationLine> productLocationsToBeCreated)
        {
            foreach (var productLocationToBeCreated in productLocationsToBeCreated)
            {
                GoodsReceivalImport.Instance.ImportGoodsReceival(productLocationToBeCreated);
                CreateAutostoreProductLocations.Instance.DoAutostorePutaway(productLocationToBeCreated.LocationType,
                    productLocationToBeCreated.ExtProductId);
            }
        }

        private ProductLocationData() { }

        private static readonly Lazy<ProductLocationData> Singleton = new Lazy<ProductLocationData>(() => new ProductLocationData());
    }
}
