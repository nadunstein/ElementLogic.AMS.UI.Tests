using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inventory.InventoryHandlingUnit
{
    [Binding]
    public sealed class FeatureSteps
    {
        private string _scannedHandlingUnit, _handlingUnitPhysicallyNotInTheBinLocation;

        [Then(@"I include the Handling unit scan code as '(.*)' to the Handling unit scan code field in Autostore inventory mission page")]
        public void ThenIIncludeTheHandlingUnitScanCodeAsToTheHandlingUnitScanCodeFieldInAutostoreInventoryMissionPage(string handlingUnitScanCode)
        {
            _scannedHandlingUnit = handlingUnitScanCode;
            Assert.IsTrue(InventoryMission.Instance.InsertHandlingUnitScanCode(handlingUnitScanCode),
                $"Unable to include the Handling unit scan code as {handlingUnitScanCode} to the Handling unit scan code field in Autostore inventory mission page");
        }

        [Then(@"I scan all the Handling units except one in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page")]
        public void ThenIScanAllTheHandlingUnitsExceptOneInTheBinToTheHandlingUnitScanCodeFieldAndConfirmQuantityInAutostoreInventoryMissionPage()
        {
            var inventoryBinLocationForCurrentBin = InventoryMission.Instance.GetAutoStoreLocationLabelValue();
            var handlingUnitsInBonLocation =
                Data.DatabaseQueries.Inventory.Instance.GetFirstHandlingUnitsForLocation(
                    inventoryBinLocationForCurrentBin);
            for (var i = 1; i < handlingUnitsInBonLocation.Count; i++)
            {
                Assert.IsTrue(InventoryMission.Instance.InsertHandlingUnitScanCode(handlingUnitsInBonLocation[i - 1]),
                    $"Unable to include the Handling unit scan code as {handlingUnitsInBonLocation[i - 1]} to the Handling unit scan code field in Autostore inventory mission page");
                Assert.IsTrue(InventoryMission.Instance.ClickConfirmButton(),
                    "Unable to click on Confirm button in Autostore inventory mission page");
                Assert.IsTrue(InventoryMission.Instance.IsHandlingUnitQuantityFieldDisplayed(),
                    "The Handling Unit quantity field is NOT displayed in Autostore inventory mission page");
                Assert.IsTrue(InventoryMission.Instance.ClickConfirmButton(),
                    "Unable to click on Confirm button in Autostore inventory mission page");
            }

            _handlingUnitPhysicallyNotInTheBinLocation =
                handlingUnitsInBonLocation[handlingUnitsInBonLocation.Count - 1];
        }

        [Then(@"I scan all the Handling units in the bin to the Handling unit scan code field and confirm quantity in Autostore inventory mission page")]
        public void ThenIScanAllTheHandlingUnitsInTheBinToTheHandlingUnitScanCodeFieldAndConfirmQuantityInAutostoreInventoryMissionPage()
        {
            var inventoryBinLocationForCurrentBin = InventoryMission.Instance.GetAutoStoreLocationLabelValue();
            var handlingUnitsInBonLocation =
                Data.DatabaseQueries.Inventory.Instance.GetFirstHandlingUnitsForLocation(
                    inventoryBinLocationForCurrentBin);
            foreach (var handlingUnitInBonLocation in handlingUnitsInBonLocation)
            {
                Assert.IsTrue(InventoryMission.Instance.InsertHandlingUnitScanCode(handlingUnitInBonLocation),
                    $"Unable to include the Handling unit scan code as {handlingUnitInBonLocation} to the Handling unit scan code field in Autostore inventory mission page");
                Assert.IsTrue(InventoryMission.Instance.ClickConfirmButton(),
                    "Unable to click on Confirm button in Autostore inventory mission page");
                Assert.IsTrue(InventoryMission.Instance.IsHandlingUnitQuantityFieldDisplayed(),
                    "The Handling Unit quantity field is NOT displayed in Autostore inventory mission page");
                Assert.IsTrue(InventoryMission.Instance.ClickConfirmButton(),
                    "Unable to click on Confirm button in Autostore inventory mission page");
            }
        }

        [Then(@"I include the Handling unit which was missing in previous bin to the Handling unit scan code field in Autostore inventory mission page")]
        public void ThenIIncludeTheHandlingUnitWhichWasMissingInPreviousBinToTheHandlingUnitScanCodeFieldInAutostoreInventoryMissionPage()
        {
            _scannedHandlingUnit = _handlingUnitPhysicallyNotInTheBinLocation;
            Assert.IsTrue(
                InventoryMission.Instance.InsertHandlingUnitScanCode(_handlingUnitPhysicallyNotInTheBinLocation),
                $"Unable to include the Handling unit scan code as {_handlingUnitPhysicallyNotInTheBinLocation} to the Handling unit scan code field in Autostore inventory mission page");
        }

        [Then(@"The Handling Unit quantity field is displayed in Autostore inventory mission page")]
        public void ThenTheHandlingUnitQuantityFieldIsDisplayedInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(InventoryMission.Instance.IsHandlingUnitQuantityFieldDisplayed(),
                "The Handling Unit quantity field is NOT displayed in Autostore inventory mission page");
        }

        [Then(@"I verify the confirmed handling unit is displayed as '(.*)' in Autostore inventory mission page")]
        public void ThenIVerifyTheConfirmedHandlingUnitIsDisplayedAsInAutostoreInventoryMissionPage(string expectedHandlingUnitScanCode)
        {
            Assert.AreEqual(expectedHandlingUnitScanCode, InventoryMission.Instance.GetHandlingUnitScanCodeConfirmedText(),
                "The quantity field is NOT displayed in Autostore inventory mission page");
        }

        [Then(@"I verify the Location Complete button is disable in Autostore inventory mission page")]
        public void ThenIVerifyTheLocationCompleteButtonIsDisableInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(InventoryMission.Instance.IsLocationCompleteButtonDisable(),
                "The Location Complete button is NOT disable in Autostore inventory mission page");
        }

        [Then(@"I include the Handling Unit quantity as '(.*)' to the Location quantity field in Autostore inventory mission page")]
        public void ThenIIncludeTheHandlingUnitQuantityAsToTheLocationQuantityFieldInAutostoreInventoryMissionPage(int quantity)
        {
            Assert.IsTrue(InventoryMission.Instance.InsertHandlingUnitQuantity(quantity),
                $"Unable to include the Handling Unit quantity as {quantity} to the Location quantity field in Autostore inventory mission page");
        }

        [Then(@"The Unexpected Handling Unit popup is displayed in Autostore inventory mission page")]
        public void ThenTheUnexpectedHandlingUnitPopupIsDisplayedInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(UnexpectedHandlingUnitsPopup.Instance.IsPopupDisplayed(),
                "The Unexpected Handling Unit popup is NOT displayed in Autostore inventory mission page");
            Assert.AreEqual("The handling unit was unexpected", UnexpectedHandlingUnitsPopup.Instance.GetFirstPopupMessage(),
                "The first popup message is WRONG on Unexpected Handling Unit popup in Autostore inventory mission page");
            Assert.AreEqual($"The handling unit '{_scannedHandlingUnit} is not known by the system.", 
                UnexpectedHandlingUnitsPopup.Instance.GetSecondPopupMessage(),
                "The second popup message is WRONG on Unexpected Handling Unit popup in Autostore inventory mission page");
        }

        [When(@"I click on '(.*)' button on Unexpected Handling Unit popup in Autostore inventory mission page")]
        public void WhenIClickOnButtonOnUnexpectedHandlingUnitPopupInAutostoreInventoryMissionPage(string buttonToBeClicked)
        {
            Assert.IsTrue(UnexpectedHandlingUnitsPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to click on '{buttonToBeClicked}' button on Unexpected Handling Unit popup in Autostore inventory mission page");
        }

        [Then(@"The Handling Unit Enter Quantity popup is displayed in Autostore inventory mission page")]
        public void ThenTheHandlingUnitEnterQuantityPopupIsDisplayedInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(HandlingUnitEnterQuantityPopup.Instance.IsPopupDisplayed(),
                "The Handling Unit Enter Quantity popup is NOT displayed in Autostore inventory mission page");
            Assert.AreEqual($"Please enter the quantity for Handling Unit '{_scannedHandlingUnit}'", 
                HandlingUnitEnterQuantityPopup.Instance.GetPopupMessage(),
                "The popup message is WRONG on Handling Unit Enter Quantity popup in Autostore inventory mission page");
        }

        [Then(@"I include the Handling Unit quantity as '(.*)' to the quantity field on Handling Unit Enter Quantity popup in Autostore inventory mission page")]
        public void ThenIIncludeTheHandlingUnitQuantityAsToTheQuantityFieldOnHandlingUnitEnterQuantityPopupInAutostoreInventoryMissionPage(int handlingUnitQuantity)
        {
            Assert.IsTrue(HandlingUnitEnterQuantityPopup.Instance.InsertHandlingUnitQuantity(handlingUnitQuantity),
                $"Unable to include the Handling Unit quantity as '{handlingUnitQuantity}' to the quantity field on Handling Unit Enter Quantity popup in Autostore inventory mission page");
        }

        [When(@"I click on Confirm button on Handling Unit Enter Quantity popup in Autostore inventory mission page")]
        public void WhenIClickOnConfirmButtonOnHandlingUnitEnterQuantityPopupInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(HandlingUnitEnterQuantityPopup.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button on Handling Unit Enter Quantity popup in Autostore inventory mission page");
        }

        [When(@"I click on Location Complete button in Autostore inventory mission page")]
        public void WhenIClickOnLocationCompleteButtonInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(InventoryMission.Instance.ClickLocationCompleteButton(),
                "Unable to click on Location Complete button in Autostore inventory mission page");
        }

        [Then(@"The Handling Units Missing popup is displayed in Autostore inventory mission page")]
        public void ThenTheHandlingUnitsMissingPopupIsDisplayedInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(HandlingUnitsMissingPopup.Instance.IsPopupDisplayed(),
                "The Handling Units Missing popup is NOT displayed in Autostore inventory mission page");
            Assert.AreEqual("Missing Handling Units expected by eManager", HandlingUnitsMissingPopup.Instance.GetFirstPopupMessage(),
                "The first popup message is WRONG on Handling Units Missing popup in Autostore inventory mission page");
            Assert.AreEqual("The following Handling Units were expected to be found in this location. If you click the Confirm Missing button, they will be deleted from eManager.",
                HandlingUnitsMissingPopup.Instance.GetSecondPopupMessage(),
                "The second popup message is WRONG on Handling Units Missing popup in Autostore inventory mission page");
        }

        [Then(@"The Handling Units Missing popup is displayed in Autostore inventory mission page with following details")]
        public void ThenTheHandlingUnitsMissingPopupIsDisplayedInAutostoreInventoryMissionPageWithFollowingDetails(Table table)
        {
            Assert.IsTrue(HandlingUnitsMissingPopup.Instance.IsPopupDisplayed(),
                "The Handling Units Missing popup is NOT displayed in Autostore inventory mission page");
            Assert.AreEqual("Missing Handling Units expected by eManager", HandlingUnitsMissingPopup.Instance.GetFirstPopupMessage(),
                "The first popup message is WRONG on Handling Units Missing popup in Autostore inventory mission page");
            Assert.AreEqual("The following Handling Units were expected to be found in this location. If you click the Confirm Missing button, they will be deleted from eManager.",
                HandlingUnitsMissingPopup.Instance.GetSecondPopupMessage(),
                "The second popup message is WRONG on Handling Units Missing popup in Autostore inventory mission page");
            var handlingUnits = table.CreateDynamicSet();
            foreach (var handlingUnit in handlingUnits)
            {
                Assert.True(
                    HandlingUnitsMissingPopup.Instance.IsHandlingUnitRecordExists(handlingUnit.HandlingUnitScanCode),
                    $"There is no record of the handling unit '{handlingUnit.HandlingUnitScanCode}' in the table on Handling Units Missing popup in Autostore inventory mission page");
                Assert.AreEqual(handlingUnit.Quantity,
                    HandlingUnitsMissingPopup.Instance.GetHandlingUnitQuantity(handlingUnit.HandlingUnitScanCode),
                    $"The '{handlingUnit.HandlingUnitScanCode}' Handling Unit quantity is wrong in the table on Handling Units Missing popup in Autostore inventory mission page");
            }
        }

        [When(@"I click on '(.*)' button on Handling Units Missing popup in Autostore inventory mission page")]
        public void WhenIClickOnButtonOnHandlingUnitsMissingPopupInAutostoreInventoryMissionPage(string buttonToBeClicked)
        {
            Assert.IsTrue(HandlingUnitsMissingPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to click {buttonToBeClicked} button on Handling Units Missing popup in Autostore inventory mission page");
        }
    }
}
