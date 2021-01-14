using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inventory.InventoryDeviation
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"The Confirm Quantity popup is displayed in Autostore inventory page")]
        public void ThenTheConfirmQuantityPopupIsDisplayedInAutostoreInventoryPage()
        {
            Assert.IsTrue(ConfirmQuantityPopup.Instance.IsPopupDisplayed(),
                "The Confirm Quantity popup is not displayed in Autostore inventory page");
            var extProductId = InventoryMission.Instance.GetProductNumberLabelValue();
            var locationBinId = InventoryMission.Instance.GetAutoStoreLocationLabelValue();
            var locationQuantity =
                ProductLocation.Instance.GetLocationQuantity(locationBinId, extProductId);
            var quantityFieldValue = InventoryMission.Instance.GetQuantityFieldValue();
            var expectedConfirmQuantityPopupMessage =
                $"The entered quantity ({quantityFieldValue}) differs from what is registered in the system ({locationQuantity})!\r\n\r\nAre you sure you want to proceed?";
            var confirmQuantityPopupMessage = ConfirmQuantityPopup.Instance.GetPopupMessage();

            Assert.AreEqual(expectedConfirmQuantityPopupMessage, confirmQuantityPopupMessage,
                "The Confirm Quantity popup message is wrong in Autostore inventory page");
        }

        [When(@"I click on '(.*)' button on Confirm Quantity popup in Autostore inventory page")]
        public void WhenIClickOnButtonOnConfirmQuantityPopupInAutostoreInventoryPage(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ConfirmQuantityPopup.Instance.ClickYesButton(),
                "No" => ConfirmQuantityPopup.Instance.ClickNoButton(),
                _ => false
            };

            Assert.IsTrue(isButtonClicked,
                $"Unable to Click on {buttonToBeClicked} button on Confirm Quantity popup in Autostore inventory page");
        }
    }
}
