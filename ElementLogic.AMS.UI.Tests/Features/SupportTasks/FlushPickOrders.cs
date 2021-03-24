using System;
using System.Threading;
using ElementLogic.AMS.UI.Tests.Data.DatabaseQueries;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch;
using NUnit.Framework;
using AdminLogin = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class FlushPickOrders
    {
        public static FlushPickOrders Instance => Singleton.Value;

        public void FinishUnfinishedPickOrders()
        {
            var pickOrdersToBeFinishedCount = Order.Instance.GetUnFinishedPickOrders().Count;
            if (pickOrdersToBeFinishedCount == 0)
            {
                return;
            }

            NavigatePicklistSearchPageSteps();
            var unfinishedPickOrderStatus = Order.Instance.GetFirstUnFinishedPickOrderStatus();
            while (unfinishedPickOrderStatus != null)
            {
                ClickFinishActionMenuOptionSteps(unfinishedPickOrderStatus);
                ConfirmConfirmSelectionPopup(unfinishedPickOrderStatus);
                WaitAndConfirmStartedMissionsPopup();
                RefreshPicklistSearchPageSteps();
                unfinishedPickOrderStatus = Order.Instance.GetFirstUnFinishedPickOrderStatus();
            }
        }

        private static void NavigatePicklistSearchPageSteps()
        {
            PicklistSearch.Instance.Navigate();
            AdminLogin.Instance.LoginToApplicationIfNeeded("Admin");
            Assert.IsTrue(PicklistSearch.Instance.IsPageLoaded(),
                "The Pick list search page is not loaded to finish unfinished pick orders after scenario");
        }

        private static void ClickFinishActionMenuOptionSteps(string unfinishedPickOrderStatus)
        {
            PicklistSearch.Instance.SelectOrderStatus(int.Parse(unfinishedPickOrderStatus));
            PicklistSearch.Instance.ClickSearchButton();
            PicklistSearch.Instance.IsFirstPicklistResultBarDisplayed();
            PicklistSearch.Instance.SelectAllCheckBox();
            PicklistSearch.Instance.SelectActionMenuOption("Finish");
        }

        private static void RefreshPicklistSearchPageSteps()
        {
            PicklistSearch.Instance.RefreshWebPage();
            PicklistSearch.Instance.IsPageLoaded();
        }

        private static void ConfirmConfirmSelectionPopup(string unfinishedPickOrderStatus)
        {
            var pickOrderCountForOrderStatus =
                Order.Instance.GetUnFinishedPickOrderCount(int.Parse(unfinishedPickOrderStatus));
            if (pickOrderCountForOrderStatus <= 1)
            {
                return;
            }

            ConfirmSelectionPopup.Instance.IsPopupDisplayed();
            ConfirmSelectionPopup.Instance.ClickConfirmButton();
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
