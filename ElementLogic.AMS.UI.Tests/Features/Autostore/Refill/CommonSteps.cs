using ElementLogic.AMS.UI.Tests.Pages.Autostore.Refill;
using ElementLogic.AMS.UI.Tests.TestDataPreparationHelper;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Refill
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Then(@"I Navigate to refill taskgroup selection page in Autostore")]
        public void ThenINavigateToRefillTaskgroupSelectionPageInAutostore()
        {
            Assert.IsTrue(RefillTaskgroupSelection.Instance.IsPageLoaded(),
                "The refill taskgroup selection page is not loaded");
        }

        [When(@"I click on Select button from refill taskgroup selection page in Autostore")]
        public void WhenIClickOnSelectButtonFromRefillTaskgroupSelectionPageInAutostore()
        {
            var nameOfTheTrolley = TestDataFactory.Instance.GetRefillTrolleyForScenario(_scenarioContext);
            Assert.IsTrue(RefillTaskgroupSelection.Instance.ClickTaskgroupSelectButton(nameOfTheTrolley),
                "Unable to click on Select button from refill taskgroup selection page in Autostore");
        }

        [Then(@"The Autostore Refill mission '(.*)' is loaded")]
        public void ThenTheAutostoreRefillMissionIsLoaded(int missionNumber)
        {
            Assert.IsTrue(RefillMission.Instance.IsPageLoaded(),
                "The Autostore Refill page is not loaded");
            var taskQueueLabelValue = RefillMission.Instance.GetTaskQueueLabelValue();
            Assert.IsTrue(taskQueueLabelValue.Contains($"Task {missionNumber} of"),
                $"The refill mission {missionNumber} is not loaded");

            _scenarioContext["ExtLocationId"] = RefillMission.Instance.GetLocationNameLabelValue();
            _scenarioContext["ActualQuantity"] = RefillMission.Instance.GetRefillQuantityFieldValue();
            _scenarioContext["TotalQuantity"] =
                _scenarioContext.ContainsKey("TotalQuantity")
                    ? int.Parse(_scenarioContext["TotalQuantity"].ToString())
                    : 0 + int.Parse(_scenarioContext["ActualQuantity"].ToString());
        }

        [Then(@"I check the refill product Id is correct in Autostore Refill mission page")]
        public void ThenICheckTheRefillProductIdIsCorrectInAutostoreRefillMissionPage()
        {
            var expectedProductId = _scenarioContext["ExtProductId"].ToString();
            Assert.AreEqual(expectedProductId, RefillMission.Instance.GetRefillProductId(),
                "The product Id is incorrect in Autostore Refill mission page");
        }

        [Then(@"I check the Refill Product Quantity is correct in Autostore Refill mission page")]
        public void ThenICheckTheRefillProductQuantityIsCorrectInAutostoreRefillMissionPage()
        {
            var expectedProductQuantity = _scenarioContext["Quantity"].ToString();
            var actualRefillQuantity = RefillMission.Instance.GetRefillQuantityFieldValue().ToString();
            Assert.AreEqual(expectedProductQuantity, actualRefillQuantity,
                "The Refill Product Quantity is incorrect in Autostore Refill mission page");
        }

        [Then(@"I check the Refill Product Quantity is '(.*)' in Autostore Refill mission page")]
        public void ThenICheckTheRefillProductQuantityIsInAutostoreRefillMissionPage(int quantity)
        {
            Assert.AreEqual(quantity, RefillMission.Instance.GetRefillQuantityFieldValue(),
                "The Refill Product Quantity is incorrect in Autostore Refill mission page");
        }

        [Then(@"I check the proposed refill bin is an empty bin in Autostore Refill mission page")]
        public void ThenICheckTheProposedRefillBinIsAnEmptyBinInAutostoreRefillMissionPage()
        {
            Assert.AreEqual("Empty bin", RefillMission.Instance.GetRefillEmptyBinLabelValue(),
                "The Empty Bin label is not displayed in Autostore Refill mission page");
        }

        [Then(@"I check the proposed refill bin is NOT an empty bin in Autostore Refill mission page")]
        public void ThenICheckTheProposedRefillBinIsNotAnEmptyBinInAutostoreRefillMissionPage()
        {
            Assert.IsFalse(RefillMission.Instance.IsRefillEmptyBinLabelDisplayed(),
                "The Empty Bin label is displayed in Autostore Refill mission page");
        }

        [When(@"I click on Confirm button in Autostore Refill mission page")]
        public void WhenIClickOnConfirmButtonInAutostoreRefillMissionPage()
        {
            Assert.IsTrue(RefillMission.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button in Autostore Refill mission page");
        }

        private CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
