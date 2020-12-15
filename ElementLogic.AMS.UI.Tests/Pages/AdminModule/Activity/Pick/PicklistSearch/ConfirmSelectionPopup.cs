using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Pick.PicklistSearch
{
    public class ConfirmSelectionPopup
    {
        private const string Iframe = "iframe";

        private const string ConfirmButton = "#ctl00_content_ConfirmSelectionView1_BtnConfirm";

        public static ConfirmSelectionPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Iframe)
                .IsVisible();
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .SwitchToIframe(Iframe)
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private ConfirmSelectionPopup() { }

        private static readonly Lazy<ConfirmSelectionPopup> Singleton =
            new Lazy<ConfirmSelectionPopup>(() => new ConfirmSelectionPopup());
    }
}
