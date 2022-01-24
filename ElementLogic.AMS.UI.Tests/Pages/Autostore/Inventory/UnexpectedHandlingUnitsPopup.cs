
using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inventory
{
    public class UnexpectedHandlingUnitsPopup
    {
        private const string Iframe = "iframe";

        private const string FirstPopupMessage = "#ctl00_ctl00_ContentPlaceHolder1_ctl00_FormDataPanelPanel .as-popup-title";

        private const string SecondPopupMessage = "#ctl00_ctl00_ContentPlaceHolder1_ctl00_FormDataPanelPanel .as-popup-content";

        private const string RegisterButton = "#ctl00_ContentPlaceHolder1_ctl00_btnRegister";

        private const string RemoveFromBinButton = "#ctl00_ContentPlaceHolder1_ctl00_btnRemove";

        public static UnexpectedHandlingUnitsPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public string GetFirstPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(FirstPopupMessage)
                .GetText();
        }

        public string GetSecondPopupMessage()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(SecondPopupMessage)
                .GetText();
        }

        public bool ClickPopupButton(string buttonToBeClicked)
        {
            return buttonToBeClicked switch
            {
                "Register" => ClickRegisterButton(),
                "Remove from bin" => ClickRemoveFromBinButton(),
                _ => false
            };
        }

        private static bool ClickRegisterButton()
        {
            return FluentElement.Instance
                .WaitForElement(RegisterButton)
                .Click();
        }

        private static bool ClickRemoveFromBinButton()
        {
            return FluentElement.Instance
                .WaitForElement(RemoveFromBinButton)
                .Click();
        }

        private UnexpectedHandlingUnitsPopup() { }

        private static readonly Lazy<UnexpectedHandlingUnitsPopup> Singleton =
            new Lazy<UnexpectedHandlingUnitsPopup>(() => new UnexpectedHandlingUnitsPopup());
    }
}
