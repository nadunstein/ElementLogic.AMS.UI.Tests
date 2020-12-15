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
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public bool ClickOkButton()
        {
            return FluentElement.Instance
                .WaitForElement(OkButton)
                .Click();
        }

        private NoMoreTasksPopup() { }

        private static readonly Lazy<NoMoreTasksPopup> Singleton =
            new Lazy<NoMoreTasksPopup>(() => new NoMoreTasksPopup());
    }
}
