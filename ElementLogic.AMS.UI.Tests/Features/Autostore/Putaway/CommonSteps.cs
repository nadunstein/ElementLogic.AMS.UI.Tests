using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway
{
    [Binding]
    public class CommonSteps
    {
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
            PutawaySelection.Instance.ClickEnterButtonOnScanField();
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
        public void ThenTheQuantityFieldValueShouldBeInAutostorePutawayQuantityConfirmPopup(double putawayQuantity)
        {
            Assert.AreEqual(putawayQuantity, PutawayConfirmQuantityPopup.Instance.GetPutawayQuantity(),
                "The putaway quantity is not correct");
        }

        [Then(@"I enter putaway quantity value as '(.*)' in Autostore putaway quantity confirm popup")]
        public void ThenIEnterPutawayQuantityValueAsInAutostorePutawayQuantityConfirmPopup(int quantity)
        {
            Assert.IsTrue(PutawayConfirmQuantityPopup.Instance.InsertPutawayQuantity(quantity.ToString()),
                "Unable to Insert putaway quantity value in Autostore putaway quantity confirm popup");
        }

        [Then(@"I Include max location quantity value as '(.*)' in Autostore putaway quantity confirm popup")]
        public void ThenIIncludeMaxLocationQuantityValueAsInAutostorePutawayQuantityConfirmPopup(int maxLocationQuantity)
        {
            Assert.IsTrue(
                PutawayConfirmQuantityPopup.Instance.InsertMaxLocationQuantity(maxLocationQuantity.ToString()),
                "Unable to Include max location quantity value in Autostore putaway quantity confirm popup");
        }

        [When(@"I click on enter button after include max location quantity in Autostore putaway quantity confirm popup")]
        public void WhenIClickOnEnterButtonAfterIncludeMaxLocationQuantityInAutostorePutawayQuantityConfirmPopup()
        {
            PutawayConfirmQuantityPopup.Instance.ClickConfirmButton();
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
            _scenarioContext["ExtLocationId"] = PutawayMission.Instance.GetLocationNameLabelValue();
            _scenarioContext["ActualQuantity"] = PutawayMission.Instance.GetQuantityFieldValue();
            _scenarioContext["TotalQuantity"] =
                _scenarioContext.ContainsKey("TotalQuantity")
                    ? (int)_scenarioContext["TotalQuantity"]
                    : 0 + (int)_scenarioContext["ActualQuantity"];
        }

        [Then(@"I check the focus is on quantity field in Autostore putaway mission page")]
        public void ThenICheckTheFocusIsOnQuantityFieldInAutostorePutawayMissionPage()
        {
            Assert.IsTrue(PutawayMission.Instance.IsQuantityFieldDisplayed(),
                "The Autostore putaway mission quantity field is not displayed");
            Assert.True(PutawayMission.Instance.IsQuantityFieldFocused(),
                "The Focus is not on the Quantity field in Autostore putaway mission page");
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
