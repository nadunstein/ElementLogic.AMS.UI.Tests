using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickDeviation
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"I change the quantity of the Quantity field as '(.*)' in Autostore Pick Mission page")]
        public void ThenIChangeTheQuantityOfTheQuantityFieldAsInAutostorePickMissionPage(int quantity)
        {
            Assert.IsTrue(PickMission.Instance.InsertQuantity(quantity.ToString()),
                $"Unable to Change the quantity of the Quantity field as '{quantity}' in Autostore Pick Mission page");
        }

        [Then(@"The pick Change Quantity popup is displayed in Autostore Pick Mission page")]
        public void ThenThePickChangeQuantityPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(ChangeQuantityPopup.Instance.IsPopupDisplayed(),
                    "The pick Change Quantity dialog is not displayed in Autostore Pick Mission page");
            Assert.AreEqual("Are you sure you want to change the quantity?",
                ChangeQuantityPopup.Instance.GetPopupMessage(),
                "The message of the pick Change Quantity popup is wrong");
        }

        [When(@"I click on '(.*)' button on Change Quantity popup in Autostore Pick Mission page")]
        public void WhenIClickOnButtonOnChangeQuantityPopupInAutostorePickMissionPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ChangeQuantityPopup.Instance.ClickYesButton(),
                "No" => ChangeQuantityPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Change Quantity popup in Autostore Pick Mission page");
        }

        [Then(@"The Empty location popup is displayed In Autostore Pick Mission page")]
        public void ThenTheEmptyLocationPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(EmptyLocationPopup.Instance.IsPopupDisplayed(),
                "The Empty location popup is not displayed in Autostore Pick Mission page");
            Assert.AreEqual("Is the location empty?",
                EmptyLocationPopup.Instance.GetPopupMessage(),
                "The message of the Empty location popup is wrong");
        }

        [When(@"I click on '(.*)' button on Empty location popup in Autostore Pick Mission page")]
        public void WhenIClickOnButtonOnEmptyLocationPopupInAutostorePickMissionPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => EmptyLocationPopup.Instance.ClickYesButton(),
                "No" => EmptyLocationPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Empty location popup in Autostore Pick Mission page");
        }
    }
}
