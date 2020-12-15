using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class SynchronizeTaskGroupsPopup
    {
        private const string Popup = "#swal2-title";
        
        private const string SynchronizeButton = ".swal2-confirm";

        public static SynchronizeTaskGroupsPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public bool ClickSynchronizeButton()
        {
            return FluentElement.Instance
                .WaitForElement(SynchronizeButton)
                .Click();
        }

        private SynchronizeTaskGroupsPopup() { }

        private static readonly Lazy<SynchronizeTaskGroupsPopup> Singleton =
            new Lazy<SynchronizeTaskGroupsPopup>(() => new SynchronizeTaskGroupsPopup());
    }
}
