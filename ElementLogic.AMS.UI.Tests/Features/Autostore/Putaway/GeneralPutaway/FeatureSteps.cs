using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.GeneralPutaway
{
    [Binding]
    public class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Then(@"I check the focus is on scan field in Autostore putaway mission page")]
        public void ThenICheckTheFocusIsOnScanFieldInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.IsScanFieldDisplayed(),
                "The Scan Field is not displayed in Autostore putaway mission page");
            Assert.True(PutawayMission.Instance.IsScanFieldFocused(),
                "The Focus is NOT on the Scan field in Autostore putaway mission page");
        }

        [Then(@"I verify the putaway product image is displayed in Autostore putaway mission page")]
        public void ThenIVerifyThePutawayProductImageIsDisplayedInAutostorePutawayMissionPage()
        {
            var imageId = Product.Instance.GetProductData(_scenarioContext["ExtProductId"].ToString()).ImageId;
            var imageServiceEndPoint =
                Parameter.Instance.GetParameterData("ProductImageServiceEndpoint").ParameterTextValue;
            var imageUrl = string.Format(imageServiceEndPoint, imageId);
            Assert.AreEqual(imageUrl, PutawayMission.Instance.GetProductImageUrl(),
                "The putaway product image URL is wrong in autostore putaway mission page");
            Assert.IsTrue(PutawayMission.Instance.IsProductImageDisplayed(),
                "The Putaway product image is NOT displayed in Autostore putaway mission page");
        }

        [Then(@"I include the scan value to Scan value field in Autostore putaway mission page")]
        public void ThenIIncludeTheScanValueToScanValueFieldInAutostorePutawayMissionPage()
        {
            var extProductId = _scenarioContext["ExtProductId"].ToString();
            Assert.IsTrue(PutawayMission.Instance.IncludeScanValue(extProductId),
                "Unable to include the scan value to Scan value field in Autostore putaway mission page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
