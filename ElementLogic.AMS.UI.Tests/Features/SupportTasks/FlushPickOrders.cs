using System;
using System.Threading;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch;
using NUnit.Framework;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class FlushPickOrders
    {
        public static FlushPickOrders Instance => Singleton.Value;

        public void FinishUnfinishedPickOrders()
        {
            var pickOrdersToBeFinished = Order.Instance.GetUnFinishedPickOrders();
            if (pickOrdersToBeFinished.Count.Equals(0))
            {
                return;
            }

            PicklistSearch.Instance.Navigate();
            Pages.Login.Login.Instance.LoginToApplication("Admin");
            Assert.AreEqual("Pick list search", PicklistSearch.Instance.GetPageTitle(),
                "The Pick list search page is not loaded to finish unfinished pick orders");

            var unfinishedPickOrderStatus = Order.Instance.GetFirstUnFinishedPickOrderStatus();
            while (unfinishedPickOrderStatus != null)
            {
                PicklistSearch.Instance.SelectOrderStatus(int.Parse(unfinishedPickOrderStatus));
                PicklistSearch.Instance.ClickSearchButton();
                PicklistSearch.Instance.IsFirstPicklistResultBarDisplayed();
                PicklistSearch.Instance.SelectAllCheckBox();
                PicklistSearch.Instance.SelectActionMenuOption("Finish");
                var pickOrderCountForOrderStatus =
                    Order.Instance.GetUnFinishedPickOrderCount(int.Parse(unfinishedPickOrderStatus));
                if (pickOrderCountForOrderStatus > 1)
                {
                    ConfirmSelectionPopup.Instance.IsPopupDisplayed();
                    ConfirmSelectionPopup.Instance.ClickConfirmButton();
                }

                WaitAndConfirmStartedMissionsPopup();
                PicklistSearch.Instance.RefreshWebPage();
                Assert.AreEqual("Pick list search", PicklistSearch.Instance.GetPageTitle());
                unfinishedPickOrderStatus = Order.Instance.GetFirstUnFinishedPickOrderStatus();
            } 
        }

        private static void WaitAndConfirmStartedMissionsPopup()
        {
            for (var i = 0; i < 20; i++)
            {
                var startedMissionsPopupDisplayed = StartedMissionsPopup.Instance.IsPopupDisplayed();
                var noRecordsToShowLabelDisplayed = PicklistSearch.Instance.IsNoRecordsToShowLabelDisplayed();

                if (startedMissionsPopupDisplayed)
                {
                    StartedMissionsPopup.Instance.ClickYesButton();
                    break;
                }

                if (noRecordsToShowLabelDisplayed)
                {
                    break;
                }

                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }

        private FlushPickOrders() { }

        private static readonly Lazy<FlushPickOrders>
            Singleton = new Lazy<FlushPickOrders>(() => new FlushPickOrders());
    }
}
