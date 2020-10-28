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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public string GetPopupMessage()
        {
            return PageObjectHelper.Instance.GetTextValue(PopupMessage);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        public bool ClickNoButton()
        {
            return PageObjectHelper.Instance.Click(NoButton);
        }

        private StartedMissionsPopup() { }

        private static readonly Lazy<StartedMissionsPopup> Singleton =
            new Lazy<StartedMissionsPopup>(() => new StartedMissionsPopup());
    }
}
