using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.UserActivity
{
    public class StartedMissionsPopup
    {
        private const string Popup = ".rwTable";

        private const string PopupMessage = "#divMessage";

        private const string YesButton = ".rwTable .col-md-8 span";

        private const string NoButton = ".rwTable .col-md-4 span";

        public static StartedMissionsPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public string GetPopupMessage()
        {
            return FluentElement.Instance
                .WaitForElement(PopupMessage)
                .GetText();
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            var isButtonClicked = buttonToBeClicked switch
            {
                "Yes" => ClickYesButton(),
                "No" => ClickNoButton(),
                _ => false
            };

            return isButtonClicked;
        }

        private static bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private static bool ClickNoButton()
        {
            return FluentElement.Instance
                .WaitForElement(NoButton)
                .Click();
        }

        private StartedMissionsPopup() { }

        private static readonly Lazy<StartedMissionsPopup> Singleton =
            new Lazy<StartedMissionsPopup>(() => new StartedMissionsPopup());
    }
}
