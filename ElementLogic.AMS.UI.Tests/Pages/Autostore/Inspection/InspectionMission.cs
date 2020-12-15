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
            "#ctl00_MonitorContentPlaceholder_InspectionView_rtbOptions";

        private const string OptionsList = ".rtbSlide";

        private const string ConfirmButton = "#ctl00_MonitorContentPlaceholder_InspectionView_btnConfirm";

        public static InspectionMission Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Inspection");
        }

        public string GetProductNumberLabelValue()
        {
            return FluentElement.Instance
                .WaitForElement(ProductNumberLabel)
                .GetAttribute("Value");
        }

        public bool IncludeLocationQuantityValue(int quantity)
        {
            var quantityString = quantity.ToString();
            return FluentElement.Instance
                .WaitForElement(InspectionQuantityField)
                .Insert(quantityString);
        }

        public bool SelectReasonCode(string value)
        {
            if (FluentElement.Instance
                .WaitForElement(ReasonCodeDropdown)
                .GetAttribute("value")
                .Equals(value))
            {
                return true;
            }

            return FluentElement.Instance
                .WaitForElement(ReasonCodeDropdown)
                .SelectDropDown(ReasonCodeDropdownPanel, 
                    "li", value);
        }

        public bool SelectOption(string value)
        {
            return FluentElement.Instance
                .WaitForElement(OptionsButton)
                .SelectDropDown(OptionsList, 
                    ".rtbText", value);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private InspectionMission() { }

        private static readonly Lazy<InspectionMission> Singleton =
            new Lazy<InspectionMission>(() => new InspectionMission());
    }
}
