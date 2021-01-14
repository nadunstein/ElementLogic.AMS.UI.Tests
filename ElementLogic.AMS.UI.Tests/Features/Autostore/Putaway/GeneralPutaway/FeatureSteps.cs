using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.GeneralPutaway
{
    [Binding]
    public sealed class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;

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

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
