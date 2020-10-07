using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.MultipleUserPutaway
{
    [Binding]
    public class FeatureSteps
    {
        [When(@"I click on Exit button in Autostore Putaway Mission page")]
        public void WhenIClickOnExitButtonInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.ClickExitButton(),
                "Unable to click on Exit button in Autostore Putaway Mission page");
        }

        [Then(@"The Delete Incomplete Tasks popup is loaded in Autostore Putaway Mission page")]
        public void TheDeleteIncompleteTasksPopupIsLoadedInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(DeleteIncompleteTasksPopup.Instance.IsPopupDisplayed(),
                "The Delete Incomplete Tasks popup is not loaded in Autostore Putaway Mission page");
        }

        [Then(@"I click Yes button in Delete Incomplete Tasks popup")]
        public void ThenIClickYesButtonInDeleteIncompleteTasksPopup()
        {
            Assert.IsTrue(DeleteIncompleteTasksPopup.Instance.ClickYesButton(),
                "Unable to click Yes button in Delete Incomplete Tasks popup");
        }

        [Then(@"I click on Exit button in Autostore Putaway Selection page")]
        public void ThenIClickOnExitButtonInAutostorePutawaySelectionPage()
        {
            Assert.IsTrue(PutawaySelection.Instance.ClickExitButton(),
                "Unable to click on Exit button in Autostore Putaway Selection page");
        }
    }
}
