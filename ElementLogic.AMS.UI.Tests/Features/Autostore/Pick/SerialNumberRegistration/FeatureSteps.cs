using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using TechTalk.SpecFlow;
using SerialNumberRegistrationPage = ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick.SerialNumberRegistration;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SerialNumberRegistration
{
    [Binding]
    public class FeatureSteps
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

        [Then(@"I verify the autostore bin layout is displayed in Autostore Serial Number Registration page is loaded")]
        public void ThenIVerifyTheAutostoreBinLayoutIsDisplayedInAutostoreSerialNumberRegistrationPageIsLoaded()
        {
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsAutostoreBinLayoutDisplayed(),
                "The autostore bin layout is not displayed in Autostore Serial Number Registration page is loaded");
        }

        [Then(@"I verify the name of the serial number scan field is displayed as '(.*)' in Autostore Serial Number Registration page")]
        public void ThenIVerifyTheNameOfTheSerialNumberScanFieldIsDisplayedAsInAutostoreSerialNumberRegistrationPage(string expectedFieldName)
        {
            Assert.AreEqual(expectedFieldName, SerialNumberRegistrationPage.Instance.GetScanFieldLabelValue(),
                $"The name of the serial number scan field is displayed as '{expectedFieldName}' in Autostore Serial Number Registration page");
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
            Assert.AreEqual(expectedValidationMessage, SerialNumberValidationPopup.Instance.GetPopupMessage(),
                "The Serial Number Validation Popup message is wrong in Autostore Serial Number Registration page");
        }


        [When(@"I click on OK button in Serial Number Validation Popup in Autostore Serial Number Registration page")]
        public void WhenIClickOnOKButtonInSerialNumberValidationPopupInAutostoreSerialNumberRegistrationPage()
        {
            Assert.IsTrue(SerialNumberValidationPopup.Instance.ClickOkButton(),
                "Unable to click on OK button in Serial Number Validation Popup in Autostore Serial Number Registration page");
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
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsPreviousSerialNumberScanFieldDisplayed(),
                "The Previous Serial Number scan field is not displayed in Autostore Serial Number Registration page");
            Assert.IsFalse(SerialNumberRegistrationPage.Instance.IsScanFieldDisplayed(),
                "The serial number scan field is displayed in last Autostore Serial Number Registration page");
            Assert.IsTrue(SerialNumberRegistrationPage.Instance.IsLastSerialNumberConfirmLabelDisplayed(),
                "The last serial number confirm label is not displayed in Autostore Serial Number Registration page");
            Assert.AreEqual("Confirm that the last serial number is correct",
                SerialNumberRegistrationPage.Instance.GetLastSerialNumberConfirmLabelTextValue(),
                "The last serial number confirm label text is wrong in Autostore Serial Number Registration page");
        }
    }
}
