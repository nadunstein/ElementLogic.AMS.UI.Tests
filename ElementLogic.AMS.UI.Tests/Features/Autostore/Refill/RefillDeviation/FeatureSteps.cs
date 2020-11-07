using ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill.RefillDeviation
{
    [Binding]
    public class FeatureSteps
    {
        [Then(@"I change the refill quantity as '(.*)' in Autostore Refill mission page")]
        public void ThenIChangeTheRefillQuantityAsInAutostoreRefillMissionPage(string reducedQuantity)
        {
            Assert.IsTrue(RefillMission.Instance.ChangeValueOfQuantityField(reducedQuantity),
                $"Unable to reduce the quantity of the Quantity field by {reducedQuantity} field in Refill Mission page");
        }

        [Then(@"The Change Quantity Dialog is displayed in Autostore Refill mission page")]
        public void ThenTheChangeQuantityDialogIsDisplayedInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(RefillChangeQuantityPopup.Instance.IsPopupDisplayed(),
                "The Change Quantity Dialog is not displayed in Autostore Refill mission page");
            Assert.AreEqual("Are you sure you want to change the quantity?", RefillChangeQuantityPopup.Instance.GetPopupMessage(),
                "The Message of the Change Quantity Dialog is wrong in Autostore Refill mission page");
        }

        [When(@"I click on Yes button on Change Quantity Dialog in Autostore Refill mission page")]
        public void WhenIClickOnYesButtonOnChangeQuantityDialogInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(RefillChangeQuantityPopup.Instance.ClickYesButton(), 
                "Unable to click on Yes button on Change Quantity Dialog in Autostore Refill mission page");
        }

        [Then(@"The Confirm Remaining Refill Dialog is displayed in Autostore Refill mission page")]
        public void ThenTheConfirmRemainingRefillDialogIsDisplayedInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(ConfirmRemainingRefillPopup.Instance.IsPopupDisplayed(),
                "The Change Quantity Dialog is not displayed in Autostore Refill mission page");
            Assert.AreEqual("Do you have remaining quantity for the refill mission?", 
                ConfirmRemainingRefillPopup.Instance.GetPopupMessage(),
                "The Message of the Change Quantity Dialog is wrong in Autostore Refill mission page");
        }

        [When(@"I click on Yes button on Confirm Remaining Refill Dialog in Autostore Refill mission page")]
        public void WhenIClickOnYesButtonOnConfirmRemainingRefillDialogInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(ConfirmRemainingRefillPopup.Instance.ClickYesButton(),
                "Unable to click on Yes button on Confirm Remaining Refill Dialog in Autostore Refill mission page");
        }
    }
}
