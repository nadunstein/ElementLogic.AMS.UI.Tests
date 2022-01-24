using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Pick
{
    public class RemainingQuantityChangedPopup
    {
        private const string Iframe = "iframe";

        private const string PopUpMessage = "#ctl00_ContentPlaceHolder1_ctl00_lblBinQuantityDifferFromRegistered";

        private const string YesButton = "#continueWithEnteredQuantity";

        private const string NoButton = "#cancelEnteredQuantity";

        public static RemainingQuantityChangedPopup Instance => Singleton.Value;

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

        public bool ClickPopupButton(string button)
        {
            return button switch
            {
                "Yes" => ClickYesButton(),
                "No" => ClickNoButton(),
                _ => false
            };
        }

        private static bool ClickYesButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(YesButton)
                .Click();
        }

        private static bool ClickNoButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(NoButton)
                .Click();
        }

        private RemainingQuantityChangedPopup() { }

        private static readonly Lazy<RemainingQuantityChangedPopup> Singleton =
            new Lazy<RemainingQuantityChangedPopup>(() => new RemainingQuantityChangedPopup());
    }
}
