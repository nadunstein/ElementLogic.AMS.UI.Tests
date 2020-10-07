using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class NoMoreTasksPopup
    {
        private const string Popup = ".rwTable";

        private const string OkButton = "#radAlertOkButton";

        public static NoMoreTasksPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            var isPopupDisplayed = PageObjectHelper.Instance.IsDisplayed(Popup, true);
            return isPopupDisplayed;
        }

        public bool IsPopupLoaded()
        {
            return PageObjectHelper.Instance.IsDisplayed(Popup);
        }

        public bool IsOkButtonDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(OkButton);
        }

        public bool ClickOkButton()
        {
            return PageObjectHelper.Instance.Click(OkButton);
        }

        private NoMoreTasksPopup() { }

        private static readonly Lazy<NoMoreTasksPopup> Singleton =
            new Lazy<NoMoreTasksPopup>(() => new NoMoreTasksPopup());
    }
}
