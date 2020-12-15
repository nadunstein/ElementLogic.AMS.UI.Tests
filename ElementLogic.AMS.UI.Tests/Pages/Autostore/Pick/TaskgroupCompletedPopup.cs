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
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(PopUpMessage)
                .GetText();
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            return buttonToBeClicked switch
            {
                "Continue" => ClickContinueButton(),
                "Exit" => ClickExitButton(),
                _ => false
            };
        }

        private static bool ClickContinueButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ContinueButton)
                .Click();
        }

        private static bool ClickExitButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ExitButton)
                .Click();
        }

        private TaskgroupCompletedPopup() { }

        private static readonly Lazy<TaskgroupCompletedPopup> Singleton =
            new Lazy<TaskgroupCompletedPopup>(() => new TaskgroupCompletedPopup());
    }
}
