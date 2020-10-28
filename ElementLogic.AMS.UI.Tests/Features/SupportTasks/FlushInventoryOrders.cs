using System;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Inventory;
using NUnit.Framework;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class FlushInventoryOrders
    {
        public static FlushInventoryOrders Instance => Singleton.Value;

        public void FinishUnfinishedInventoryOrders()
        {
            if (Order.Instance.GetUnFinishedInventoryOrdersCount().Equals(0))
            {
                return;
            }

            InventoryOrderList.Instance.Navigate();
            Pages.Login.Login.Instance.LoginToApplication("Admin");
            Assert.AreEqual("Inventory order list", InventoryOrderList.Instance.GetPageTitle(),
                "The Inventory order list page is not loaded to finish unfinished Inventory orders");
            InventoryOrderList.Instance.ClickSearchButton();
            InventoryOrderList.Instance.IsFirstInventoryResultBarDisplayed();
            InventoryOrderList.Instance.SelectAllCheckBox();
            InventoryOrderList.Instance.SelectActionMenuOption("Delete");
            DeleteConfirmationPopup.Instance.IsPopupDisplayed();
            DeleteConfirmationPopup.Instance.ClickYesButton();
        }

        private FlushInventoryOrders() { }

        private static readonly Lazy<FlushInventoryOrders>
            Singleton = new Lazy<FlushInventoryOrders>(() => new FlushInventoryOrders());
    }
}