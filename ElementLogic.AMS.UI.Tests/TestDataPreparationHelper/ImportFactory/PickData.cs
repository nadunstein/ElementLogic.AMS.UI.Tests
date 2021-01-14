using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.Integration.Import.Contracts.Commands;
using ElementLogic.Integration.Import.Contracts.Types;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory
{
    public class PickData
    {
        public static PickData Instance => Singleton.Value;

        public void PreparePickTestData(IList<PicklistLine> pickLines, ScenarioContext scenarioContext,
            bool isPickReassignOrBatchOrder = false)
        {
            GeneratePickOrder(pickLines, scenarioContext, isPickReassignOrBatchOrder);
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

                PreparePickTestData(pickLines, scenarioContext, true);
            }
        }

        private static void GeneratePickOrder(IList<PicklistLine> pickLines,
            ScenarioContext scenarioContext, bool isPickReassignOrBatchOrder = false)
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

            if (isPickReassignOrBatchOrder)
            {
                return;
            }

            WaitToPreparePickOrder(picklistId);
        }

        private static void CreateScenarioContextsForPick(IList<PicklistLine> pickLines, ScenarioContext scenarioContext)
        {
            scenarioContext["PicklistId"] = pickLines[0].ExtPicklistId;
            scenarioContext["ExtOrderlineId"] = pickLines[0].ExtOrderlineId;
        }

        private static void WaitToPreparePickOrder(string picklistId)
        {
            var timeOut = 0;
            string orderStatusId;
            var statusesToWait = new[]
            {
                AutoStoreManagementSystem.UITests.Types.Enums.LineStatus.AssignedLocation.ToString("d"),
                AutoStoreManagementSystem.UITests.Types.Enums.LineStatus.Prepared.ToString("d")
            };

            do
            {
                orderStatusId = Order.Instance.GetOrderStatusId(picklistId);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                timeOut++;
            }
            while (!statusesToWait.Contains(orderStatusId) && timeOut < 50);

            if (timeOut.Equals(50))
            {
                Assert.Fail("The pick mission is not created");
            }
        }

        private PickData() { }

        private static readonly Lazy<PickData>
            Singleton = new Lazy<PickData>(() => new PickData());
    }
}
