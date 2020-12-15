using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch
{
    public class StartedMissionsPopup
    {
        private const string Popup = ".rwTable #divMessage";

        private const string YesButton = ".rwTable .btn-confirm";

        public static StartedMissionsPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(Popup);
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private StartedMissionsPopup() { }

        private static readonly Lazy<StartedMissionsPopup> Singleton =
            new Lazy<StartedMissionsPopup>(() => new StartedMissionsPopup());
    }
}
