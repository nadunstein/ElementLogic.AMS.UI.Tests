using ElementLogic.AMS.UI.Tests.Integration;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AbstractWarehouse.K_PrepareAutostore
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I Perform a Reset for Internet Information Services\(IIS\) Manager")]
        public void GivenIPerformAResetForInternetInformationServicesIisManager()
        {
            WindowsServices.Instance.DoIisReset();
        }
    }
}
