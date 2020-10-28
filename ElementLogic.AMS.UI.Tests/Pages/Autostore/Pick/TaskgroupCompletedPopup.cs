using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class TaskgroupCompletedPopup
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#ctl00_ContentPlaceHolder1_ctl00_Panel1 .as-popup-title";

        private const string ContinueButton = "#ctl00_ContentPlaceHolder1_ctl00_btnContinue";

        private const string ExitButton = "#ctl00_ContentPlaceHolder1_ctl00_btnExit";

        public static TaskgroupCompletedPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Iframe, true);
        }

        public string GetPopupMessage()
        {
            PageObjectHelper.Instance.SwitchToIframeContent(Iframe);
            return PageObjectHelper.Instance.GetTextValue(PopUpMessage);
        }

        public bool ClickContinueButton()
        {
            var isContinueButtonClicked = PageObjectHelper.Instance.Click(ContinueButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isContinueButtonClicked;
        }

        public bool ClickExitButton()
        {
            var isExitButtonClicked = PageObjectHelper.Instance.Click(ExitButton);
            PageObjectHelper.Instance.SwitchToDefaultWebPage();
            return isExitButtonClicked;
        }

        private TaskgroupCompletedPopup() { }

        private static readonly Lazy<TaskgroupCompletedPopup> Singleton =
            new Lazy<TaskgroupCompletedPopup>(() => new TaskgroupCompletedPopup());
    }
}
