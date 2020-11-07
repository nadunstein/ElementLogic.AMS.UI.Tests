using System;
using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.SupportTasks
{
    public class SynchronizeTaskGroups
    {
        public static SynchronizeTaskGroups Instance => Singleton.Value;

        public void DoAutostoreTaskGroupSync()
        {
            LiveFeedStatus.Instance.Navigate();
            LoginPage.Instance.LoginToApplication("Admin");
            LiveFeedStatus.Instance.IsPageLoaded();
            LiveFeedStatus.Instance.SelectActionDropDownOption("Synchronize task groups");
            SynchronizeTaskGroupsPopup.Instance.IsPopupDisplayed();
            SynchronizeTaskGroupsPopup.Instance.ClickSynchronizeButton();
        }

        private SynchronizeTaskGroups() { }

        private static readonly Lazy<SynchronizeTaskGroups> Singleton =
            new Lazy<SynchronizeTaskGroups>(() => new SynchronizeTaskGroups());
    }
}
