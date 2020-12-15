using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Refill
{
    public class RefillOrderList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_lblHeader";

        private const string LoadingPanel =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_RefillLoadingPanelctl00_ContentPlaceHolderContent_RadAjaxPanel1";

        private const string ScanIdField =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_flbScanId_InputTemplateItem_txtScanId";

        private const string TrolleyDropDown =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_flbTrolley_InputTemplateItem_CmbTrolley_Input";

        private const string TrolleyDropDownList =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_flbTrolley_InputTemplateItem_CmbTrolley_DropDown .rcbList";

        private const string NoOfItemsOnTrolleyField =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_flbNumberOfItems_InputTemplateItem_txtNumberOfItems";

        private const string ConfirmButton =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_ButtonConfirm";

        private const string ActivateButton =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_ButtonActivate";

        private const string ViewItemsButton =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_ButtonView";

        private const string ViewItemsTable =
            "#ctl00_ContentPlaceHolderContent_RefillOrderListView1_RefillOrderGrid_ctl00 > tbody";

        public static RefillOrderList Instance => Singleton.Value;

        public void Navigate()
        {
            const string refillOrderListPageUrl = "/pages/activity/refill/refillorders.aspx";
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + refillOrderListPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Refill order list");
        }

        public string GetTrolleyFieldValue()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(TrolleyDropDown)
                .GetAttribute("value");
        }

        public bool EnterScanId(string scanValue)
        {
            return FluentElement.Instance
                .WaitForElement(ScanIdField)
                .Insert(scanValue);
        }

        public bool SelectTrolley(string trolleyName)
        {
            return FluentElement.Instance
                .WaitForElement(TrolleyDropDown)
                .SelectSearchDropDown(TrolleyDropDownList, "li", trolleyName);
        }

        public int GetNumberOfItemsOnTrolley()
        {
            return int.Parse(FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(NoOfItemsOnTrolleyField)
                .GetAttribute("value"));
        }

        public bool ClickActivateButton()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ActivateButton)
                .Click();
        }

        public bool ClickViewItemsButton()
        {
            return FluentElement.Instance
                .WaitForElement(ViewItemsButton)
                .Click();
        }

        public bool IsViewItemTableDisplayed()
        {
            return FluentElement.Instance
                .WaitUntilInvisible(LoadingPanel)
                .WaitForElement(ViewItemsTable)
                .IsVisible();
        }

        public IList<string> GetViewItemProductList()
        {
            return FluentElement.Instance
                .GetTableColumnDataSet(ViewItemsTable, 5);
        }

        public bool ClickConfirmButton()
        {
            return FluentElement.Instance
                .WaitForElement(ConfirmButton)
                .Click();
        }

        private RefillOrderList() { }

        private static readonly Lazy<RefillOrderList>
            Singleton = new Lazy<RefillOrderList>(() => new RefillOrderList());
    }
}
