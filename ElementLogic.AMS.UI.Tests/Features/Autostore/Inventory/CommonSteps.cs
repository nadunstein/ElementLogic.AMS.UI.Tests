using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inventory
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Then(@"The Autostore inventory mission '(.*)' is loaded")]
        public void ThenTheAutostoreInventoryMissionIsLoaded(int missionNumber)
        {
            Assert.IsTrue(InventoryMission.Instance.IsPageLoaded(),
                $"Autostore Inventory mission {missionNumber} page is not loaded");
            Assert.IsTrue(InventoryMission.Instance.GetTaskQueueLabelValue().Contains($"Task {missionNumber} of"),
                $"The Autostore Inventory mission {missionNumber} is not loaded");

            var extProductId = InventoryMission.Instance.GetProductNumberLabelValue();
            var locationBinId = InventoryMission.Instance.GetAutoStoreLocationLabelValue();
            _scenarioContext["Quantity"] =
                ProductLocation.Instance.GetLocationQuantity(locationBinId, extProductId);
        }

        [Then(@"I include the location quantity as '(.*)' to the Location quantity field in Autostore inventory mission page")]
        public void ThenIIncludeTheLocationQuantityAsToTheLocationQuantityFieldInAutostoreInventoryMissionPage(int quantity)
        {
            Assert.IsTrue(InventoryMission.Instance.InsertQuantity(quantity),
                $"Unable to include the location quantity as {quantity} to the Location quantity field in Autostore inventory mission page");
        }

        [When(@"I click on Confirm button in Autostore inventory mission page")]
        public void WhenIClickOnConfirmButtonInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(InventoryMission.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button in Autostore inventory mission page");
        }

        [Then(@"No more tasks popup is displayed in Autostore inventory mission page")]
        public void ThenNoMoreTasksPopupIsDisplayedInInventoryMissionPage()
        {
            Assert.IsTrue(NoMoreTasksPopup.Instance.IsPopupDisplayed(),
                "No more tasks popup is not displayed in Autostore inventory mission page");
        }

        [When(@"I click on OK button on No more tasks popup in Autostore inventory mission page")]
        public void WhenIClickOnOKButtonOnNoMoreTasksPopupInAutostoreInventoryMissionPage()
        {
            Assert.IsTrue(NoMoreTasksPopup.Instance.ClickOkButton(),
                "Unable to click on OK button on No more tasks popup in Autostore inventory mission page");
        }

        private CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
