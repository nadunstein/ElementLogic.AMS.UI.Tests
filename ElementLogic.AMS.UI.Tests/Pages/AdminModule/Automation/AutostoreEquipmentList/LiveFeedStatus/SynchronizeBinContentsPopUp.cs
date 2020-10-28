using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class SynchronizeTaskGroupsPopUp
    {
        private const string Popup = "#swal2-title";
        
        private const string SynchronizeButton = ".swal2-confirm";

        public static SynchronizeTaskGroupsPopUp Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public bool ClickSynchronizeButton()
        {
            return PageObjectHelper.Instance.Click(SynchronizeButton);
        }

        private SynchronizeTaskGroupsPopUp() { }

        private static readonly Lazy<SynchronizeTaskGroupsPopUp> Singleton =
            new Lazy<SynchronizeTaskGroupsPopUp>(() => new SynchronizeTaskGroupsPopUp());
    }
}
