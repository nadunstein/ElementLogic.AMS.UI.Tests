using System;
using System.Linq;
using System.Text.RegularExpressions;
using ElementLogic.AMS.UI.Tests.Integration;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataPreparationFactory;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using ElementLogic.Integration.Import.Contracts.Types;
using Humanizer;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.TestDataFactory
{
    public class TestDataFactory
    {
        public static TestDataFactory Instance => Singleton.Value;

        public void PrepareTestDataSet(ScenarioContext scenarioContext)
        {
            if (GetTestDataFilePath(scenarioContext) == null)
            {
                return;
            }

            var jsonObject = JsonFileReader.Instance.GetJsonObject(GetTestDataFilePath(scenarioContext));

            if (jsonObject.ContainsKey("ParametersToBeChanged"))
            {
                var jsonLists = jsonObject["ParametersToBeChanged"].Children().ToList();
                var parametersToBeChanged =
                    jsonLists.Select(jsonList => jsonList.ToObject<ParameterLIne>()).ToList();

                ParameterData.Instance.SetUpParameterData(parametersToBeChanged);
            }

            if (jsonObject.ContainsKey("ProductsToBeCreated"))
            {
                var jsonLists = jsonObject["ProductsToBeCreated"].Children().ToList();
                var productsToBeCreated =
                    jsonLists.Select(jsonList => jsonList.ToObject<ProductLine>()).ToList();

                ProductData.Instance.PrepareProductData(productsToBeCreated);
            }

            if (jsonObject.ContainsKey("ProductLocationsToBeCreated"))
            {
                var jsonLists = jsonObject["ProductLocationsToBeCreated"].Children().ToList();
                var productsToBeCreated =
                    jsonLists.Select(jsonList => jsonList.ToObject<ProductLocationLine>()).ToList();

                ProductLocationData.Instance.PrepareProductLocationData(productsToBeCreated);
            }

            if (jsonObject.ContainsKey("PutawayOrdersToBeCreated"))
            {
                var putawayOrdersJsonLists = jsonObject["PutawayOrdersToBeCreated"].Children().ToList();

                foreach (var putawayOrdersJsonList in putawayOrdersJsonLists)
                {
                    var putawayLineJsonLists = putawayOrdersJsonList["PutawayOrderToBeCreated"].Children().ToList();
                    var putawayOrderLinesToBeCreated =
                        putawayLineJsonLists.Select(putawayLineJsonList => putawayLineJsonList.ToObject<GoodsReceivalLine>()).ToList();
                    GoodsReceivalData.Instance.PrepareGoodsReceivalTestData(putawayOrderLinesToBeCreated,
                        scenarioContext);
                }
            }

            if (jsonObject.ContainsKey("PickOrdersToBeCreated"))
            {
                var pickOrdersJsonLists = jsonObject["PickOrdersToBeCreated"].Children().ToList();

                foreach (var pickOrdersJsonList in pickOrdersJsonLists)
                {
                    var picklistLineJsonLists = pickOrdersJsonList["PickOrderToBeCreated"].Children().ToList();
                    var pickOrderLinesToBeCreated =
                        picklistLineJsonLists.Select(picklistLineJsonList => picklistLineJsonList.ToObject<PicklistLine>()).ToList();
                    PicklistData.Instance.PreparePicklistTestData(pickOrderLinesToBeCreated, scenarioContext);
                }
            }
        }

        public string GetRefillTrolleyForScenario(ScenarioContext scenarioContext)
        {
            var jsonObject = JsonFileReader.Instance.GetJsonObject(GetTestDataFilePath(scenarioContext));
            return jsonObject.ContainsKey("RefillTrolley")? jsonObject["RefillTrolley"].ToString() : null;
        }

        private static string GetTestDataFilePath(ScenarioContext scenarioContext)
        {
            string testFilePathTag = null;
            string scenarioNumberTag = null;
            var scenarioTags = scenarioContext.ScenarioInfo.Tags;

            foreach (var scenarioTag in scenarioTags)
            {
                if (scenarioTag.Split(':').First().Contains("Login"))
                {
                    return null;
                }

                if (scenarioTag.Contains("AdminModule") || scenarioTag.Contains("Autostore"))
                {
                    testFilePathTag = scenarioTag;
                }

                if (scenarioTag.Contains("Scenario"))
                {
                    scenarioNumberTag = scenarioTag;
                }
            }

            if (testFilePathTag == null)
            {
                return null;
            }

            var modelingFilePath = testFilePathTag.Replace(":", "/");
            var testFilePath = $"Features/{modelingFilePath}/TestData/";
            var scenarioNumber = int.Parse(Regex.Match(scenarioNumberTag ?? string.Empty, @"\d+").Value);
            var humanizedScenarioNumber = scenarioNumber.ToOrdinalWords().Transform(To.TitleCase);
            var testFileName = $"{humanizedScenarioNumber}ScenarioTestData.json";
            return testFilePath + testFileName;
        }

        private TestDataFactory() { }

        private static readonly Lazy<TestDataFactory>
            Singleton = new Lazy<TestDataFactory>(() => new TestDataFactory());
    }
}
