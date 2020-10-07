using System.Globalization;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
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
            Assert.AreEqual("Picking", PickMission.Instance.GetPageTitle(),
                $"Autostore Pick mission {missionNumber} page is not loaded");
            Assert.IsTrue(PickMission.Instance.GetTaskQueueLabelValue().Contains($"Task {missionNumber} of"),
                $"The Autostore Pick mission {missionNumber} is not loaded");

            _scenarioContext["task_id"] = PickMission.Instance.GetMissionIdLabelValue();
            var splitLocationId = PickMission.Instance.GetPickLocation().Split(new char[] { '-' });
            _scenarioContext["bin_id"] = splitLocationId[1];
            _scenarioContext["ExtProductId"] = PickMission.Instance.GetProductNumberLabelValue();
            _scenarioContext["TotalQuantity"] =
                (_scenarioContext.ContainsKey("TotalQuantity") ? (int)_scenarioContext["TotalQuantity"] : 0)
                + PickMission.Instance.GetPickQuantityFieldValue();
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
                "The message content of the successfully container added is wrong");
        }

        [Then(@"I include the product scan value to scan field in Autostore Pick Mission page")]
        public void ThenIIncludeTheProductScanValueToScanFieldInAutostorePickMissionPage()
        {
            var productScanValue =
                Parameter.Instance.GetParameterData("AutoStore.Picking.Scanning.ValidateProduct").ParameterValue.Contains("1")
                    ? PickMission.Instance.GetProductNumberLabelValue()
                    : PickMission.Instance.GetPickLocation();

            Assert.IsTrue(PickMission.Instance.InsertProductScanValue(productScanValue),
                "Unable to include the product scan value to scan field in Autostore Pick Mission page");
        }

        [When(@"I click on the confirm button in Autostore Pick Mission page")]
        public void WhenIClickOnTheConfirmButtonInAutostorePickMissionPage()
        {
            var quantityFieldValue = PickMission.Instance.GetPickQuantityFieldValue().ToString();
            var productId = PickMission.Instance.GetProductNumberLabelValue();
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

        [Then(@"The AutoStore Place in Container page is loaded")]
        public void ThenTheAutoStorePlaceInContainerPageIsLoaded()
        {
            Assert.AreEqual("Place in Container", PlaceInContainer.Instance.GetPageTitle(),
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

        [Then(@"The Add new container popup is displayed in AutoStore Place in Container page")]
        public void TheThenAddNewContainerPopupIsDisplayedInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(AddNewContainerPopup.Instance.IsPopupDisplayed(),
                "The Add new container popup is not displayed in AutoStore Place in Container page");
        }

        [When(@"I click on '(.*)' button on Add new container popup in AutoStore Place in Container page")]
        public void WhenIClickOnButtonOnAddNewContainerPopupInAutoStorePlaceInContainerPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Add" => AddNewContainerPopup.Instance.ClickAddButton(),
                "Update" => AddNewContainerPopup.Instance.ClickUpdateButton(),
                "Close" => AddNewContainerPopup.Instance.ClickCloseButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Add new container popup in AutoStore Place in Container page");
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

        [When(@"I click on the Confirm button in AutoStore Place in Container page")]
        public void WhenIClickOnTheConfirmButtonInAutoStorePlaceInContainerPage()
        {
            Assert.IsTrue(PlaceInContainer.Instance.ClickConfirmButton(),
                "Unable to click on the Confirm button in  AutoStore Place in Container page");
        }

        private CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
