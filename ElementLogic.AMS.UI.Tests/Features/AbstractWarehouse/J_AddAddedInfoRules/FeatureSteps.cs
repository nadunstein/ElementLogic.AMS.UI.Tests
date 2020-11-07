using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AbstractWarehouse.J_AddAddedInfoRules
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I add added info rule to AddedInfoRules table as follows:")]
        public void GivenIAddAddedInfoRuleToAddedInfoRulesTableAsFollows(Table table)
        {
            var addedInfoRules = table.CreateDynamicSet();
            foreach (var addedInfoRule in addedInfoRules)
            {
               AddedInfoRules.Instance.InsertAddedInfoRule(addedInfoRule.Id,
                    addedInfoRule.AddedInfoRuleName, addedInfoRule.ExactQuantity, addedInfoRule.AddedInfoRegEx);
            }
        }
    }
}
