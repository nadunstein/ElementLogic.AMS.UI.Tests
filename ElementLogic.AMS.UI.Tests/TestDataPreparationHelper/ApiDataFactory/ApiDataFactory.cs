using System;
using System.Net.Http;
using System.Threading.Tasks;
using ElementLogic.Integration.Import.Contracts.Commands;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ApiDataFactory
{
    public class ApiDataFactory
    {
        public static ApiDataFactory Instance => Singleton.Value;

        public static async Task<HttpResponseMessage> CreateProductAsync(ImportProductInformation productData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("api/products", productData);
        }

        public async Task<HttpResponseMessage> CreateGoodsReceivalAsync(ImportGoodsReceival goodsReceivalData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("/api/GoodsReceivals", goodsReceivalData);
        }

        public async Task<HttpResponseMessage> CreatePicklistAsync(ImportPicklist picklistData)
        {
            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("/api/PickLists", picklistData);
        }

        private ApiDataFactory() { }

        private static readonly Lazy<ApiDataFactory> Singleton = new Lazy<ApiDataFactory>(() => new ApiDataFactory());
    }
}
