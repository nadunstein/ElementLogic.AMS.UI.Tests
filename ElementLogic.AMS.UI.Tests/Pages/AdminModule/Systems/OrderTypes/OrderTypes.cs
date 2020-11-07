using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Systems.OrderTypes
{
    public class OrderTypes
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_OrdertypeListView_lblHeader";

        private const string AddRow =
            "#ctl00_ContentPlaceHolderContent_OrdertypeListView_ordertypeGrid_ctl00 .rgEditRow";

        private const string OrderTypeIdField =
            "#ctl00_ContentPlaceHolderContent_OrdertypeListView_ordertypeGrid_ctl00_ctl02_ctl03_txtOrdertypeid";

        private const string OrderTypeTextField =
            "#ctl00_ContentPlaceHolderContent_OrdertypeListView_ordertypeGrid_ctl00_ctl02_ctl03_txtOrdertypetext";

        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_OrdertypeListView_ordertypeGrid_ctl00_ctl02_ctl03_PerformInsertButton";

        private const string ResultTable = "#ctl00_ContentPlaceHolderContent_OrdertypeListView_ordertypeGrid_ctl00 > tbody";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_OrdertypeListView_ordertypeGrid_ctl00_ctl02_ctl00_rtbGridTopBar .rtbText";

        public static OrderTypes Instance => Singleton.Value;

        public void Navigate()
        {
            const string orderTypesPageUrl = "/Pages/System/ListOrderTypes.aspx";
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, orderTypesPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Order types");
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool IsAddRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(AddRow, true);
        }

        public bool InsertOrderTypeId(string orderTypeId)
        {
            return PageObjectHelper.Instance.InsertField(OrderTypeIdField,orderTypeId);
        }

        public bool InsertOrderTypeText(string orderType)
        {
            return PageObjectHelper.Instance.InsertField(OrderTypeTextField, orderType);
        }

        public bool ClickSaveButton()
        {
            return PageObjectHelper.Instance.Click(SaveButton);
        }

        public bool IsNewOrderTypeAdded(string orderType)
        {
            PageObjectHelper.Instance.WaitUntilInvisible(AddRow);
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, orderType);
        }

        private OrderTypes() { }

        private static readonly Lazy<OrderTypes> Singleton = new Lazy<OrderTypes>(() => new OrderTypes());
    }
}
