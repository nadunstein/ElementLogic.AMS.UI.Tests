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
            return PageObjectHelper.Instance.IsDisplayed(Popup, true);
        }

        public bool IsPutawayQuantityFieldDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(PutawayQuantityField);
        }

        public bool IsPutawayQuantityFieldFocused()
        {
            return PageObjectHelper.Instance.IsFocused(PutawayQuantityField);
        }

        public double GetPutawayQuantity()
        {
            return double.Parse(PageObjectHelper.Instance.GetAttributeValue(PutawayQuantityField, "Value"));
        }

        public bool InsertMaxLocationQuantity(string quantity)
        {
            var isFieldFocused = PageObjectHelper.Instance.IsFocused(MaxLocationQuantityField);
            if (!isFieldFocused)
            {
                PageObjectHelper.Instance.ClickTabButton(PutawayQuantityField);    
            }

            return PageObjectHelper.Instance.InsertField(MaxLocationQuantityField, quantity);
        }

        public bool InsertPutawayQuantity(string quantity)
        {
            return PageObjectHelper.Instance.InsertField(PutawayQuantityField, quantity);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        private PutawayConfirmQuantityPopup() { }

        private static readonly Lazy<PutawayConfirmQuantityPopup> Singleton =
            new Lazy<PutawayConfirmQuantityPopup>(() => new PutawayConfirmQuantityPopup());
    }
}
