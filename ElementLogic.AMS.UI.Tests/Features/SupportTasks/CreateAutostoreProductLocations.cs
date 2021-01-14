using System;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.TaskMenu;
using NUnit.Framework;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class CreateAutostoreProductLocations
    {
        public static CreateAutostoreProductLocations Instance => Singleton.Value;

        public void DoAutostorePutaway(string putawayTaskName, string productId, int productLocationMaxQuantity = 20)
        {
            if (!PutawaySelection.Instance.IsPageDisplayed())
            {
                NavigateToPutawaySelectionPageSteps(putawayTaskName);
            }

            AutostorePutawaySteps(productId, productLocationMaxQuantity);
        }

        private static void NavigateToPutawaySelectionPageSteps(string putawayTaskName)
        {
            LoginPage.Instance.NavigateToAutoStore("01");
            LoginPage.Instance.LoginToApplication("Admin");
            var isPageLoaded1 = AutostoreTaskMenu.Instance.IsPageLoaded();
            var isClickedPutawayTaskType = AutostoreTaskMenu.Instance.ClickPutawayTaskType(putawayTaskName);
            var isPageLoaded2 = PutawaySelection.Instance.IsPageLoaded();

            var result = isPageLoaded1 && isClickedPutawayTaskType && isPageLoaded2;
            Assert.IsTrue(result, "Unable to navigate to putaway selection page in TEST DATA PREPARATION");
        }

        private static void AutostorePutawaySteps(string productId, int productLocationMaxQuantity)
        {
            var isSelectedSearchOnDropdownValue = PutawaySelection.Instance.SelectSearchOnDropdownValue("Order line");
            var isInsertScanFieldValue = PutawaySelection.Instance.InsertScanFieldValue(productId);
            var isClickedEnterButton = PutawaySelection.Instance.ClickEnterButtonOnScanField();
            var isPopupDisplayed = PutawayConfirmQuantityPopup.Instance.IsPopupDisplayed();
            var isInsertedMaxLocationQuantity =
                PutawayConfirmQuantityPopup.Instance.InsertMaxLocationQuantity(productLocationMaxQuantity.ToString());
            var isClickedConfirmButton1 = PutawayConfirmQuantityPopup.Instance.ClickConfirmButton();
            var isPageLoaded1 = PutawayMission.Instance.IsPageLoaded();
            var isClickedConfirmButton2 = PutawayMission.Instance.ClickConfirmButton();
            var isPageLoaded2 = PutawaySelection.Instance.IsPageLoaded();

            var result = isSelectedSearchOnDropdownValue && isInsertScanFieldValue && isClickedEnterButton &&
                         isPopupDisplayed && isInsertedMaxLocationQuantity && isClickedConfirmButton1 &&
                         isPageLoaded1 && isClickedConfirmButton2 && isPageLoaded2;
            Assert.IsTrue(result, "Unable to create product data in TEST DATA PREPARATION");
        }

        private CreateAutostoreProductLocations() { }

        private static readonly Lazy<CreateAutostoreProductLocations> Singleton =
            new Lazy<CreateAutostoreProductLocations>(() => new CreateAutostoreProductLocations());
    }
}
