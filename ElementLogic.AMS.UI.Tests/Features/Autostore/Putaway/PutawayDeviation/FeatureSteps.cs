using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.PutawayDeviation
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"The maximum bin quantity popup is displayed in Autostore putaway Mission page")]
        public void ThenTheMaximumBinQuantityPopupIsDisplayedInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(MaximumBinQuantityPopup.Instance.IsPopupDisplayed(),
                "The maximum bin quantity popup is not displayed in Autostore putaway Mission page");

            const string expectedPopupMessage = "Do you want to change the maximum location quantity?";
            var actualPopupMessage = MaximumBinQuantityPopup.Instance.GetPopupMessage();
            Assert.AreEqual(expectedPopupMessage, actualPopupMessage,
                "The Message of the maximum bin quantity popup is wrong in Autostore putaway Mission page");
        }

        [When(@"I click on '(.*)' button on maximum bin quantity popup in Autostore putaway Mission page")]
        public void WhenIClickOnButtonOnMaximumBinQuantityPopupInAutostorePutawayMissionPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => MaximumBinQuantityPopup.Instance.ClickYesButton(),
                "No" => MaximumBinQuantityPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on maximum bin quantity popup in Autostore putaway Mission page");
        }

        [Then(@"The Change quantity popup is displayed in Autostore putaway Mission page")]
        public void ThenTheChangeQuantityPopupIsDisplayedInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(ChangeQuantityPopup.Instance.IsPopupDisplayed(),
                "The Change quantity popup is not displayed in Autostore putaway Mission page");

            const string expectedPopupMessage = "Are you sure you want to change the quantity?";
            var actualPopupMessage = ChangeQuantityPopup.Instance.GetPopupMessage();
            Assert.AreEqual(expectedPopupMessage, actualPopupMessage,
                "The Message of the Change quantity popup is wrong in Autostore putaway Mission page");
        }

        [When(@"I click on '(.*)' button on change quantity popup in Autostore putaway Mission page")]
        public void WhenIClickOnButtonOnChangeQuantityPopupInAutostorePutawayMissionPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ChangeQuantityPopup.Instance.ClickYesButton(),
                "No" => ChangeQuantityPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on change quantity popup in Autostore putaway Mission page");
        }

        [Then(@"The Confirm new putaway creation popup is displayed in Autostore putaway Mission page")]
        public void ThenTheConfirmNewPutawayCreationPopupIsDisplayedInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(ConfirmNewPutawayCreationPopup.Instance.IsPopupDisplayed(),
                "The  Confirm new putaway creation popup is not displayed in Autostore putaway Mission page");

            const string expectedPopupMessage = "Do you want to create new putaways for the difference?";
            var actualPopupMessage = ConfirmNewPutawayCreationPopup.Instance.GetPopupMessage();
            Assert.AreEqual(expectedPopupMessage, actualPopupMessage,
                "The Message of the  Confirm new putaway creation popup is wrong in Autostore putaway Mission page");
        }

        [When(@"I click on '(.*)' button on confirm new putaway creation popup in Autostore putaway Mission page")]
        public void WhenIClickOnButtonOnConfirmNewPutawayCreationPopupInAutostorePutawayMissionPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ConfirmNewPutawayCreationPopup.Instance.ClickYesButton(),
                "No" => ConfirmNewPutawayCreationPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on confirm new putaway creation popup in Autostore putaway Mission page");
        }
    }
}
