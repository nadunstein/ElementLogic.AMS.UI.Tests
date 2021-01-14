using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Refill;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Activity.Refill.TrolleyTakeOver
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Given(@"The Take over trolley popup is displayed in Refill Order List page")]
        public void GivenTheTakeOverTrolleyPopupIsDisplayedInRefillOrderListPage()
        {
            Assert.True(TakeOverTrolleyPopup.Instance.IsPopupDisplayed(),
                "The Take over trolley popup is NOT displayed in Refill Order List page");
        }

        [When(@"I click on YES button on Take over trolley popup in Refill Order List page")]
        public void WhenIClickOnYesButtonOnTakeOverTrolleyPopupInRefillOrderListPage()
        {
            TakeOverTrolleyPopup.Instance.ClickYesButton();
        }
    }
}
