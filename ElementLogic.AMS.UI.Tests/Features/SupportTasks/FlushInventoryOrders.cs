using System;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory;
using NUnit.Framework;
using AdminLogin = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class FlushInventoryOrders
    {
        public static FlushInventoryOrders Instance => Singleton.Value;

        public void FinishUnfinishedInventoryOrders()
        {
            var unFinishedInventoryOrdersCount = Order.Instance.GetUnFinishedInventoryOrdersCount();
            if (unFinishedInventoryOrdersCount == 0)
            {
                return;
            }

            FinishInventoryOrderSteps();
        }

        private static void FinishInventoryOrderSteps()
        {
            InventoryOrderList.Instance.Navigate();
            AdminLogin.Instance.LoginToApplicationIfNeeded("Admin");
            var isPageLoaded = InventoryOrderList.Instance.IsPageLoaded();
            var isClickedSearchButton = InventoryOrderList.Instance.ClickSearchButton();
            var isFirstInventoryResultBarDisplayed = InventoryOrderList.Instance.IsFirstInventoryResultBarDisplayed();
            var isSelectedAllCheckBox = InventoryOrderList.Instance.SelectAllCheckBox();
            var isSelectedActionMenuOption = InventoryOrderList.Instance.SelectActionMenuOption("Finish");
            var isPopupDisplayed = DeleteConfirmationPopup.Instance.IsPopupDisplayed();
            var isClickedYesButton = DeleteConfirmationPopup.Instance.ClickYesButton();

            var result = isPageLoaded && isClickedSearchButton && isFirstInventoryResultBarDisplayed &&
                         isSelectedAllCheckBox && isSelectedActionMenuOption && isPopupDisplayed && isClickedYesButton;
            Assert.IsTrue(result, "Unable to finish unfinished Inventory orders after the scenario");
        }

        private FlushInventoryOrders() { }

        private static readonly Lazy<FlushInventoryOrders>
            Singleton = new Lazy<FlushInventoryOrders>(() => new FlushInventoryOrders());
    }
}