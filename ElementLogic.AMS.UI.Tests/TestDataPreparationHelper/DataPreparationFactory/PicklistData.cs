using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.ImportFactory;
using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Types.Dtos;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.TestDataPreparationHelper.DataPreparationFactory
{
    public class PicklistData
    {
        public static PicklistData Instance => Singleton.Value;

        public void PreparePicklistTestData(IList<PicklistLine> pickLines, ScenarioContext scenarioContext)
        {
            PicklistImport.Instance.ImportPicklist(pickLines, scenarioContext);
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

                PreparePicklistTestData(pickLines, scenarioContext);
            }
        }

        private PicklistData() { }

        private static readonly Lazy<PicklistData>
            Singleton = new Lazy<PicklistData>(() => new PicklistData());
    }
}
