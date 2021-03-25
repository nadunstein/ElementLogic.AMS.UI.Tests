using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection
{
    public class PutawayConfirmQuantityPopup
    {
        private const string Popup =
            "#RadWindowWrapper_ctl00_MonitorContentPlaceholder_putawayselectionview_modalPopup";

        private const string PutawayQuantityField =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_modalPopup_C_txtPutawayQty";

        private const string MaxLocationQuantityField =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_modalPopup_C_txtMaxBinQuantity";

        private const string ConfirmButton =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_modalPopup_C_btnConfirm";

        public static PutawayConfirmQuantityPopup Instance => Singleton.Value;

        public bool IsPopupDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(Popup)
                .IsVisible();
        }

        public bool IsPutawayQuantityFieldDisplayed()
        {
            return FluentElement.Instance
                .IsVisible(PutawayQuantityField);
        }

        public bool IsPutawayQuantityFieldFocused()
        {
            return FluentElement.Instance
                .WaitForElement(PutawayQuantityField)
                .IsFocused();
        }

        public int GetPutawayQuantity()
        {
            return int.Parse(FluentElement.Instance
                .WaitForElement(PutawayQuantityField)
                .GetAttribute("Value"));
        }

        public int GetMaximumLocationQuantity()
        {
            return int.Parse(FluentElement.Instance
                .WaitForElement(MaxLocationQuantityField)
                .GetAttribute("Value"));
        }

        public bool InsertMaxLocationQuantity(string quantity)
        {
            var isFieldFocused = FluentElement.Instance
                .WaitForElement(MaxLocationQuantityField)
                .IsFocused();
            if (!isFieldFocused)
            {
                FluentElement.Instance
                    .WaitForElement(PutawayQuantityField)
                    .ClickTabButton();    
            }

            return FluentElement.Instance
                .WaitForElement(MaxLocationQuantityField)
                .Insert(quantity);
        }

        public bool InsertPutawayQuantity(string quantity)
        {
            return FluentElement.Instance
                .WaitForElement(PutawayQuantityField)
                .Insert(quantity);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private PutawayConfirmQuantityPopup() { }

        private static readonly Lazy<PutawayConfirmQuantityPopup> Singleton =
            new Lazy<PutawayConfirmQuantityPopup>(() => new PutawayConfirmQuantityPopup());
    }
}
