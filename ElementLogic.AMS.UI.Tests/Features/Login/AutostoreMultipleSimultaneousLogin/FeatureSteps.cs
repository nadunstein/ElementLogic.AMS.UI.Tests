using ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Login.AutostoreMultipleSimultaneousLogin
{
    [Binding]
    public class AutostoreMultiplePortsSimultaneousLoginSteps
    {
        [Then(@"The Duplicate login confirmation popup is displayed in Autostore Task Menu Page")]
        public void ThenTheDuplicateLoginConfirmationPopupIsDisplayedInAutostoreTaskMenuPage()
        {
            Assert.IsTrue(DuplicateLoginConfirmationPopup.Instance.IsPopupDisplayed(),
                "The Duplicate login confirmation popup is not displayed in Autostore Task Menu Page");
            const string expectedPopupMessage =
                "You are already logged into port(s) 03!\r\n\r\nAre you sure you want to log into port 04 as well?";
            Assert.AreEqual(expectedPopupMessage, DuplicateLoginConfirmationPopup.Instance.GetPopupMessage(),
                "The Duplicate login confirmation popup message is wrong in Autostore Task Menu Page");
        }

        [When(@"I click on '(.*)' button on Duplicate login confirmation popup in Autostore Task Menu Page")]
        public void WhenIClickOnButtonOnDuplicateLoginConfirmationPopupInAutostoreTaskMenuPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => DuplicateLoginConfirmationPopup.Instance.ClickYesButton(),
                "No" => DuplicateLoginConfirmationPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Duplicate login confirmation popup in Autostore Task Menu Page");
        }
    }
}
