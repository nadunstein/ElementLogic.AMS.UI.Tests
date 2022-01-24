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

        public void DoAutostorePutaway(string putawayTaskName, string productId, bool isHandlingUnitProduct, bool useSameLocation)
        {
            if (!PutawaySelection.Instance.IsPageDisplayed())
            {
                NavigateToPutawaySelectionPageSteps(putawayTaskName);
            }

            AutostorePutawaySteps(productId, isHandlingUnitProduct, useSameLocation);
        }

        private static void NavigateToPutawaySelectionPageSteps(string putawayTaskName)
        {
            var retryCount = 0;
            while (true)
            {
                retryCount++;
                LoginPage.Instance.NavigateToAutoStore("01");
                LoginPage.Instance.LoginToApplicationIfNeeded("Admin");
                var isUserLoggedIn = AutostoreTaskMenu.Instance.IsPageLoaded();
                var isPutawayTaskClicked = AutostoreTaskMenu.Instance.ClickPutawayTaskType(putawayTaskName);
                var isPutawaySelectionPageLoaded = PutawaySelection.Instance.IsPageLoaded();

                if (retryCount == 5)
                {
                    Assert.Fail("Unable to navigate to Putaway selection page in TEST DATA PREPARATION");
                }

                if (!isUserLoggedIn && !isPutawayTaskClicked && !isPutawaySelectionPageLoaded)
                {
                    continue;
                }

                break;
            }
        }

        private static void AutostorePutawaySteps(string productId, bool isHandlingUnitProduct, bool useSameLocation)
        {
            const int productLocationMaxQuantity = 20;

            Assert.IsTrue(PutawaySelection.Instance.SelectSearchOnDropdownValue("Order line"),
                "Unable to select search on dropdown value on putaway selection page in TEST DATA PREPARATION");
            Assert.IsTrue(PutawaySelection.Instance.InsertScanFieldValue(productId),
                "Unable to insert product id to scan field on putaway selection page in TEST DATA PREPARATION");
            PutawaySelection.Instance.ClickEnterButtonOnScanField();
            if (!useSameLocation && !isHandlingUnitProduct)
            {
                Assert.True(PutawayConfirmQuantityPopup.Instance.IsPopupDisplayed(),
                    "The Autostore putaway quantity confirm popup is not displayed in TEST DATA PREPARATION");
                Assert.IsTrue(
                    PutawayConfirmQuantityPopup.Instance.InsertMaxLocationQuantity(productLocationMaxQuantity.ToString()),
                    "Unable to Insert max location quantity on Putaway confirm quantity popup on putaway selection page in TEST DATA PREPARATION");
                Assert.IsTrue(PutawayConfirmQuantityPopup.Instance.ClickConfirmButton(),
                    "Unable to click on Confirm button on Putaway confirm quantity popup on putaway selection page in TEST DATA PREPARATION");
            }

           
            Assert.IsTrue(PutawayMission.Instance.IsPageLoaded(),
                "The Autostore putaway mission page is not displayed in TEST DATA PREPARATION");
            if (useSameLocation)
            {
                Assert.IsTrue(PutawayMission.Instance.ClickPutawayMoreButton(),
                    "Unable to click on Putaway More button on putaway mission page in TEST DATA PREPARATION");
            }
            else
            {
                Assert.IsTrue(PutawayMission.Instance.ClickConfirmButton(),
                    "Unable to click on Confirm button on putaway mission page in TEST DATA PREPARATION");
            }

           
            Assert.IsTrue(PutawaySelection.Instance.IsPageLoaded(),
                "The putaway selection page is not displayed in TEST DATA PREPARATION");
        }

        private CreateAutostoreProductLocations() { }

        private static readonly Lazy<CreateAutostoreProductLocations> Singleton =
            new Lazy<CreateAutostoreProductLocations>(() => new CreateAutostoreProductLocations());
    }
}
