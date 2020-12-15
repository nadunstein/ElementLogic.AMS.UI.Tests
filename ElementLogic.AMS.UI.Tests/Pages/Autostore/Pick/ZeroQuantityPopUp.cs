using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class ZeroQuantityPopUp
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#ctl00_ContentPlaceHolder1_ctl00_BinQtyIsEmptyLocation";

        private const string YesButton = "#locationEmpty";

        private const string NoButton = "#locationNotEmpty";

        public static ZeroQuantityPopUp Instance => Singleton.Value;

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

        public bool ClickYesButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(YesButton)
                .Click();
        }

        public bool ClickNoButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(NoButton)
                .Click();
        }

        private ZeroQuantityPopUp() { }

        private static readonly Lazy<ZeroQuantityPopUp> Singleton =
            new Lazy<ZeroQuantityPopUp>(() => new ZeroQuantityPopUp());
    }
}
