using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ElementLogic.AMS.UI.Tests.Configuration;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataFactory
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient()
        {
            var client = new HttpClient
                {BaseAddress = new Uri(ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url"))};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YWRtOjIwNDA=");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }

    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}
