using System;
using System.Net.Http;
using System.Threading.Tasks;
using ElementLogic.AMS.UI.Tests.Types.Dtos;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ApiDataFactory
{
    public class ApiDataFactory
    {
        public static ApiDataFactory Instance => Singleton.Value;

        public async Task<HttpResponseMessage> CreateProductAsync(ImportProductInformation productData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("/api/products", productData);
        }

        public async Task<HttpResponseMessage> CreateGoodsReceivalAsync(ImportGoodsReceival goodsReceivalData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync(" /api/goodsreceivals", goodsReceivalData);
        }

        public async Task<HttpResponseMessage> CreatePicklistAsync(ImportPicklist picklistData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("/api/PickLists", picklistData);
        }

        public async Task<HttpResponseMessage> CreateInventoryCountAsync(ImportInventoryCount inventoryCountData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("api/inventorycounts", inventoryCountData);
        }

        private ApiDataFactory() { }

        private static readonly Lazy<ApiDataFactory> Singleton = new Lazy<ApiDataFactory>(() => new ApiDataFactory());
    }
}
