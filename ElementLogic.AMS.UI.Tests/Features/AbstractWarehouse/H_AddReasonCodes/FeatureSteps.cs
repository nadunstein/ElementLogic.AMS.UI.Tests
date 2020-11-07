using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AbstractWarehouse.H_AddReasonCodes
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I add reason codes to REASONCODE table as follows:")]
        public void GivenIAddReasonCodesToReasonCodeTableAsFollows(Table table)
        {
            var reasonCodes = table.CreateDynamicSet();
            foreach (var reasonCode in reasonCodes)
            {
                ReasonCode.Instance.InsertReasonCode(reasonCode.ReasonCodeID, reasonCode.ReasonText,
                    reasonCode.UpdateCode);
            }
        }
    }
}
