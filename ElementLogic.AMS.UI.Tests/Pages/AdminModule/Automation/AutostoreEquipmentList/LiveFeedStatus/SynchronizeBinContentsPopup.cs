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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public bool ClickSynchronizeButton()
        {
            return PageObjectHelper.Instance.Click(SynchronizeButton);
        }

        private SynchronizeTaskGroupsPopup() { }

        private static readonly Lazy<SynchronizeTaskGroupsPopup> Singleton =
            new Lazy<SynchronizeTaskGroupsPopup>(() => new SynchronizeTaskGroupsPopup());
    }
}
