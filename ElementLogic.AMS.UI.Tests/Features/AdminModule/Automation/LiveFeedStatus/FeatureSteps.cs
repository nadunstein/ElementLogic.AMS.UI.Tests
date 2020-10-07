using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus;
using NUnit.Framework;
using TechTalk.SpecFlow;
using AutoStoreLiveFeedStatus =
    ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus.LiveFeedStatus;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Automation.LiveFeedStatus
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I navigate to Live feed status page")]
        public void GivenINavigateToLiveFeedStatusPage()
        {
            AutoStoreLiveFeedStatus.Instance.Navigate();
            Assert.AreEqual("Live feed status", AutoStoreLiveFeedStatus.Instance.GetPageTitle(),
                "The Autostore equipment list - Live feed status page is NOT loaded");
        }

        [When(@"I select '(.*)' option from the Gear action menu in Live feed status page")]
        public void WhenISelectOptionFromTheGearActionMenuInLiveFeedStatusPage(string option)
        {
            Assert.IsTrue(AutoStoreLiveFeedStatus.Instance.SelectActionDropDownOption(option),
                "The Action DropDown is not selectable in Live feed status page");
        }

        [Then(@"The Synchronize bin contents popup is displayed in Live feed status page")]
        public void ThenTheSynchronizeBinContentsPopupIsDisplayedInLiveFeedStatusPage()
        {
            Assert.AreEqual("Synchronize bin contents", SynchronizeBinContentsPopUp.Instance.GetPopUpTitle(),
                "Synchronize bin contents popUp is NOT displayed in Live feed status page");
        }

        [Then(@"I click on Synchronize button on Synchronize bin contents popup in Live feed status page")]
        public void ThenIClickOnSynchronizeButtonOnSynchronizeBinContentsPopupInLiveFeedStatusPage()
        {
            Assert.IsTrue(SynchronizeBinContentsPopUp.Instance.ClickSynchronizeButton(),
                "Unable to click on Synchronize button on Synchronize bin contents popup in Live feed status page");
        }
    }
}
