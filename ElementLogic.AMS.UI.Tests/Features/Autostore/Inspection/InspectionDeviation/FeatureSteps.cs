using ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Inspection.InspectionDeviation
{
    [Binding]
    public class FeatureSteps
    {
        [Then(@"The Change Quantity dialog is displayed in Autostore Inspection mission page")]
        public void ThenTheChangeQuantityDialogIsDisplayedInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(ChangeQuantityPopup.Instance.IsPopupDisplayed(),
                "The Change Quantity dialog is not displayed in Autostore Inspection mission page");
        }

        [When(@"I Click on YES button on Change Quantity dialog in Autostore Inspection mission page")]
        public void WhenIClickOnYesButtonOnChangeQuantityDialogInAutostoreInspectionMissionPage()
        {
            Assert.IsTrue(ChangeQuantityPopup.Instance.ClickYesButton(),
                "Unable to Click on YES button on Change Quantity dialog in Autostore Inspection mission page");
        }
    }
}
