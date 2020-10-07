using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Commands;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataFactory
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

        public async Task<HttpResponseMessage> CreateProductLocationAsync(IList<DirectPutawayLine> productlocationData)
        {
            var productLocationJsonString =
                new JavaScriptSerializer().Serialize(productlocationData).TrimStart('[').TrimEnd(']');
            var productLocationData = JObject.Parse(productLocationJsonString);

            var factory = new HttpClientFactory();
            using var client = factory.CreateHttpClient();
            return await client.PostAsJsonAsync("/api/external/putaway", productLocationData);
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
