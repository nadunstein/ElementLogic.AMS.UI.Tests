using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection
{
    [Binding]
    public sealed class CommonSteps
    {
        private string _productLocation;
        private int _changedQuantity;

        [Then(@"The Inspection-Create task page is loaded")]
        public void ThenTheInspection_CreateTaskPageIsLoaded()
        {
            Assert.IsTrue(InspectionCreateTask.Instance.IsPageLoaded(),
                "The Inspection-Create task page is not loaded");
        }

        [Given(@"I include the product as '(.*)' to the Product field and select in Autostore Inspection-Create Task page")]
        public void GivenIIncludeTheProductAsToTheProductFieldAndSelectInAutostoreInspection_CreateTaskPage(string productSearchText)
        {
            Assert.IsTrue(InspectionCreateTask.Instance.SearchProductAndSelect(productSearchText),
                $"Unable to include the product as '{productSearchText}' to the Product field and select in Autostore Inspection-Create Task page");
        }

        [Given(@"I select the Batch Id as '(.*)' to the Batch field in Autostore Inspection-Create Task page")]
        public void GivenISelectTheBatchIdAsToTheBatchFieldInAutostoreInspection_CreateTaskPage(string batchId)
        {
            Assert.IsTrue(InspectionCreateTask.Instance.SelectBatchId(batchId),
                $"Unable to select the Batch Id as '{batchId}' to the Batch field in Autostore Inspection-Create Task page");
        }

        [When(@"I click on Select Locations button in Autostore Inspection-Create Task page")]
        public void WhenIClickOnSelectLocationsButtonInAutostoreInspection_CreateTaskPage()
        {
            Assert.IsTrue(InspectionCreateTask.Instance.ClickSelectLocationsButton(),
                "Unable to click on Select Locations button in Autostore Inspection-Create Task page");
        }

        [Then(@"The Autostore Inspection-Select locations page is loaded")]
        public void ThenTheAutostoreInspection_SelectLocationsPageIsLoaded()
        {
            Assert.IsTrue(InspectionSelectLocationsPage.Instance.IsPageLoaded(),
                "The Autostore Inspection-Select locations page is NOT loaded");
        }

        [Then(@"I verify the location count is '(.*)' in Autostore Inspection-Select locations page")]
        public void ThenIVerifyTheLocationCountIsInAutostoreInspection_SelectLocationsPage(int expectedLocationCount)
        {
            var actualLocationCount = InspectionSelectLocationsPage.Instance.GetLocationCount();
            Assert.AreEqual(expectedLocationCount, actualLocationCount,
                "The location count is wrong in Autostore Inspection-Select locations page");
        }

        [Then(@"I click on Select all locations button in Autostore Inspection-Select locations page")]
        public void ThenIClickOnSelectAllLocationsButtonInAutostoreInspection_SelectLocationsPage()
        {
            Assert.IsTrue(InspectionSelectLocationsPage.Instance.ClickSelectAllLocationButton(),
                "Unable to click on Select all locations button in Autostore Inspection-Select locations page");
        }

        [When(@"I click on confirm button in Autostore Inspection-Select locations page")]
        public void WhenIClickOnConfirmButtonInAutostoreInspection_SelectLocationsPage()
        {
            Assert.IsTrue(InspectionSelectLocationsPage.Instance.ClickConfirmButton(),
                "Unable to click on confirm button in Autostore Inspection-Select locations page");
        }

        [Given(@"I include the location of '(.*)' product to the location field in Autostore Inspection-Create Task page")]
        [Then(@"I include the location of '(.*)' product to the location field in Autostore Inspection-Create Task page")]
        public void GivenIIncludeTheLocationOfProductToTheLocationFieldInAutostoreInspection_CreateTaskPage(string extProductId)
        {
            _productLocation = ProductLocation.Instance.GetFirstProductLocation(extProductId);
            Assert.IsTrue(InspectionCreateTask.Instance.IncludeLocationValue(_productLocation),
                "Unable to include the location in Autostore Inspection-Create Task page");
        }

        [Given(@"I include the Bin Id of '(.*)' product to the location field in Autostore Inspection-Create Task page")]
        public void GivenIIncludeTheBinIdOfProductToTheLocationFieldInAutostoreInspection_CreateTaskPage(string extProductId)
        {
            _productLocation = ProductLocation.Instance.GetFirstProductLocation(extProductId);
            var binId = "AS-" + _productLocation.Split('-')[1];
            Assert.IsTrue(InspectionCreateTask.Instance.IncludeLocationValue(binId),
                "Unable to include the binId in Autostore Inspection-Create Task page");
        }

        [When(@"I click on confirm button in Autostore Inspection-Create Task page")]
        public void WhenIClickOnConfirmButtonInAutostoreInspection_CreateTaskPage()
        {
            Assert.IsTrue(InspectionCreateTask.Instance.ClickConfirmButton(),
                "Unable to click confirm button in Autostore Inspection-Create Task page");
        }

        [Then(@"The Autostore Inspection mission '(.*)' is loaded")]
        public void ThenTheAutostoreInspectionMissionIsLoaded(int missionNumber)
        {
            Assert.IsTrue(InspectionMission.Instance.IsPageLoaded(),
                "The Autostore Inspection mission page is not loaded");
            Assert.IsTrue(InspectionMission.Instance.GetTaskQueueValue().Contains($"Task {missionNumber} of"),
                $"The Inspection Pick mission {missionNumber} is not loaded");
        }

        [Then(@"I verify the Quantity field value is displayed in Autostore Inspection Mission page")]
        public void ThenIVerifyTheQuantityFieldValueIsDisplayedInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(InspectionMission.Instance.IsQuantityDisplayed(),
                "The Location Quantity is NOT displayed in Autostore Inspection mission page");
        }

        [Then(@"I verify the Quantity field value is '(.*)' in Autostore Inspection Mission page")]
        public void ThenIVerifyTheQuantityFieldValueIsInAutostoreInspectionMissionPage(int expectedQuantity)
        {
            Assert.AreEqual(expectedQuantity.ToString(), InspectionMission.Instance.GetQuantityFieldValue(),
                "The Quantity field value is Wrong in Autostore Inspection Mission page");
        }

        [Then(@"I verify the Quantity field value is not displayed in Autostore Inspection Mission page")]
        public void ThenIVerifyTheQuantityFieldValueIsNotDisplayedInAutostoreInspectionMissionPage()
        {
            Assert.IsFalse(InspectionMission.Instance.IsQuantityDisplayed(),
                "The Location Quantity is displayed in Autostore Inspection mission page");
        }

        [Then(@"I include the actual quantity to the Location Quantity field in Autostore Inspection mission page")]
        public void ThenIIncludeTheActualQuantityToTheLocationQuantityFieldInAutostoreInspectionMissionPage()
        {
            var productId = InspectionMission.Instance.GetProductNumberLabelValue();
            var actualQty = (int) ProductLocation.Instance.GetLocationQuantity(_productLocation, productId);
            Assert.IsTrue(InspectionMission.Instance.IncludeLocationQuantityValue(actualQty),
                "Unable to include the quantity in Autostore Inspection mission page");
        }

        [When(@"I click on Confirm button in Autostore Inspection mission page")]
        public void WhenIClickOnConfirmButtonInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(InspectionMission.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button in Autostore Inspection mission page");
        }

        [Then(@"I include the location quantity as '(.*)' to the Location quantity field in Autostore Inspection mission page")]
        public void ThenIIncludeTheLocationQuantityAsToTheLocationQuantityFieldInAutostoreInspectionMissionPage(int changedQuantity)
        {
            Assert.IsTrue(InspectionMission.Instance.IncludeLocationQuantityValue(changedQuantity),
                "Unable to include the quantity in Autostore Inspection mission page");
        }

        [Then(@"I include a Quantity to the Location Quantity field which is less than the Original Quantity in Autostore Inspection mission page")]
        public void ThenIIncludeAQuantityToTheLocationQuantityFieldWhichIsLessThanTheOriginalQuantityInAutostoreInspectionMissionPage()
        {
            var productId = InspectionMission.Instance.GetProductNumberLabelValue();
            _changedQuantity = (int) ProductLocation.Instance.GetLocationQuantity(_productLocation, productId) - 1;
            Assert.IsTrue(InspectionMission.Instance.IncludeLocationQuantityValue(_changedQuantity),
                "Unable to include the quantity in Autostore Inspection mission page");
        }

        [Then(@"The Quantity is updated successfully for the product")]
        public void ThenTheQuantityIsUpdatedSuccessfullyForTheProduct()
        {
            var productId = InspectionMission.Instance.GetProductNumberLabelValue();
            var qtyAfterInspection = (int) ProductLocation.Instance.GetLocationQuantity(_productLocation, productId);
            Assert.AreEqual(_changedQuantity, qtyAfterInspection,
                "The Location Quantity is not changed after Inspection");
        }

        [Then(@"I Select the reason code as '(.*)' in Autostore Inspection page")]
        public void ThenISelectTheSearchOnAsInAutostorePutawaySelectionPage(string reasonCode)
        {
            Assert.IsTrue(InspectionMission.Instance.SelectReasonCode(reasonCode),
                $"Unable to Select the reason code as {reasonCode} in Autostore Inspection page");
        }

        [When(@"I click on Exit button in Autostore Inspection Mission page")]
        public void WhenIClickOnExitButtonInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(InspectionMission.Instance.ClickExitButton(),
                "Unable to click on Exit button in Autostore Inspection mission page");
        }

        [Then(@"The Delete mission popup is displayed in Autostore Inspection Mission page")]
        public void ThenTheDeleteMissionPopupIsDisplayedInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(DeleteMissionsPopup.Instance.IsPopupDisplayed(),
                "The Delete mission popup is NOT displayed in Autostore Inspection mission page");
            const string expectedPopupMessage = "Incomplete missions will be deleted. Are you sure?";
            Assert.AreEqual(expectedPopupMessage, DeleteMissionsPopup.Instance.GetPopupMessage(),
                "The popup message is wrong in Delete mission popup Autostore Inspection mission page");
        }

        [When(@"I click on '(.*)' button on Delete mission popup in Autostore Inspection Mission page")]
        public void WhenIClickOnButtonOnDeleteMissionPopupInAutostoreInspectionMissionPage(string buttonToBeClicked)
        {
            Assert.IsTrue(DeleteMissionsPopup.Instance.ClickPopupButton(buttonToBeClicked),
                $"Unable to click on '{buttonToBeClicked}' button on Delete mission popup in Autostore Inspection Mission page");
        }
    }
}
