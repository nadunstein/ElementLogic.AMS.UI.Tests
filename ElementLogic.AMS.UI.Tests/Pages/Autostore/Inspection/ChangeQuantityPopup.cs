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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public bool ClickYesButton()
        {
            return PageObjectHelper.Instance.Click(YesButton);
        }

        private ChangeQuantityPopup() { }

        private static readonly Lazy<ChangeQuantityPopup> Singleton =
            new Lazy<ChangeQuantityPopup>(() => new ChangeQuantityPopup());
    }
}
