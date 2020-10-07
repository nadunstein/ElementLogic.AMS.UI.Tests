using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.PickReassign
{
    [Binding]
    public class FeatureSteps
    {
        [Then(@"I include the locationId as the pick order reserved location of the product '(.*)' to the FromLocationId field in the Inventory details page")]
        public void ThenIIncludeTheLocationIdAsThePickOrderReservedLocationOfTheProductToTheFromLocationIdFieldInTheInventoryDetailsPage(string productId)
        {
            var productLocationId = ProductLocation.Instance.GetFirstProductLocationAssignedForPick(productId);
            Assert.IsTrue(InventoryDetails.Instance.InsertLocation(productLocationId),
                $"Unable to select the locationId as {productLocationId} to the FromLocationId field in the Inventory details page");
        }

    }
}
