using ElementLogic.AMS.UI.Tests.Features.SupportTasks;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Systems.Parameters
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I change the '(.*)' parameter value as '(.*)'")]
        public void GivenIChangeTheParameterValueAs(string parameterCode, string paramValue)
        {
            SetUpParameters.Instance.ChangeTheParameterValue(parameterCode, paramValue);
        }
    }
}
