using System.Linq;
using System.Text.RegularExpressions;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Inventory.Overview
{
    [Binding]
    public sealed class FeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Given(@"I navigate to the Inventory order list page")]
        public void GivenINavigateToTheInventoryOrderListPage()
        {
            InventoryOrderList.Instance.Navigate();
            Assert.IsTrue(InventoryOrderList.Instance.IsPageLoaded(),
                "The Admin Inventory order list page is not loaded");
        }

        [Then(@"The Inventory order list page is loaded")]
        public void ThenTheInventoryOrderListPageIsLoaded()
        {
            Assert.IsTrue(InventoryOrderList.Instance.IsPageLoaded(),
                "The Admin Inventory order list page is not loaded");
        }

        [When(@"I click on Search button in Inventory order list page")]
        public void WhenIClickOnSearchButtonInInventoryOrderListPage()
        {
            Assert.IsTrue(InventoryOrderList.Instance.ClickSearchButton(),
                "Unable to click on Search button in Inventory order list page");
        }

        [Then(@"The inventory record is listed on the inventory details grid in Inventory order list page")]
        public void ThenTheInventoryRecordIsListedOnTheInventoryDetailsGridInInventoryOrderListPage()
        {
            Assert.IsTrue(InventoryOrderList.Instance.IsFirstInventoryResultBarDisplayed(),
                "The inventory record is NOT listed on the inventory details grid in Inventory order list page");
        }

        [Then(@"I verify the taskgroup count for the inventory order list is correct on the inventory details grid in Inventory order list page")]
        public void ThenIVerifyTheTaskgroupCountForTheInventoryOrderListIsCorrectOnTheInventoryDetailsGridInInventoryOrderListPage()
        {
            var scenarioTags = _scenarioContext.ScenarioInfo.Tags;
            var expectedInventoryTaskgroupCountTag =
                scenarioTags.FirstOrDefault(scenarioTag => scenarioTag.Contains("InventoryTaskgroupCount"));
            var expectedInventoryTaskgroupCount =
                int.Parse(Regex.Match(expectedInventoryTaskgroupCountTag ?? string.Empty, @"\d+").Value);
            Assert.AreEqual(expectedInventoryTaskgroupCount,
                InventoryOrderList.Instance.GetFirstInventoryTaskgroupCount(),
                "The taskgroup count for the inventory order list is WRONG on the inventory details grid in Inventory order list page");
        }

        [Then(@"I click on the Activate menu item for the inventory activity in Inventory order list page")]
        public void ThenIClickOnTheActivateMenuItemForTheInventoryActivityInInventoryOrderListPage()
        {
            Assert.IsTrue(InventoryOrderList.Instance.SelectActionMenuOption("Activate"),
                "Unable to click on the Activate menu item for the inventory activity in Inventory order list page");
        }

        [When(@"I click on the inventory add button of the Inventory order list page")]
        public void WhenIClickOnTheInventoryAddButtonOfTheInventoryOrderListPage()
        {
            Assert.IsTrue(InventoryOrderList.Instance.ClickAddButton(),
                "Unable to click on the inventory add button of the Inventory order list page");
        }

        [Then(@"The Inventory details page is loaded")]
        public void ThenTheInventoryDetailsPageIsLoaded()
        {
            Assert.IsTrue(InventoryDetails.Instance.IsPageLoaded(),
                "The Admin Inventory details page is not loaded");
        }

        [Then(@"I verify Maximum lines per taskgroup field value is '(.*)' in the Inventory details page")]
        public void ThenIVerifyMaximumLinesPerTaskgroupFieldValueIsInTheInventoryDetailsPage(string expectedMaxLineCount)
        {
            Assert.AreEqual(expectedMaxLineCount, InventoryDetails.Instance.GetMaximumLinesPerFieldValue(),
                "Maximum lines per taskgroup field value is different in the Inventory details page");
        }

        [Then(@"I include the productId as '(.*)' to the FromProductId field in the Inventory details page")]
        public void ThenIIncludeTheProductIdAsToTheFromProductIdFieldInTheInventoryDetailsPage(string productId)
        {
            Assert.IsTrue(InventoryDetails.Instance.InsertProduct(productId),
                $"Unable to select the productId as {productId} to the FromProductId field in the Inventory details page");
        }

        [Then(@"I include the locationId as '(.*)' to the FromLocationId field in the Inventory details page")]
        public void ThenIIncludeTheLocationIdAsToTheFromLocationIdFieldInTheInventoryDetailsPage(string locationId)
        {
            Assert.IsTrue(InventoryDetails.Instance.InsertLocation(locationId),
                $"Unable to select the locationId as {locationId} to the FromLocationId field in the Inventory details page");
        }

        [When(@"I click on the Add button in the Inventory details page")]
        public void WhenIClickOnTheAddButtonInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryDetails.Instance.ClickAddButton(),
                "Unable to click on the Add button in the Inventory details page");
        }

        [Then(@"I click on Remove button in the Inventory details page")]
        public void ThenIClickOnRemoveButtonInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryDetails.Instance.ClickRemoveButton(),
                "Unable to click on the Remove button in the Inventory details page");
        }

        [Then(@"The Inventory count confirmation dialog is displayed in the Inventory details page")]
        public void ThenTheInventoryCountConfirmationDialogIsDisplayedInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryCountConfirmationPopup.Instance.IsPopupDisplayed(),
                "The Inventory count confirmation dialog is not displayed in the Inventory details page");
        }

        [Then(@"I verify the Total taskgroup count is '(.*)' on inventory count confirmation dialog in the Inventory details page")]
        public void ThenIVerifyTheTotalTaskgroupCountIsOnInventoryCountConfirmationDialogInTheInventoryDetailsPage(int taskgroupCount)
        {
            var popupMessage = InventoryCountConfirmationPopup.Instance.GetPopupMessage();
            Assert.IsTrue(popupMessage.Contains($"Total task groups: {taskgroupCount}"),
                $"Total taskgroup count is Wrong {taskgroupCount} on Inventory count confirmation dialog in the Inventory details page");
        }

        [When(@"I click on the Yes button on inventory count confirmation dialog in the Inventory details page")]
        public void WhenIClickOnTheYesButtonOnInventoryCountConfirmationDialogInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryCountConfirmationPopup.Instance.ClickYesButton(),
                "Unable to click on the Yes button on inventory count confirmation dialog in the Inventory details page");
        }

        [Then(@"The inventory record is added to the inventory details grid in the Inventory details page")]
        public void ThenTheInventoryRecordIsAddedToTheInventoryDetailsGridInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryDetails.Instance.IsFirstInventoryRecordRowDisplayed(),
                "The inventory record is not added to the inventory details grid in the Inventory details page");
            _scenarioContext["TaskGroupId"] = InventoryDetails.Instance.GetTaskGroupId();
        }

        [Then(@"I verify '(.*)' inventory task groups have been created and added to the inventory details grid in the Inventory details page")]
        public void ThenIVerifyInventoryTaskGroupsHaveBeenCreatedAndAddedToTheInventoryDetailsGridInTheInventoryDetailsPage(int expectedTaskgroupCount)
        {
            Assert.AreEqual(expectedTaskgroupCount, InventoryDetails.Instance.GetTaskgroupCount(),
                "The Expected number of Inventory task groups are not created");
        }

        [When(@"I click on Taskgroup expander for the inventory taskgroup on inventory details grid in the Inventory details page")]
        public void WhenIClickOnTaskgroupExpanderForTheInventoryTaskgroupOnInventoryDetailsGridInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryDetails.Instance.ClickTaskgroupExpander(),
                "Unable to click on Taskgroup expander for the inventory taskgroup on inventory details grid in the Inventory details page");
        }

        [Then(@"Inventory missions belongs to the taskgroup are listed on inventory details grid in the Inventory details page")]
        public void ThenInventoryMissionsBelongsToTheTaskgroupAreListedOnInventoryDetailsGridInTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryDetails.Instance.IsInventoryMissionListGridDisplayed(),
                "Inventory missions belongs to the taskgroup are not listed on inventory details grid in the Inventory details page");
        }

        [Then(@"I verify '(.*)' inventory missions are listed on inventory details grid in the Inventory details page")]
        public void ThenIVerifyInventoryMissionsAreListedOnInventoryDetailsGridInTheInventoryDetailsPage(int expectedMissionCount)
        {
            Assert.AreEqual(expectedMissionCount, InventoryDetails.Instance.GetFirstTaskGroupMissionCount(),
                "The Expected number of Inventory missions are not listed on inventory details grid in the Inventory details page");
        }

        [Then(@"I click on the Activate menu item on the Inventory details page")]
        public void WhenIClickOnTheActivateMenuItemOnTheInventoryDetailsPage()
        {
            Assert.IsTrue(InventoryDetails.Instance.SelectActionMenuOption("Activate"),
                "Unable to click on the Activate menu item on the Inventory details page");
        }

        [Then(@"The inventory task is activated")]
        public void ThenTheInventoryTaskIsActivated()
        {
            var taskgroupId = InventoryDetails.Instance.GetTaskGroupId();
            Assert.IsTrue(InventoryDetails.Instance.IsFirstInventoryRecordRowDisplayed(),
                "The inventory record is not added to the inventory details grid in the Inventory details page");
            Assert.IsTrue(InventoryDetails.Instance.IsInventoryTaskActivated(taskgroupId),
                $"The inventory task {taskgroupId} is not activated");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
