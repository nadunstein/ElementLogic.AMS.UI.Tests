using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.PutawayMore
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"The PutawayMore Button is not displayed in the Autostore putaway mission page")]
        public void ThenThePutawayMoreButtonIsNotDisplayedInTheAutostorePutawayMissionPage()
        {
            Assert.IsFalse(PutawayMission.Instance.IsPutawayMoreButtonDisplayed(), 
                "PutawayMore Button is displayed in the Autostore putaway mission page");
        }

        [Then(@"The PutawayMore Button is displayed in the Autostore putaway mission page")]
        public void ThenThePutawayMoreButtonIsDisplayedInTheAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.IsPutawayMoreButtonDisplayed(), 
                "PutawayMore Button is not displayed in the Autostore putaway mission page");
        }

        [When(@"I click on PutawayMore button in Autostore putaway mission page")]
        public void WhenIClickOnPutawayMoreButtonInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.ClickPutawayMoreButton(), 
                "Unable to click on PutawayMore button in Autostore putaway mission page");
        }
    }
}
