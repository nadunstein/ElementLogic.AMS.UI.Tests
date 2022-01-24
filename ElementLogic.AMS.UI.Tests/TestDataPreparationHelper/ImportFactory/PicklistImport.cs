using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class PicklistImport
    {
        public static PicklistImport Instance => Singleton.Value;

        public async void ImportPicklist(IList<PicklistLine> pickLines, ScenarioContext scenarioContext)
        {
            var picklistId = Guid.NewGuid().ToString().Substring(0, 8);
            
            var pickDate = DateTime.Now.ToString("yyyyMMdd");
            const string pickTime = "080200";
            foreach (var picklistLine in pickLines)
            {
                picklistLine.ExtPicklistId = picklistId;
                picklistLine.ExtOrderId = picklistId;
                picklistLine.ExtPickDate = pickDate;
                picklistLine.ExtPickTime = pickTime;
            }

            CreateScenarioContextsForPick(pickLines, scenarioContext);

            var pickData = new ImportPicklist
            {
                UniqueMessageId = Guid.NewGuid().ToString(),
                Lines = pickLines
            };

            var plData = await ApiDataFactory.ApiDataFactory.Instance.CreatePicklistAsync(pickData);
            if (!plData.IsSuccessStatusCode)
            {
                Assert.Fail($"The pick order {picklistId} is not created");
            }
        }

        private static void CreateScenarioContextsForPick(IList<PicklistLine> pickLines, ScenarioContext scenarioContext)
        {
            scenarioContext["PicklistId"] = pickLines[0].ExtPicklistId;
            scenarioContext["ExtOrderlineId"] = pickLines[0].ExtOrderlineId;
        }

        private PicklistImport() { }

        private static readonly Lazy<PicklistImport>
            Singleton = new Lazy<PicklistImport>(() => new PicklistImport());
    }
}
