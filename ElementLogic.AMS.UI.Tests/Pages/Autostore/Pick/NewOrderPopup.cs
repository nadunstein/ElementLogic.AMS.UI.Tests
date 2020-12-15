using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class NewOrderPopup
    {
        private const string Iframe = ".rwTable > tbody > .rwContentRow > .rwWindowContent > iframe";

        private const string OkButton = "#ctl00_ContentPlaceHolder1_ctl00_btnExit";

        public static NewOrderPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public bool ClickOkButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(OkButton)
                .Click();
        }

        private NewOrderPopup() { }

        private static readonly Lazy<NewOrderPopup> Singleton =
            new Lazy<NewOrderPopup>(() => new NewOrderPopup());
    }
}
