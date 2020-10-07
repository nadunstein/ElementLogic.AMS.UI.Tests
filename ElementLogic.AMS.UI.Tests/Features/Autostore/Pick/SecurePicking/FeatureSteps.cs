using ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Pick.SecurePicking
{
    [Binding]
    public class FeatureSteps
    {
        [Then(@"I verify the confirm quantity field is displayed in Autostore Pick Mission page")]
        public void ThenIVerifyTheConfirmQuantityFieldIsDisplayedInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.IsConfirmQuantityFieldDisplayed(),
                "The confirm quantity field is not displayed in Autostore Pick Mission page");
        }

        [Then(@"I verify the focus is on the confirm quantity field in Autostore Pick Mission page")]
        public void ThenIVerifyTheFocusIsOnTheConfirmQuantityFieldInAutostorePickMissionPage()
        {
            Assert.IsTrue(PickMission.Instance.IsConfirmQuantityFieldFocused(),
                "The focus is not on the confirm quantity field in Autostore Pick Mission page");
        }

        [Then(@"I include the pick quantity to confirm quantity field in Autostore Pick Mission page")]
        public void ThenIIncludeThePickQuantityToConfirmQuantityFieldInAutostorePickMissionPage()
        {
            var pickQuantityValue = PickMission.Instance.GetPickQuantityFieldValue().ToString();
            Assert.IsTrue(PickMission.Instance.InsertConfirmQuantity(pickQuantityValue),
                "Unable to include the pick quantity to confirm quantity field in Autostore Pick Mission page");
        }
    }
}
