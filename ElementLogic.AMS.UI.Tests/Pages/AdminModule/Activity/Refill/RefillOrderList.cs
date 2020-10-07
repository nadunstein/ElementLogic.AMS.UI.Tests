using System;
using System.Collections.Generic;
using ElementLogic.AMS.UI.Tests.Configuration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Activity.Refill
{
    public class RefillOrderList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_lblHeader";

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

        private const string LoadingPanel =
            "#ctl00_ContentPlaceHolderContent_RefillOrderGenerateView1_RefillLoadingPanel";

        public static RefillOrderList Instance => Singleton.Value;

        public void Navigate()
        {
            const string refillOrderListPageUrl = "/pages/activity/refill/refillorders.aspx";
            string baseUrl = ConfigFileReader.Instance.ConfigurationKeyValue("Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, refillOrderListPageUrl);
        }

        public string GetPageTitle()
        {
            return PageObjectHelper.Instance.GetTextValue(PageHeader, true);
        }

        public string GetTrolleyFieldValue()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.GetAttributeValue(TrolleyDropDown, "value");
        }

        public bool EnterScanId(string scanValue)
        {
            return PageObjectHelper.Instance.InsertField(ScanIdField, scanValue);
        }

        public bool SelectTrolley(string trolleyName)
        {
            var isInserted = PageObjectHelper.Instance.InsertField(TrolleyDropDown, trolleyName);
            var isSelected = PageObjectHelper.Instance.SelectDropDown(null, TrolleyDropDownList, "li",
                trolleyName);

            return isInserted && isSelected;
        }

        public int GetNumberOfItemsOnTrolley()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return int.Parse(PageObjectHelper.Instance.GetAttributeValue(NoOfItemsOnTrolleyField, "value"));
        }

        public bool ClickActivateButton()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.Click(ActivateButton);
        }

        public bool ClickViewItemsButton()
        {
            return PageObjectHelper.Instance.Click(ViewItemsButton);
        }

        public bool IsViewItemTableDisplayed()
        {
            PageObjectHelper.Instance.WaitUntilInvisible(LoadingPanel);
            return PageObjectHelper.Instance.IsDisplayed(ViewItemsTable, true);
        }

        public IList<string> GetViewItemProductList()
        {
            return PageObjectHelper.Instance.GetTableColumnDataSet(ViewItemsTable, 5);
        }

        public bool ClickConfirmButton()
        {
            return PageObjectHelper.Instance.Click(ConfirmButton);
        }

        private RefillOrderList() { }

        private static readonly Lazy<RefillOrderList>
            Singleton = new Lazy<RefillOrderList>(() => new RefillOrderList());
    }
}
