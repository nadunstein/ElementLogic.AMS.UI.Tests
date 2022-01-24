using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using TechTalk.SpecFlow;
using SerialNumberRegistrationPage = ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick.SerialNumberRegistration;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SerialNumberRegistration
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"The Autostore Serial Number Registration page is loaded")]
        public void ThenTheAutostoreSerialNumberRegistrationPageIsLoaded()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsPageLoaded(),
                "The Serial Number Registration page is not loaded");
        }

        [Then(@"I verify the quantity field is displayed in Autostore Serial Number Registration page is loaded")]
        public void ThenIVerifyTheQuantityFieldIsDisplayedInAutostoreSerialNumberRegistrationPageIsLoaded()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsQuantityFieldDisplayed(),
                "The quantity field is not displayed in Autostore Serial Number Registration page is loaded");
        }

        [Then(@"I change the quantity of the Quantity field as '(.*)' in Autostore Serial Number Registration page")]
        public void ThenIChangeTheQuantityOfTheQuantityFieldAsInAutostoreSerialNumberRegistrationPage(int quantity)
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.InsertQuantity(quantity.ToString()),
                $"Unable to Change the quantity of the Quantity field as '{quantity}' in Autostore Serial Number Registration page");
        }

        [Then(@"The pick Change Quantity popup is displayed in Autostore Serial Number Registration page")]
        public void ThenThePickChangeQuantityPopupIsDisplayedInAutostoreSerialNumberRegistrationPage()
        {
            Assert.IsTrue(ChangeQuantityPopup.Instance.IsPopupDisplayed(),
                "The pick Change Quantity dialog is not displayed in Autostore Serial Number Registration page");
            Assert.AreEqual("Are you sure you want to change the quantity?",
                ChangeQuantityPopup.Instance.GetPopupMessage(),
                "The message of the pick Change Quantity popup is wrong");
        }

        [When(@"I click on '(.*)' button on Change Quantity popup in Autostore Serial Number Registration page")]
        public void WhenIClickOnButtonOnChangeQuantityPopupInAutostoreSerialNumberRegistrationPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ChangeQuantityPopup.Instance.ClickYesButton(),
                "No" => ChangeQuantityPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Change Quantity popup in Autostore Serial Number Registration page");
        }

        [Then(@"The Empty location popup is displayed in Autostore Serial Number Registration page")]
        public void ThenTheEmptyLocationPopupIsDisplayedInAutostoreSerialNumberRegistrationPage()
        {
            Assert.IsTrue(EmptyLocationPopup.Instance.IsPopupDisplayed(),
                "The Empty location popup is not displayed in Autostore Serial Number Registration page");
            Assert.AreEqual("Is the location empty?",
                EmptyLocationPopup.Instance.GetPopupMessage(),
                "The message of the Empty location popup is wrong");
        }

        [When(@"I click on '(.*)' button on Empty location popup in Autostore Serial Number Registration page")]
        public void WhenIClickOnButtonOnEmptyLocationPopupInAutostoreSerialNumberRegistrationPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => EmptyLocationPopup.Instance.ClickYesButton(),
                "No" => EmptyLocationPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Empty location popup in Autostore Serial Number Registration page");
        }

        [Then(@"I verify the autostore bin layout is displayed in Autostore Serial Number Registration page is loaded")]
        public void ThenIVerifyTheAutostoreBinLayoutIsDisplayedInAutostoreSerialNumberRegistrationPageIsLoaded()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsAutostoreBinLayoutDisplayed(),
                "The autostore bin layout is not displayed in Autostore Serial Number Registration page is loaded");
        }

        [Then(@"I verify the name of the serial numbers panel is displayed as '(.*)' in Autostore Serial Number Registration page")]
        public void ThenIVerifyTheNameOfTheSerialNumbersPanelIsDisplayedAsInAutostoreSerialNumberRegistrationPage(string expectedFieldName)
        {
            Assert.AreEqual(expectedFieldName, SerialNumberRegistrationPage.Instance.GetScanFieldLabelValue(),
                $"The name of the serial number scan field is displayed as '{expectedFieldName}' in Autostore Serial Number Registration page");
        }

        [Then(@"I verify the name of the serial number scan fields are correct in the on serial numbers panel in Autostore Serial Number Registration page")]
        public void ThenIVerifyTheNameOfTheSerialNumberScanFieldsAreCorrectInTheOnSerialNumbersPanelInAutostoreSerialNumberRegistrationPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I include the serial number scan value as '(.*)' to serial number scan field in Autostore Serial Number Registration page")]
        public void ThenIIncludeTheSerialNumberScanValueAsToSerialNumberScanFieldInAutostoreSerialNumberRegistrationPage(string serialNumber)
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.InsertScanValue(serialNumber),
                "Unable to include the serial number scan value to serial number scan field in Autostore Serial Number Registration page");
        }

        [Then(@"I update the previously scanned serial number as '(.*)' in Autostore Serial Number Registration page")]
        public void ThenIUpdateThePreviouslyScannedSerialNumberAsInAutostoreSerialNumberRegistrationPage(string serialNumberToBeUpdated)
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.InsertPreviousScanValue(serialNumberToBeUpdated),
                $"Unable to update the previously scanned serial number  as '{serialNumberToBeUpdated}' in Autostore Serial Number Registration page");
        }

        [When(@"I click on Update button in Autostore Serial Number Registration page")]
        public void WhenIClickOnUpdateButtonInAutostoreSerialNumberRegistrationPage()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.ClickUpdateButton(),
                "Unable to click on Update button in Autostore Serial Number Registration page");
        }

        [Then(@"The successfully updated serial number notification is displayed in Autostore Serial Number Registration page")]
        public void ThenTheSuccessfullyUpdatedSerialNumberNotificationIsDisplayedInAutostoreSerialNumberRegistrationPage()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IstUpdateSuccessNotificationDisplayed(),
                "The successfully updated serial number notification is not displayed in Autostore Serial Number Registration page");
            Assert.AreEqual("Serial number is successfully updated",
                SerialNumberRegistrationPage.Instance.GetUpdateSuccessNotificationMessage(),
                "The successfully updated serial number notification message is wrong in Autostore Serial Number Registration page");
        }

        [When(@"I click on the Confirm button in Autostore Serial Number Registration page")]
        public void WhenIClickOnTheConfirmButtonInAutostoreSerialNumberRegistrationPage()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.ClickConfirmButton(),
                "Unable to click on the Confirm button in Autostore Serial Number Registration page");
        }

        [Then(@"The '(.*)' validation Popup is displayed in Autostore Serial Number Registration page")]
        public void ThenTheValidationPopupIsDisplayedInAutostoreSerialNumberRegistrationPage(string expectedValidationMessage)
        {
            Assert.IsTrue(SerialNumberValidationPopup.Instance.IsPopupDisplayed(),
                "The serial number validation popup is not displayed in Autostore Serial Number Registration page");
            Assert.AreEqual(expectedValidationMessage, SerialNumberValidationPopup.Instance.GetPopupMessage(),
                "The Serial Number Validation Popup message is wrong in Autostore Serial Number Registration page");
        }

        [Then(@"The Edit Previous Autostore Serial Number Registration page is loaded")]
        public void ThenTheEditPreviousAutostoreSerialNumberRegistrationPageIsLoaded()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsPageLoaded(),
                "The Edit Autostore Serial Number Registration page is not loaded");
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsPreviousSerialNumberScanFieldDisplayed(),
                "The Previous Serial Number scan field is not displayed in Autostore Serial Number Registration page");
        }

        [Then(@"The Edit last Autostore Serial Number Registration page is loaded")]
        public void ThenTheEditLastAutostoreSerialNumberRegistrationPageIsLoaded()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsPageLoaded(),
                "The Edit last Autostore Serial Number Registration page is not loaded");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsPreviousSerialNumberScanFieldDisplayed(),
                    "The Previous Serial Number scan field is not displayed in Autostore Serial Number Registration page");
                Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsScanFieldNotDisplayed(),
                    "The serial number scan field is displayed in last Autostore Serial Number Registration page");
                Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsLastSerialNumberConfirmLabelDisplayed(),
                    "The last serial number confirm label is not displayed in Autostore Serial Number Registration page");
                Assert.AreEqual("Confirm that the last serial number is correct",
                    SerialNumberRegistrationPage.Instance.GetLastSerialNumberConfirmLabelTextValue(),
                    "The last serial number confirm label text is wrong in Autostore Serial Number Registration page");
            });
        }
    }
}
