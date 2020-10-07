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
            if (!PutawaySelection.Instance.IsPageLoaded())
            {
                LoginPage.Instance.NavigateToAutoStore("01");
                LoginPage.Instance.LoginToApplication("Admin");

                AutostoreTaskMenu.Instance.ClickPutawayTaskType(putawayTaskName);
                Assert.AreEqual("Putaway selection", PutawaySelection.Instance.GetPageTitle(),
                    "The putaway selection page is not displayed");
            }

            Assert.IsTrue(PutawaySelection.Instance.SelectSearchOnDropdownValue("Order line"),
                "Unable to select search on dropdown value on putaway selection page in TEST DATA PREPARATION");
            Assert.IsTrue(PutawaySelection.Instance.InsertScanFieldValue(productId),
                "Unable to insert product id to scan field on putaway selection page in TEST DATA PREPARATION");
            PutawaySelection.Instance.ClickEnterButtonOnScanField();
            Assert.True(PutawayConfirmQuantityPopup.Instance.IsPopupDisplayed(),
                "The Autostore putaway quantity confirm popup is not displayed in TEST DATA PREPARATION");
            Assert.IsTrue(
                PutawayConfirmQuantityPopup.Instance.InsertMaxLocationQuantity(productLocationMaxQuantity.ToString()),
                "Unable to Insert max location quantity on Putaway confirm quantity popup on putaway selection page in TEST DATA PREPARATION");
            Assert.IsTrue(PutawayConfirmQuantityPopup.Instance.ClickConfirmButton(),
                "Unable to click on Confirm button on Putaway confirm quantity popup on putaway selection page in TEST DATA PREPARATION");
            Assert.AreEqual("Putaway", PutawayMission.Instance.GetPageTitle(),
                "Autostore Putaway mission page is not loaded in TEST DATA PREPARATION");
            PutawayMission.Instance.ClickEnterButtonOnQuantityField();
            Assert.AreEqual("Putaway selection", PutawaySelection.Instance.GetPageTitle(),
                "The putaway selection page is not displayed in TEST DATA PREPARATION");
        }

        private CreateAutostoreProductLocations() { }

        private static readonly Lazy<CreateAutostoreProductLocations> Singleton =
            new Lazy<CreateAutostoreProductLocations>(() => new CreateAutostoreProductLocations());
    }
}
