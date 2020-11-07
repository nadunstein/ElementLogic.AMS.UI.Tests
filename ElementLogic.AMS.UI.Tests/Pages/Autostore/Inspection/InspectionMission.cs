using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Inspection
{
    public class InspectionMission
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_pnlDataHider .ModalLoadingPanel";

        private const string ProductNumberLabel =
            "#ctl00_MonitorContentPlaceholder_InspectionView_flbProdNo_InputTemplateItem_txtProdNo";

        private const string InspectionQuantityField = "#ctl00_MonitorContentPlaceholder_InspectionView_txtBinQuantity";

        private const string ReasonCodeDropdown = "#ctl00_MonitorContentPlaceholder_InspectionView_cboReasons_Input";

        private const string ReasonCodeDropdownPanel =
            "#ctl00_MonitorContentPlaceholder_InspectionView_cboReasons_DropDown .rcbList";

        private const string OptionsButton =
            "#ctl00_ctl00_MonitorContentPlaceholder_InspectionView_rtbOptionsPanel";

        private const string OptionsList = ".rtbSlide";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_InspectionView_btnConfirm";

        public static InspectionMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Inspection", LoadingPanel);
        }

        public string GetProductNumberLabelValue()
        {
            return PageObjectHelper.Instance.GetAttributeValue(ProductNumberLabel, "Value");
        }

        public bool IncludeLocationQuantityValue(int quantity)
        {
            return PageObjectHelper.Instance.InsertField(InspectionQuantityField, quantity.ToString());
        }

        public bool SelectReasonCode(string value)
        {
            if (PageObjectHelper.Instance.GetAttributeValue(ReasonCodeDropdown, "value").Equals(value))
            {
                return true;
            }

            return PageObjectHelper.Instance.SelectDropDown(ReasonCodeDropdown, 
                ReasonCodeDropdownPanel, "li", value);
        }

        public bool SelectOption(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(OptionsButton, 
                OptionsList, ".rtbText", value);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton, true);
        }

        private InspectionMission() { }

        private static readonly Lazy<InspectionMission> Singleton =
            new Lazy<InspectionMission>(() => new InspectionMission());
    }
}
