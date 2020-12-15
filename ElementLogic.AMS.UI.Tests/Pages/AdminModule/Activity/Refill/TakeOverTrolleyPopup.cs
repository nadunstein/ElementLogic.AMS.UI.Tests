using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Refill
{
    public class TakeOverTrolleyPopup
    {
        private const string Popup = ".rwTable";

        private const string YesButton = ".btn-confirm";

        public static TakeOverTrolleyPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .WaitForElement(YesButton)
                .Click();
        }

        private TakeOverTrolleyPopup() { }

        private static readonly Lazy<TakeOverTrolleyPopup> Singleton =
            new Lazy<TakeOverTrolleyPopup>(() => new TakeOverTrolleyPopup());
    }
}
