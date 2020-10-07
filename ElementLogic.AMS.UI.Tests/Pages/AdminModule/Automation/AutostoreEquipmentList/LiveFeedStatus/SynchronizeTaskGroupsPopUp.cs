using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Automation.AutostoreEquipmentList.LiveFeedStatus
{
    public class SynchronizeBinContentsPopUp
    {
        private const string PopupTitle = "#swal2-title";
        
        private const string SynchronizeButton = ".swal2-confirm";

        public static SynchronizeBinContentsPopUp Instance => Singleton.Value;

        public string GetPopUpTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PopupTitle, true);
        }

        public bool ClickSynchronizeButton()
        {
            return PageObjectHelper.Instance.Click(SynchronizeButton);
        }

        private SynchronizeBinContentsPopUp() { }

        private static readonly Lazy<SynchronizeBinContentsPopUp> Singleton =
            new Lazy<SynchronizeBinContentsPopUp>(() => new SynchronizeBinContentsPopUp());
    }
}
