using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using System.Globalization;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick
{
    [Binding]
    public class CommonSteps
    {
        private string _addedNewContainer;
        private readonly ScenarioContext _scenarioContext;

        [Then(@"The Autostore pick mission '(.*)' is loaded")]
        public void ThenTheAutostorePickMissionIsLoaded(int missionNumber)
        {
            Assert.IsTrue(PickMission.Instance.IsPageLoaded(),
                $"Autostore Pick mission {missionNumber} page is not loaded");
            Assert.IsTrue(PickMission.Instance.GetTaskQueueValue().Contains($"Task {missionNumber} of"),
                $"The Autostore Pick mission {missionNumber} is not loaded");

            _scenarioContext["task_id"] = PickMission.Instance.GetMissionIdValue();
            var splitLocationId = PickMission.Instance.GetPickLocation().Split(new char[] { '-' });
            _scenarioContext["bin_id"] = splitLocationId[1];
            _scenarioContext["ExtProductId"] = PickMission.Instance.GetProductNumber();
            _scenarioContext["TotalQuantity"] = (_scenarioContext.ContainsKey("TotalQuantity")
                ? (int) _scenarioContext["TotalQuantity"]
                : 0) + PickMission.Instance.GetPickQuantityFieldValue();
        }

        [Then(@"The new order popup is displayed in Autostore Pick Mission page")]
        public void ThenTheNewOrderPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(NewOrderPopup.Instance.IsPopupDisplayed(),
                "The new order popup is not displayed in Autostore Pick Mission page");
        }

        [When(@"I click OK button on new order popup in Autostore Pick Mission page")]
        public void WhenIClickOkButtonOnNewOrderPopupInAutostorePickMissionPage()
        {
            Assert.IsTrue(NewOrderPopup.Instance.ClickOkButton(),
                "Unable to click OK button on new order popup in Autostore Pick Mission page");
        }

        [Then(@"I verify the Quantity field value is '(.*)' in Autostore Pick Mission page")]
        public void ThenIVerifyTheQuantityFieldValueIsInAutostorePickMissionPage(int expectedPickQuantity)
        {
            var pickQuantityFieldValue = PickMission.Instance.GetPickQuantityFieldValue();
            Assert.AreEqual(expectedPickQuantity, pickQuantityFieldValue,
                "THe Expected pick quantity field is value is wrong in Autostore Pick Mission page");
        }

        [Then(@"I add '(.*)' container by clicking on New Container button in Autostore Pick Mission page")]
        public void ThenIAddContainerByClickingOnNewContainerButtonInAutostorePickMissionPage(string boxType)
        {
            _addedNewContainer = boxType;
            Assert.IsTrue(PickMission.Instance.SelectContainer(boxType),
                $"Unable to add '{boxType}' container by clicking on New Container button in Autostore Pick Mission page");
        }

        [Then(@"The successfully added a new container notification is displayed in Autostore Pick Mission page")]
        public void ThenTheSuccessfullyAddedANewContainerNotificationIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.IsAddNewContainerNotificationDisplayed(),
                "The successfully added a new container notification is not displayed in Autostore Pick Mission page");
            var addNewContainerNotification = PickMission.Instance.GetAddNewContainerNotificationTextValue();
            Assert.AreEqual($"A new container added successfully ({_addedNewContainer})", addNewContainerNotification,
                "The successfully added a new container notification is wrong in Autostore Pick Mission page");
        }

        [Then(@"I include the product scan value to scan field in Autostore Pick Mission page")]
        public void ThenIIncludeTheProductScanValueToScanFieldInAutostorePickMissionPage()
        {
            var productScanValue =
                Parameter.Instance.GetParameterData("AutoStore.Picking.Scanning.ValidateProduct").ParameterValue.Contains("1")
                    ? PickMission.Instance.GetProductNumber()
                    : PickMission.Instance.GetPickLocation();

            Assert.IsTrue(PickMission.Instance.InsertProductScanValue(productScanValue),
                "Unable to include the product scan value to scan field in Autostore Pick Mission page");
        }

        [Then(@"I verify the container scan field is displayed in Autostore Pick Mission page")]
        public void ThenIVerifyTheContainerScanFieldIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.IsContainerScanFieldDisplayed(),
                "The container scan field is not displayed in Autostore Pick Mission page");
        }

        [Then(@"I verify the container scan field is not displayed in Autostore Pick Mission page")]
        public void ThenIVerifyTheContainerScanFieldIsNotDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.IsContainerScanFieldNotDisplayed(),
                "The container scan field is displayed in Autostore Pick Mission page");
        }

        [Then(@"I include the container scan value as '(.*)' to the container scan field in Autostore Pick Mission page")]
        public void ThenIIncludeTheContainerScanValueAsToTheContainerScanFieldInAutostorePickMissionPage(string containerScanCode)
        {
            if (containerScanCode == "Empty")
            {
                containerScanCode = string.Empty;
            }

            Assert.IsTrue(PickMission.Instance.InsertContainerScanValue(containerScanCode),
                $"Unable to include the container scan value as '{containerScanCode}' to the container scan field in Autostore Pick Mission page");
        }

        [When(@"I click on the confirm button in Autostore Pick Mission page")]
        public void WhenIClickOnTheConfirmButtonInAutostorePickMissionPage()
        {
            var quantityFieldValue = PickMission.Instance.GetPickQuantityFieldValue().ToString();
            var productId = PickMission.Instance.GetProductNumber();
            var pickLocationBinId = PickMission.Instance.GetPickLocation();
            var actLocationQuantity = ProductLocation.Instance.GetLocationQuantity(pickLocationBinId, productId)
                .ToString(CultureInfo.CurrentCulture);

            if (quantityFieldValue == actLocationQuantity)
            {
                _scenarioContext["IsZeroQuantityConfirmationPopupNeedToBeDisplayed"] = true; 
            }

            Assert.IsTrue(PickMission.Instance.ClickConfirmButton(),
                "Unable to click on the confirm button in Autostore Pick Mission page");
        }

        [Then(@"The possible delay notification is displayed in Autostore Pick Mission page")]
        public void ThenThePossibleDelayNotificationIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.IsPossibleDelayLabelDisplayed(),
                "The possible delay notification is not displayed in Autostore Pick Mission page");
        }

        [Then(@"The '(.*)' Validation message is displayed in AutoStore Pick Mission page")]
        public void ThenTheValidationMessageIsDisplayedInAutostorePickMissionPage(string expectedValidationMessage)
        {
            Assert.IsTrue(ContainerValidationPopup.Instance.IsPopupDisplayed(),
                "The container validation popup is not displayed in AutoStore Pick Mission page");
            Assert.IsTrue(ContainerValidationPopup.Instance.GetPopupMessage().Contains(expectedValidationMessage),
                "The container validation popup message is wrong in AutoStore Pick Mission page");
        }

        [Then(@"The '(.*)' Validation message is displayed in Autostore Place in Container page")]
        public void ThenTheValidationMessageIsDisplayedInAutostorePlaceInContainerPage(string expectedValidationMessage)
        {
            Assert.IsTrue(ContainerValidationPopup.Instance.IsPopupDisplayed(),
                "The container validation popup is not displayed in AutoStore Place in Container page");
            Assert.IsTrue(ContainerValidationPopup.Instance.GetPopupMessage().Contains(expectedValidationMessage),
                "The container validation popup message is wrong in utoStore Place in Container page");
        }

        [Then(@"I click on OK button in container validation popup in AutoStore Pick Mission page")]
        public void ThenIClickOnOKButtonInContainerValidationPopupInAutostorePickMissionPage()
        {
            Assert.IsTrue(ContainerValidationPopup.Instance.ClickOkButton(),
                "Unable to click on OK button in container validation popup in AutoStore Pick Mission page");
        }

        [Then(@"I click on OK button in container validation popup in AutoStore Place in Container page")]
        public void ThenIClickOnOKButtonInContainerValidationPopupInAutostorePlaceInContainerPage()
        {
            Assert.IsTrue(ContainerValidationPopup.Instance.ClickOkButton(),
                "Unable to click on OK button in container validation popup in AutoStore Place in Container page");
        }

        [Then(@"The AutoStore Place in Container page is loaded")]
        public void ThenTheAutoStorePlaceInContainerPageIsLoaded()
        {
            Assert.IsTrue(PlaceInContainer.Instance.IsPageLoaded(),
                "The AutoStore Place in Container page is not loaded");
        }

        [Then(@"I verify the Quantity field value is '(.*)' in Autostore Place in Container page")]
        public void ThenIVerifyTheQuantityFieldValueIsInAutostorePlaceInContainerPage(int expectedPickQuantity)
        {
            var placeQuantityFieldValue = PlaceInContainer.Instance.GetQuantityFieldValue();
            Assert.AreEqual(expectedPickQuantity, placeQuantityFieldValue,
                "THe Expected pick quantity field is value is wrong in Autostore Pick Mission page");
        }

        [Then(@"I change the quantity of the Quantity field as '(.*)' in Autostore Place in Container page")]
        public void ThenIChangeTheQuantityOfTheQuantityFieldAsInAutostorePlaceInContainerPage(int newQuantity)
        {
            Assert.IsTrue(PlaceInContainer.Instance.InsertQuantity(newQuantity),
                $"Unable to change the quantity of the Quantity field as '{newQuantity}' in Autostore Place in Container page");
        }

        [When(@"I click on '(.*)' option item in Autostore Pick Mission page")]
        public void WhenIClickOnOptionItemInAutostorePickMissionPage(string optionToBeSelected)
        {
            Assert.IsTrue(PickMission.Instance.SelectOption(optionToBeSelected),
                $"Unable to click on '{optionToBeSelected}' option item in Autostore Pick Mission page");
        }

        [Then(@"The Add new container popup is displayed in Autostore Pick Mission page")]
        public void TheThenAddNewContainerPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.IsPopupDisplayed(),
                "The Add new container popup is not displayed in AutoStore Place in Container page");
        }

        [Then(@"The Add new container popup is displayed in AutoStore Place in Container page")]
        public void TheThenAddNewContainerPopupIsDisplayedInAutostorePlaceInContainerPage()
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.IsPopupDisplayed(),
                "The Add new container popup is not displayed in AutoStore Place in Container page");
        }

        [Then(@"I select the boxtype as '(.*)' from container selection list in Add new container popup in Autostore Pick Mission page")]
        public void ThenISelectTheBoxtypeAsFromContainerSelectionListInAddNewContainerPopupInAutostorePickMissionPage(string boxType)
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.SelectContainerFromTheList(boxType),
                $"Unable to select the boxtype as '{boxType}' from container selection list in Add new container popup in Autostore Pick Mission page");
        }

        [Then(@"I select the boxtype as '(.*)' from box type selection dropdown in Add new container popup in Autostore Pick Mission page")]
        public void ThenISelectTheBoxtypeAsFromBoxTypeSelectionDropdownInAddNewContainerPopupInAutostorePickMissionPage(string boxTypeToBeSelected)
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.SelectBoxType(boxTypeToBeSelected),
                $"Unable to select the boxtype as '{boxTypeToBeSelected}' from box type selection dropdown in Add new container popup in Autostore Pick Mission page");
        }

        [When(@"I click on '(.*)' button on Add new container popup in Autostore Pick Mission page")]
        public void WhenIClickOnButtonOnAddNewContainerPopupInAutostoreMissionPage(string buttonToBeClicked)
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to Click on {buttonToBeClicked} button on Add new container popup in Autostore Pick Mission page");
        }

        [When(@"I click on '(.*)' button on Add new container popup in AutoStore Place in Container page")]
        public void WhenIClickOnButtonOnAddNewContainerPopupInAutostorePlaceInContainerPage(string buttonToBeClicked)
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to Click on {buttonToBeClicked} button on Add new container popup in AutoStore Place in Container page");
        }

        [Then(@"I include the container scan value as '(.*)' to the container scan field in Add new container popup in Autostore Pick Mission page")]
        public void ThenIIncludeTheContainerScanValueAsToTheContainerScanFieldInAddNewContainerPopupInAutostorePickMissionPage(string containerScanCode)
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.InsertContainerScanCode(containerScanCode),
                $"Unable to include the container scan value as '{containerScanCode}' to the container scan field in Add new container popup in Autostore Pick Mission page");
        }

        [Then(@"The container validation popup is displayed in Add new container popup in AutoStore Pick Mission page")]
        public void ThenTheContainerValidationPopupIsDisplayedInAddNewContainerPopupInAutoStorePickMissionPage()
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.IsContainerValidationPopupDisplayed(),
                "The container validation popup is not displayed in Add new container popup in AutoStore Pick Mission page");
            var containerScanFieldValue = AddNewContainerPopup.Instance.GetScanCodeFieldValue();
            var expectedValidationMessage = $"Scanned container ID ({containerScanFieldValue}) is invalid.";
            Assert.AreEqual(expectedValidationMessage, AddNewContainerPopup.Instance.GetValidationPopupMessage(),
                "The container validation popup message is wrong in Add new container popup in AutoStore Pick Mission page");
        }

        [Then(@"I click on OK button in container validation popup in Add new container popup in AutoStore Place in Container page")]
        public void ThenIClickOnOKButtonInContainerValidationPopupInAddNewContainerPopupInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.ClickValidationPopupOkButton(),
                "Unable to click on OK button in container validation popup in Add new container popup in AutoStore Place in Container page");
        }

        [Then(@"I verify the Add button is Disable in Add new container popup in Autostore Pick Mission page")]
        public void ThenIVerifyTheAddButtonIsDisableInAddNewContainerPopupInAutostorePickMissionPage()
        {
            Assert.IsFalse(AddNewContainerPopup.Instance.IsAddButtonEnable(),
                "The Add button is not Disable in Add new container popup in Autostore Pick Mission page");
        }

        [Then(@"I verify the scancode field is not displayed in Add new container popup in Autostore Pick Mission page")]
        public void ThenIVerifyTheScancodeFieldIsNotDisplayedInAddNewContainerPopupInAutostorePickMissionPage()
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.IsScanCodeFieldNotDisplayed(),
                "The scancode field is displayed in Add new container popup in Autostore Pick Mission page");
        }

        [Then(@"I verify the scancode field value is displayed as '(.*)' in Add new container popup in Autostore Pick Mission page")]
        public void ThenIVerifyTheScancodeFieldValueIsDisplayedAsInAddNewContainerPopupInAutostorePickMissionPage(string containerScanCode)
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.IsScanCodeFieldDisplayed(),
                "The scancode field is not displayed in Add new container popup in Autostore Pick Mission page");
            var actualContainerScanCode = AddNewContainerPopup.Instance.GetScanCodeFieldValue();
            Assert.AreEqual(containerScanCode, actualContainerScanCode,
                "The Container scancode is different in Add new container popup in Autostore Pick Mission page");
        }

        [Then(@"I verify the scan field is displayed in AutoStore Place in Container page")]
        public void ThenIVerifyTheScanFieldIsDisplayedInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(PlaceInContainer.Instance.IsScanFieldDisplayed(),
                "The scan field is not displayed in AutoStore Place in Container page");
        }

        [Then(@"I verify the focus is on the scan value field in AutoStore Place in Container page")]
        public void ThenIVerifyTheFocusIsOnTheScanValueFieldInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(PlaceInContainer.Instance.IsScanFieldFocused(),
                "The focus is not on the scan value field in AutoStore Place in Container page");
        }

        [Then(@"I include the container scan value to scan value field in AutoStore Place in Container page")]
        public void ThenIIncludeTheContainerScanValueToScanValueFieldInAutoStorePlaceInContainerPage()
        {
            var containerScanValue = PlaceInContainer.Instance.GetBoxNumber();
            Assert.IsTrue(PlaceInContainer.Instance.InsertScanValue(containerScanValue),
                "Unable to include the container scan value to scan value field in AutoStore Place in Container page");
        }

        [Then(@"I include the container scan value as '(.*)' to the container scan field in Autostore Place in Container page")]
        public void ThenIIncludeTheContainerScanValueAsToTheContainerScanFieldInAutostorePlaceInContainerPage(string containerScanCode)
        {
            Assert.IsTrue(PlaceInContainer.Instance.InsertScanValue(containerScanCode),
                $"Unable to include the container scan value as '{containerScanCode}' to the container scan field in Autostore Place in Container page");
        }

        [When(@"I click on the Confirm button in AutoStore Place in Container page")]
        public void WhenIClickOnTheConfirmButtonInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(PlaceInContainer.Instance.ClickConfirmButton(),
                "Unable to click on the Confirm button in  AutoStore Place in Container page");
        }

        [Then(@"The taskgroup completed popup is displayed in Autostore Pick Mission page")]
        public void ThenTheTaskgroupCompletedPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(TaskgroupCompletedPopup.Instance.IsPopupDisplayed(),
                "The taskgroup completed popup is not displayed in Autostore Pick Mission page");
            Assert.AreEqual("The task group has been completed!", TaskgroupCompletedPopup.Instance.GetPopupMessage(),
                "The taskgroup completed popup message is wrong in Autostore Pick Mission page");
        }

        [When(@"I click on '(.*)' button on taskgroup completed popup in Autostore Pick Mission page")]
        public void WhenIClickOnButtonOnTaskgroupCompletedPopupInAutostorePickMissionPage(string buttonToBeClicked)
        {
            Assert.IsTrue(TaskgroupCompletedPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to Click on {buttonToBeClicked} button on taskgroup completed popup in Autostore Pick Mission page");
        }

        [When(@"I click on Exit button in Autostore Place in Container page")]
        public void WhenIClickOnExitButtonInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(PlaceInContainer.Instance.ClickExitButton(),
                "Unable to click on Exit button in Autostore Pick Mission page");
        }

        [When(@"I click on Exit button in Autostore Pick Mission page")]
        public void WhenIClickOnExitButtonInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.ClickExitButton(),
                "Unable to click on Exit button in Autostore Pick Mission page");
        }

        [Then(@"The Confirm Task Exit popup is displayed in Autostore Pick Mission page")]
        public void ThenTheConfirmTaskExitPopupIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(ConfirmTaskExitPopup.Instance.IsPopupDisplayed(),
                "The Confirm Task Exit popup is not displayed in Autostore Pick Mission page");
            const string expectedMessage =
                "If you exit, the current task group will be suspended!\r\n\r\nAre you sure you want to exit?";
            Assert.AreEqual(expectedMessage, ConfirmTaskExitPopup.Instance.GetPopupMessage(),
                "Confirm Task Exit popup message is wrong in Autostore Pick Mission page");
        }

        [When(@"I click on '(.*)' button on Confirm Task Exit popup in Autostore Pick Mission page")]
        public void WhenIClickOnButtonOnConfirmTaskExitPopupInAutostorePickMissionPage(string buttonToBeClicked)
        {
            Assert.IsTrue(ConfirmTaskExitPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to Click on {buttonToBeClicked} button on Confirm Task Exit popup in Autostore Pick Mission page");
        }

        [Then(@"The Confirm Task Exit popup is displayed in Autostore Place in Container page")]
        public void ThenTheConfirmTaskExitPopupIsDisplayedInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(ConfirmTaskExitPopup.Instance.IsPopupDisplayed(),
                "The Confirm Task Exit popup is not displayed in Autostore Place in Container page");
            const string expectedMessage =
                "If you exit, the current task group will be suspended!\r\n\r\nAre you sure you want to exit?";
            Assert.AreEqual(expectedMessage, ConfirmTaskExitPopup.Instance.GetPopupMessage(),
                "Confirm Task Exit popup message is wrong in Autostore Place in Container page");
        }

        [When(@"I click on '(.*)' button on Confirm Task Exit popup in Autostore Place in Container page")]
        public void WhenIClickOnButtonOnConfirmTaskExitPopupInAutoStorePlaceInContainerPage(string buttonToBeClicked)
        {
            Assert.IsTrue(ConfirmTaskExitPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to Click on {buttonToBeClicked} button on Confirm Task Exit popup in Autostore Place in Container page");
        }

        private CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
