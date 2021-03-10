using System;
using System.Collections.Generic;
using ElementLogic.Integration.Import.Contracts.Commands;
using ElementLogic.Integration.Import.Contracts.Types;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class PickData
    {
        public static PickData Instance => Singleton.Value;

        public void PreparePickTestData(IList<PicklistLine> pickLines, ScenarioContext scenarioContext)
        {
            GeneratePickOrder(pickLines, scenarioContext);
        }

        public void PrepareMultiplePickTestDataForSameProduct(IList<PicklistLine> pickLines, int count,
            ScenarioContext scenarioContext)
        {
            for (var i = 1; i <= count; i++)
            {
                foreach (var picklistLine in pickLines)
                {
                    picklistLine.CustId = string.Concat("EWMS-00000", i);
                }

                PreparePickTestData(pickLines, scenarioContext);
            }
        }

        private static void GeneratePickOrder(IList<PicklistLine> pickLines, ScenarioContext scenarioContext)
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

            var plData = ApiDataFactory.ApiDataFactory.Instance.CreatePicklistAsync(pickData).Result;
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

        private PickData() { }

        private static readonly Lazy<PickData>
            Singleton = new Lazy<PickData>(() => new PickData());
    }
}
