using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class ChangeQuantityPopup
    {
        private const string Popup = ".rwTable";

        private const string YesButton = "#asMasterRadConfirmYesButton";

        public static ChangeQuantityPopup Instance => Singleton.Value;

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

        private ChangeQuantityPopup() { }

        private static readonly Lazy<ChangeQuantityPopup> Singleton =
            new Lazy<ChangeQuantityPopup>(() => new ChangeQuantityPopup());
    }
}
