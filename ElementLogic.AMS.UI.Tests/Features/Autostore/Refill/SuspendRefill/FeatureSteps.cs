using ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.SuspendRefill
{
    [Binding]
    public sealed class FeatureSteps
    {
        [When(@"I click on Exit button in Autostore Refill mission page")]
        public void WhenIClickOnExitButtonInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(RefillMission.Instance.ClickExitButton(),
                "Unable to click on Exit button from refill taskgroup selection page in Autostore");
        }

        [When(@"I click on Exit button from refill taskgroup selection page in Autostore")]
        public void WhenIClickOnExitButtonFromRefillTaskgroupSelectionPageInAutostore()
        {
            Assert.IsTrue(RefillTaskgroupSelection.Instance.ClickExitButton(),
                "Unable to click on Exit button from refill taskgroup selection page in Autostore");
        }

        [Then(@"The Confirm Task Exit dialog is displayed in Autostore Refill mission page")]
        public void ThenTheConfirmTaskExitDialogIsDisplayedInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(RefillTaskgroupExitPopup.Instance.IsPopupDisplayed(),
                "The Confirm Task Exit dialog is not displayed in Autostore Refill mission page");
        }

        [When(@"I Click on Yes button in Confirm Task Exit dialog in Autostore Refill mission page")]
        public void WhenIClickOnYesButtonInConfirmTaskExitDialogInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(RefillTaskgroupExitPopup.Instance.ClickYesButton(),
                "Unable to Click on Yes button in Confirm Task Exit dialog in Autostore Refill mission page");
        }
    }
}
