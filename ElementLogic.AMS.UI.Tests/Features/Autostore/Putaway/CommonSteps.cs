using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly IList<string> _taskgroupMissionBinLocationList = new List<string>();
        private readonly ScenarioContext _scenarioContext;

        [Then(@"I Navigate to Autostore Putaway Selection page")]
        public void ThenINavigateToAutostorePutawaySelectionPage()
        {
            Assert.IsTrue(PutawaySelection.Instance.IsPageLoaded(),
                "The putaway selection page is not Loaded");
        }

        [Given(@"I Select the search on as '(.*)' in Autostore Putaway Selection page")]
        [Then(@"I Select the search on as '(.*)' in Autostore Putaway Selection page")]
        public void ThenISelectTheSearchOnAsInAutostorePutawaySelectionPage(string searchOnOption)
        {
            Assert.IsTrue(PutawaySelection.Instance.SelectSearchOnDropdownValue(searchOnOption),
                "Unable to Select Search on dropdown value in Autostore Putaway Selection page");
        }

        [Then(@"I Include the ActivityId to the Scan field in Autostore Putaway Selection page")]
        public void ThenIIncludeTheActivityIdToTheScanFieldInAutostorePutawaySelectionPage()
        {
            var extProductId = _scenarioContext["ExtProductId"].ToString();
            var activityId = Mission.Instance.GetActivityIdFromProductId(extProductId);
            Assert.IsTrue(PutawaySelection.Instance.InsertScanFieldValue(activityId),
                "Unable to Include the ActivityId to the Scan field in Autostore Putaway Selection page");
        }

        [Then(@"I Include the Trolley Depth to the Scan field in Autostore Putaway Selection page")]
        public void ThenIIncludeTheTrolleyDepthToTheScanFieldInAutostorePutawaySelectionPage()
        {
            var trolleyDepth = _scenarioContext["TrolleyDepth"].ToString();
            Assert.IsTrue(PutawaySelection.Instance.InsertScanFieldValue(trolleyDepth),
                "Unable to Include the Trolley Depth to the Scan field in Autostore Putaway Selection page");
        }

        [Then(@"I Include the putaway order ID to the Scan field in Autostore Putaway Selection page")]
        public void ThenIIncludeThePutawayOrderIdToTheScanFieldInAutostorePutawaySelectionPage()
        {
            var extOrderId = _scenarioContext["ExtOrderId"].ToString();
            Assert.IsTrue(PutawaySelection.Instance.InsertScanFieldValue(extOrderId),
                "Unable to Include the putaway order ID to the Scan field in Autostore Putaway Selection page");
        }

        [Then(@"I Include Product Id as '(.*)' to the Scan field in Autostore Putaway Selection page")]
        public void ThenIncludeProductIdAsToTheScanFieldInAutostorePutawaySelectionPage(string productId)
        {
            _scenarioContext["ExtProductId"] = productId;
            Assert.IsTrue(PutawaySelection.Instance.InsertScanFieldValue(productId),
                "Unable to Include Product Id to the Scan field in Autostore Putaway Selection page");
        }

        [When(@"I click Enter button in Autostore Putaway Selection page")]
        public void WhenIClickEnterButtonInAutostorePutawaySelectionPage()
        {
            Assert.IsTrue(PutawaySelection.Instance.ClickEnterButtonOnScanField(),
                "Unable to click Enter button in Autostore Putaway Selection page");
        }

        [Then(@"The '(.*)' putaway orders are listed for product in Autostore Putaway Selection page")]
        public void ThenThePutawayOrdersAreListedForProductInAutostorePutawaySelectionPage(int expectedOrderCount)
        {
            Assert.AreEqual(expectedOrderCount, PutawaySelection.Instance.GetTaskgroupCount(),
                "The listed putaway order count is wrong in Autostore Putaway Selection page");
        }

        [When(@"I click on first Select button of the product '(.*)' from order list in Autostore Putaway Selection page")]
        public void WhenIClickOnFirstSelectButtonOfTheProductFromOrderListInAutostorePutawaySelectionPage(string productId)
        {
            Assert.IsTrue(PutawaySelection.Instance.ClickFirstTaskgroupSelectButton(productId),
                $"Unable to click on first Select button of the product '{productId}' from order list in Autostore Putaway Selection page");
        }

        [Then(@"The putaway quantity confirm popup is displayed")]
        public void ThenThePutawayQuantityConfirmPopupIsDisplayed()
        {
            Assert.True(PutawayConfirmQuantityPopup.Instance.IsPopupDisplayed(),
                "The Autostore putaway quantity confirm popup is not displayed");
        }

        [Then(@"I check the focus in on the quantity field in Autostore putaway quantity confirm popup")]
        public void ThenICheckTheFocusInOnTheQuantityFieldInAutostorePutawayQuantityConfirmPopup()
        {
            Assert.IsTrue(PutawayConfirmQuantityPopup.Instance.IsPutawayQuantityFieldDisplayed(),
                "The Putaway confirm quantity popup Quantity Field is not displayed");
            Assert.True(PutawayConfirmQuantityPopup.Instance.IsPutawayQuantityFieldFocused(),
                "The Focus is NOT on the Quantity field in Putaway confirm quantity popup");
        }

        [Then(@"The quantity field value should be '(.*)' in Autostore putaway quantity confirm popup")]
        public void ThenTheQuantityFieldValueShouldBeInAutostorePutawayQuantityConfirmPopup(int expectedPutawayQuantity)
        {
            var actualPutawayQuantity = PutawayConfirmQuantityPopup.Instance.GetPutawayQuantity();
            Assert.AreEqual(expectedPutawayQuantity, actualPutawayQuantity,
                "The quantity field value is wrong in Autostore putaway quantity confirm popup");
        }

        [Then(@"I verify max location quantity value is '(.*)' in Autostore putaway quantity confirm popup")]
        public void ThenIVerifyMaxLocationQuantityValueIsInAutostorePutawayQuantityConfirmPopup(int expectedMaxLocationQuantity)
        {
            var actualMaxLocationQuantity = PutawayConfirmQuantityPopup.Instance.GetMaximumLocationQuantity();
            Assert.AreEqual(expectedMaxLocationQuantity, actualMaxLocationQuantity,
                "The max location quantity value is wrong in Autostore putaway quantity confirm popup");
        }

        [When(@"I click on Confirm button in Autostore putaway quantity confirm popup")]
        public void WhenIClickOnConfirmButtonInAutostorePutawayQuantityConfirmPopup()
        {
            Assert.IsTrue(PutawayConfirmQuantityPopup.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button in Autostore putaway quantity confirm popup");
        }

        [Then(@"I enter putaway quantity value as '(.*)' in Autostore putaway quantity confirm popup")]
        public void ThenIEnterPutawayQuantityValueAsInAutostorePutawayQuantityConfirmPopup(double quantity)
        {
            Assert.IsTrue(PutawayConfirmQuantityPopup.Instance.InsertPutawayQuantity(quantity.ToString(CultureInfo.InvariantCulture)),
                "Unable to Insert putaway quantity value in Autostore putaway quantity confirm popup");
        }

        [Then(@"I Include max location quantity value as '(.*)' in Autostore putaway quantity confirm popup")]
        public void ThenIIncludeMaxLocationQuantityValueAsInAutostorePutawayQuantityConfirmPopup(double maxLocationQuantity)
        {
            Assert.IsTrue(
                PutawayConfirmQuantityPopup.Instance.InsertMaxLocationQuantity(maxLocationQuantity.ToString(CultureInfo.InvariantCulture)),
                "Unable to Include max location quantity value in Autostore putaway quantity confirm popup");
        }

        [Then(@"The putaway order information is loaded in the Autostore putaway mission page")]
        public void ThenThePutawayOrderInformationIsLoadedInTheAutostorePutawayMissionPage()
        {
            var expectedExtProductId = _scenarioContext["ExtProductId"].ToString();
            Assert.AreEqual(expectedExtProductId, PutawayMission.Instance.GetExtProductIdFieldValue(),
                "The product id is not correct in Autostore putaway mission page");
        }

        [Then(@"The Autostore putaway mission '(.*)' is loaded")]
        public void ThenTheAutostorePutawayMissionIsLoaded(int missionNumber)
        {
            Assert.IsTrue(PutawayMission.Instance.IsPageLoaded(),
                $"Autostore Putaway mission {missionNumber} page is not loaded");
            Assert.IsTrue(PutawayMission.Instance.GetTaskQueueLabelValue(). Contains($"Task {missionNumber} of"),
                $"The Autostore Putaway mission {missionNumber} is not loaded");

            if (_taskgroupMissionBinLocationList.Count != missionNumber)
            {
                _taskgroupMissionBinLocationList.Add(PutawayMission.Instance.GetAutostoreBinId());
            }
           
            _scenarioContext["ActualQuantity"] = PutawayMission.Instance.GetQuantityFieldValue();
            _scenarioContext["TotalQuantity"] =
                _scenarioContext.ContainsKey("TotalQuantity")
                    ? (double)_scenarioContext["TotalQuantity"]
                    : 0 + (double)_scenarioContext["ActualQuantity"];
        }

        [Then(@"I check the focus is on quantity field in Autostore putaway mission page")]
        public void ThenICheckTheFocusIsOnQuantityFieldInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.IsQuantityFieldDisplayed(),
                "The Autostore putaway mission quantity field is not displayed");
            Assert.True(PutawayMission.Instance.IsQuantityFieldFocused(),
                "The Focus is not on the Quantity field in Autostore putaway mission page");
        }

        [Then(@"I verify the Quantity field value is '(.*)' in Autostore Putaway Mission page")]
        public void ThenIVerifyTheQuantityFieldValueIsInAutostorePutawayMissionPage(double expectedPutawayQuantity)
        {
            var actualPutawayQuantity = PutawayMission.Instance.GetQuantityFieldValue();
            Assert.AreEqual(expectedPutawayQuantity, actualPutawayQuantity,
                "The Quantity field value is wrong in Autostore Putaway Mission page");
        }

        [Then(@"I verify a new autostore bin is proposed for the putaway mission in Autostore Putaway Mission page")]
        public void ThenIVerifyANewAutostoreBinIsProposedForThePutawayMissionInAutostorePutawayMissionPage()
        {
            var currentAutostoreBinId = PutawayMission.Instance.GetAutostoreBinId();
            var count = _taskgroupMissionBinLocationList.Count(taskgroupMissionBin =>
                taskgroupMissionBin == currentAutostoreBinId);
            Assert.IsTrue(count == 1,
                "The proposed autostore bin for the putaway mission is not a new bin in Autostore Putaway Mission page");
        }

        [Then(@"I change the quantity of the Quantity field as '(.*)' in Autostore putaway Mission page")]
        public void ThenIChangeTheQuantityOfTheQuantityFieldAsInAutostorePutawayMissionPage(double putawayQuantity)
        {
            Assert.IsTrue(PutawayMission.Instance.InsertQuantityFieldValue(putawayQuantity),
                $"Unable to change the quantity of the Quantity field as '{putawayQuantity}' in Autostore putaway Mission page");
        }

        [Then(@"I verify the scan field is displayed in AutoStore putaway mission page")]
        public void ThenIVerifyTheScanFieldIsDisplayedInAutoStorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.IsScanFieldDisplayed(),
                "The Scan Field is not displayed in Autostore putaway mission page");
        }

        [Then(@"I verify the focus is on scan field in Autostore putaway mission page")]
        public void ThenIVerifyTheFocusIsOnScanFieldInAutostorePutawayMissionPage()
        {
            Assert.True(PutawayMission.Instance.IsScanFieldFocused(),
                "The Focus is NOT on the Scan field in Autostore putaway mission page");
        }

        [Then(@"I include the product scan value to scan field in Autostore putaway mission page")]
        public void ThenIIncludeTheProductScanValueToScanFieldInAutostorePutawayMissionPage()
        {
            var extProductId = _scenarioContext["ExtProductId"].ToString();
            Assert.IsTrue(PutawayMission.Instance.IncludeScanValue(extProductId),
                "Unable to include the scan value to Scan value field in Autostore putaway mission page");
        }

        [When(@"I click on Confirm button in Autostore putaway mission page")]
        public void WhenIClickOnConfirmButtonInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button in Autostore putaway mission page");
        }

        private CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
