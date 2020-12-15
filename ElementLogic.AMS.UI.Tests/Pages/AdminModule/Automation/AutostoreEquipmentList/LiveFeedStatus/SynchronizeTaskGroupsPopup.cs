using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class SynchronizeBinContentsPopup
    {
        private const string PopupTitle = "#swal2-title";
        
        private const string SynchronizeButton = ".swal2-confirm";

        public static SynchronizeBinContentsPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(PopupTitle)
                .IsVisible();
        }

        public bool ClickSynchronizeButton()
        {
            return FluentElement.Instance
                .WaitForElement(SynchronizeButton)
                .Click();
        }

        private SynchronizeBinContentsPopup() { }

        private static readonly Lazy<SynchronizeBinContentsPopup> Singleton =
            new Lazy<SynchronizeBinContentsPopup>(() => new SynchronizeBinContentsPopup());
    }
}
