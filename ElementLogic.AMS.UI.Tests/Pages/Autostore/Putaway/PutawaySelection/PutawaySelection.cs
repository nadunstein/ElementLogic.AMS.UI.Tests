using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection
{
    public class PutawaySelection
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string ScanField =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_flbScan_InputTemplateItem_txtScan";

        private const string SearchOnDropdown =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_cboPutawaySearch_Input";

        private const string SearchOnDropdownList =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_cboPutawaySearch_DropDown .rcbList";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_putawayselectionview_btnExit";

        public static PutawaySelection Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsDisplayed(ScanField,false, true);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public bool SelectSearchOnDropdownValue(string dropDownValue)
        {
            var dropdownDefaultValue = PageObjectHelper.Instance.GetAttributeValue(SearchOnDropdown, "value");
            if (dropdownDefaultValue.Equals(dropDownValue))
            {
                return true;
            }

            return PageObjectHelper.Instance.SelectDropDown(SearchOnDropdown, 
                SearchOnDropdownList, "li", dropDownValue);
        }

        public bool InsertScanFieldValue(string scanValue)
        {
            return PageObjectHelper.Instance.InsertField(ScanField, scanValue);
        }

        public bool ClickExitButton()
        {
            return PageObjectHelper.Instance.Click(ExitButton);
        }

        public void ClickEnterButtonOnScanField()
        {
            PageObjectHelper.Instance.ClickEnter(ScanField);
        }

        private PutawaySelection() { }

        private static readonly Lazy<PutawaySelection> Singleton =
            new Lazy<PutawaySelection>(() => new PutawaySelection());
    }
}
