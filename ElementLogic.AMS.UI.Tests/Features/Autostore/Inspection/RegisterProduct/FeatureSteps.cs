using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.RegisterProduct
{
    [Binding]
    public class FeatureSteps
    {
        [Given(@"I include an empty location to the location field in Autostore Inspection-Create Task page")]
        public void GivenIIncludeAnEmptyLocationToTheLocationFieldInAutostoreInspection_CreateTaskPage()
        {
            Assert.IsTrue(
                InspectionCreateTask.Instance.IncludeLocationValue(
                    ProductLocation.Instance.GetEmptyAutostoreLocation("A 1/1 AutoStore Bin")),
                "Unable to include an empty location to the location field in Autostore Inspection-Create Task page");
        }

        [When(@"I click on '(.*)' option item in Autostore Inspection mission page")]
        public void WhenIClickOnOptionItemInAutostoreInspectionMissionPage(string option)
        {
            Assert.IsTrue(InspectionMission.Instance.SelectOption(option),
                $"Unable to click on {option} option item in Autostore Inspection mission page");
        }

        [Then(@"The Register Product popup is loaded in Autostore Inspection mission page")]
        public void ThenTheRegisterProductPopupIsLoadedInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(RegisterProductPopup.Instance.IsPopupDisplayed(),
                "The Register Product popup is not loaded in Autostore Inspection mission page");
        }

        [Then(@"I select '(.*)' to the Product field on Autostore Inspection Register Product popup in Autostore Inspection mission page")]
        public void ThenISelectToTheProductFieldOnAutostoreInspectionRegisterProductPopupInAutostoreInspectionMissionPage(string productId)
        {
            Assert.IsTrue(RegisterProductPopup.Instance.SelectProduct(productId),
                $"Unable to select {productId} to the Product field on Autostore Inspection Register Product popup in Autostore Inspection mission page");
        }

        [Then(@"I include '(.*)' to the Location Quantity field in Autostore Inspection Register Product popup in Autostore Inspection mission page")]
        public void ThenIIncludeToTheLocationQuantityFieldInAutostoreInspectionRegisterProductPopupInAutostoreInspectionMissionPage(int quantity)
        {
            Assert.IsTrue(RegisterProductPopup.Instance.InsertQuantity(quantity),
                $"Unable to select {quantity} to the Product field on Autostore Inspection Register Product popup in Autostore Inspection mission page");
        }

        [When(@"I click the OK button in Autostore Inspection Register Product popup in Autostore Inspection mission page")]
        public void WhenIClickTheOkButtonInAutostoreInspectionRegisterProductPopupInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(RegisterProductPopup.Instance.ClickOkButton(),
                "Unable to click the OK button in Autostore Inspection Register Product popup in Autostore Inspection mission page");
        }
    }
}
