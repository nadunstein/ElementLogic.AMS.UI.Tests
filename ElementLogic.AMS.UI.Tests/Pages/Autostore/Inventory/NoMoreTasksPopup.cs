using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory
{
    public class NoMoreTasksPopup
    {
        private const string Popup = ".rwTable";

        private const string OkButton = "#radAlertOkButton";

        public static NoMoreTasksPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
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
