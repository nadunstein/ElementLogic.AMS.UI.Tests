using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.MaxQuantityPopup
{
    [Binding]
    public class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Then(@"The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page")]
        public void ThenTheZeroQuantityConfirmationPopupIsDisplayedInAutostorePickMissionPage()
        {
            if (!_scenarioContext.ContainsKey("IsZeroQuantityConfirmationPopupNeedToBeDisplayed") ||
                _scenarioContext.ContainsKey("IsZeroQuantityConfirmationPopupNeedToBeDisplayed") &&
                 !_scenarioContext["IsZeroQuantityConfirmationPopupNeedToBeDisplayed"].Equals(true))
            {
                return; // To avoid the test failing with multiple mission pick for one or more whole location picking
            }

            Assert.IsTrue(ZeroQuantityPopUp.Instance.IsPopupDisplayed(),
                "The Zero Quantity confirmation popup is not displayed in Autostore Pick Mission page");
            Assert.AreEqual("Is the location you picked from empty?", ZeroQuantityPopUp.Instance.GetPopupMessage(),
                "The Zero Quantity confirmation popup message is wrong in Autostore Pick Mission page");
        }

        [When(@"I click on '(.*)' button on Zero Quantity confirmation popup in Autostore Pick Mission page")]
        public void WhenIClickOnButtonOnZeroQuantityConfirmationPopupInAutostorePickMissionPage(string buttonToBeClicked)
        {
            if(!_scenarioContext.ContainsKey("IsZeroQuantityConfirmationPopupNeedToBeDisplayed") ||
                _scenarioContext.ContainsKey("IsZeroQuantityConfirmationPopupNeedToBeDisplayed") &&
                !_scenarioContext["IsZeroQuantityConfirmationPopupNeedToBeDisplayed"].Equals(true))
            {
                return; // To avoid the test failing with multiple mission pick for one or more whole location picking
            }

            _scenarioContext["IsZeroQuantityConfirmationPopupNeedToBeDisplayed"] = false;
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ZeroQuantityPopUp.Instance.ClickYesButton(),
                "No" => ZeroQuantityPopUp.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Zero Quantity confirmation popup in Autostore Pick Mission page");
        }

        [Then(@"The Confirm Quantity popup is displayed in Autostore Pick Mission page")]
        public void ThenTheConfirmQuantityPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(ConfirmQuantityPopUp.Instance.IsPopupDisplayed(),
                "The Confirm Quantity popup is not displayed in Autostore Pick Mission page");
            Assert.AreEqual("Confirm remaining quantity in the location", ConfirmQuantityPopUp.Instance.GetPopupMessage(),
                "The Confirm Quantity popup message is wrong in Autostore Pick Mission page");
        }

        [Then(@"I include the Quantity as '(.*)' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page")]
        public void ThenIIncludeTheQuantityAsToTheQuantityFieldOnConfirmQuantityPopupInAutostorePickMissionPage(int quantity)
        {
            Assert.IsTrue(ConfirmQuantityPopUp.Instance.InsertQuantity(quantity.ToString()),
                $"Unable to include the Quantity as {quantity} to the quantity field on Confirm Quantity popup in Autostore Pick Mission page");
        }

        [When(@"I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page")]
        public void WhenIClickOnTheConfirmButtonOnConfirmQuantityPopupInAutostorePickMissionPage()
        {
            Assert.IsTrue(ConfirmQuantityPopUp.Instance.ClickConfirmButton(),
                "Unable to click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page");
        }

        [Then(@"The Changed confirm quantity popup is displayed in Autostore Pick Mission page")]
        public void ThenTheChangedConfirmQuantityPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(ChangedConfirmQuantityPopUp.Instance.IsPopupDisplayed(),
                "The Changed confirm quantity popup is not displayed in Autostore Pick Mission page");
            Assert.AreEqual(
                "The entered quantity is higher than the maximum allowed (10000). Do you want to continue ?",
                ChangedConfirmQuantityPopUp.Instance.GetPopupMessage(),
                "The Changed confirm quantity popup message is wrong in Autostore Pick Mission page");
        }

        [Then(@"I check the focus is on No button on Changed confirm quantity popup in Autostore Pick Mission page")]
        public void ThenICheckTheFocusIsOnNoButtonOnChangedConfirmQuantityPopupInAutostorePickMissionPage()
        {
            Assert.IsTrue(ChangedConfirmQuantityPopUp.Instance.IsNoButtonFocused(),
                "The focus is not on No button on Changed confirm quantity popup in Autostore Pick Mission page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
