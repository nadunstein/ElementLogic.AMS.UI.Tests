using System;
using Microsoft.Extensions.Configuration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Configuration
{
    public class ConfigFileReader
    {
        public static ConfigFileReader Instance => Singleton.Value;

        public dynamic ConfigurationKeyValue(string key)
        {
            var projectPath = WebDriverHelper.Instance.GetProjectPath();
            var environmentConfiguration = new ConfigurationBuilder().SetBasePath(projectPath)
                .AddJsonFile("Configuration/Environment.json").Build();

            return environmentConfiguration.GetSection(key).Value;
        }

        private ConfigFileReader() { }

        private static readonly Lazy<ConfigFileReader> Singleton =
            new Lazy<ConfigFileReader>(() => new ConfigFileReader());
    }
}
