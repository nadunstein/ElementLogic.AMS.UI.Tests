using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.ConfirmRestQuantity
{
    [Binding]
    public class FeatureSteps
    {
        [Then(@"The Remaining Quantity Changed popup is displayed in Autostore Pick Mission page")]
        public void ThenTheRemainingQuantityChangedPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(RemainingQuantityChangedPopup.Instance.IsPopupDisplayed(),
                "The Remaining Quantity Changed popup is NOT displayed in Autostore Pick Mission page");
        }

        [Then(@"I verify the quantity is '(.*)' on Remaining Quantity Changed popup in Autostore Pick Mission page")]
        public void ThenIVerifyTheQuantityIsOnRemainingQuantityChangedPopupInAutostorePickMissionPage(int remainingQuantity)
        {
            Assert.IsTrue(
                RemainingQuantityChangedPopup.Instance.GetPopupMessage().Contains(remainingQuantity.ToString()),
                "The quantity is wrong on Remaining Quantity Changed popup in Autostore Pick Mission page");
        }

        [When(@"I click '(.*)' button on Remaining Quantity Changed popup in Autostore Pick Mission page")]
        public void WhenIClickButtonOnRemainingQuantityChangedPopupInAutostorePickMissionPage(string button)
        {
            Assert.IsTrue(RemainingQuantityChangedPopup.Instance.ClickPopupButton(button),
                $"Unable to click '{button}' button on Remaining Quantity Changed popup in Autostore Pick Mission page");
        }

        [Then(@"I verify the remaining quantity is displayed as '(.*)' on Confirm Quantity popup in Autostore Pick Mission page")]
        public void ThenIVerifyTheRemainingQuantityIsDisplayedAsOnConfirmQuantityPopupInAutostorePickMissionPage(int remainingQuantity)
        {
            Assert.AreEqual(remainingQuantity.ToString(), ConfirmQuantityPopUp.Instance.GetQuantityFieldValue(),
                "The remaining quantity is wrong on Confirm Quantity popup in Autostore Pick Mission page");
        }

        [Then(@"I verify the remaining quantity is not displayed on Confirm Quantity popup in Autostore Pick Mission page")]
        public void ThenIVerifyTheRemainingQuantityIsNotDisplayedOnConfirmQuantityPopupInAutostorePickMissionPage()
        {
            Assert.IsTrue(ConfirmQuantityPopUp.Instance.IsQuantityFieldValueEmpty(),
                "The remaining quantity is displayed on Confirm Quantity popup in Autostore Pick Mission page");
        }
    }
}
