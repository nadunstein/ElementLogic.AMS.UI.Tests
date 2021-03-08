using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.PutawaySelection
{
    public class PutawaySelection
    {
        private const string PageHeader = "#ctl00_head_HeaderView_lblCurrentOperation";

        private const string LoadingPanel = "#ctl00_LoadingPanel1";

        private const string ScanField =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_flbScan_InputTemplateItem_txtScan";

        private const string SearchOnDropdown =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_cboPutawaySearch_Input";

        private const string SearchOnDropdownList =
            "#ctl00_MonitorContentPlaceholder_putawayselectionview_cboPutawaySearch_DropDown .rcbList";

        private const string OrdersListTable = ".rgMasterTable tbody";

        private const string ExitButton = "#ctl00_MonitorContentPlaceholder_putawayselectionview_btnExit";

        public static PutawaySelection Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Putaway selection");
        }

        public bool IsPageDisplayed()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .IsVisible(ScanField);
        }

        public bool SelectSearchOnDropdownValue(string dropDownValue)
        {
            var dropdownDefaultValue = FluentElement.Instance
                .WaitForElement(SearchOnDropdown)
                .GetAttribute("value");
            if (dropdownDefaultValue.Equals(dropDownValue))
            {
                return true;
            }

            return FluentElement.Instance
                .WaitForElement(SearchOnDropdown)
                .SelectDropDown(SearchOnDropdownList, 
                    "li", dropDownValue);
        }

        public bool InsertScanFieldValue(string scanValue)
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .Insert(scanValue);
        }

        public int GetTaskgroupCount()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(OrdersListTable)
                .GetTableElements()
                .GetRowCount();
        }

        public bool ClickFirstTaskgroupSelectButton(string productId)
        {
            return FluentElement.Instance
                .WaitForElement(OrdersListTable)
                .GetTableElements()
                .FindRowElements(5, productId)
                .GetRowElement(4)
                .FindElement(".as-button-md-green")
                .Click();
        }

        public bool ClickEnterButtonOnScanField()
        {
            return FluentElement.Instance
                .WaitForElement(ScanField)
                .ClickEnterButton();
        }

        public bool ClickExitButton()
        {
            return FluentElement.Instance
                .WaitForElement(ExitButton)
                .Click();
        }

        private PutawaySelection() { }

        private static readonly Lazy<PutawaySelection> Singleton =
            new Lazy<PutawaySelection>(() => new PutawaySelection());
    }
}
