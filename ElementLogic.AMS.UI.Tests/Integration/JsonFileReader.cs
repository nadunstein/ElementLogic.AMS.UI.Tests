using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Integration
{
    public class JsonFileReader
    {
        private static readonly string ProjectPath = FileHelper.Instance.GetProjectAssemblyPath();

        public static JsonFileReader Instance => Singleton.Value;

        public dynamic GetJsonKeyValue(string jsonAssemblyFilePath, string key)
        {
            var environmentConfiguration = new ConfigurationBuilder().SetBasePath(ProjectPath)
                .AddJsonFile(jsonAssemblyFilePath).Build();

            return environmentConfiguration.GetSection(key).Value;
        }

        public JObject GetJsonObject(string jsonAssemblyFilePath)
        {
            var jsonString =
                File.ReadAllText(ProjectPath + "/" + jsonAssemblyFilePath);
            return JObject.Parse(jsonString);
        }

        private JsonFileReader() { }

        private static readonly Lazy<JsonFileReader>
            Singleton = new Lazy<JsonFileReader>(() => new JsonFileReader());
    }
}
