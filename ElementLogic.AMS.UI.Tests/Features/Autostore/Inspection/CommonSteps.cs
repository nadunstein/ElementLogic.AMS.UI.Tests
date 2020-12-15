using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection
{
    [Binding]
    public class CommonSteps
    {
        private string _productLocation;
        private int _changedQuantity;

        [Then(@"The Inspection-Create task page is loaded")]
        public void ThenTheInspection_CreateTaskPageIsLoaded()
        {
            Assert.IsTrue(InspectionCreateTask.Instance.IsPageLoaded(),
                "The Inspection-Create task page is not loaded");
        }

        [Given(@"I include the location of '(.*)' product to the location field in Autostore Inspection-Create Task page")]
        public void GivenIIncludeTheLocationOfProductToTheLocationFieldInAutostoreInspection_CreateTaskPage(string extProductId)
        {
            _productLocation = ProductLocation.Instance.GetFirstProductLocation(extProductId);
            Assert.IsTrue(InspectionCreateTask.Instance.IncludeLocationValue(_productLocation),
                "Unable to include a location in Autostore Inspection-Create Task page");
        }

        [When(@"I click on confirm button in Autostore Inspection-Create Task page")]
        public void WhenIClickOnConfirmButtonInAutostoreInspection_CreateTaskPage()
        {
            Assert.IsTrue(InspectionCreateTask.Instance.ClickConfirmButton(),
                "Unable to click confirm button in Autostore Inspection-Create Task page");
        }

        [Then(@"The Autostore Inspection mission page is loaded")]
        public void ThenTheAutostoreInspectionMissionPageIsLoaded()
        {
            Assert.IsTrue(InspectionMission.Instance.IsPageLoaded(),
                "The Autostore Inspection mission page is not loaded");
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
                "the Location Quantity is not changed after Inspection");
        }

        [Then(@"I Select the reason code as '(.*)' in Autostore Inspection page")]
        public void ThenISelectTheSearchOnAsInAutostorePutawaySelectionPage(string reasonCode)
        {
            Assert.IsTrue(InspectionMission.Instance.SelectReasonCode(reasonCode),
                $"Unable to Select the reason code as {reasonCode} in Autostore Inspection page");
        }
    }
}
