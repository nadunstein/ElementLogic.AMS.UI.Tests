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
            var baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + orderTypesPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Order types");
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsAddRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(AddRow)
                .IsVisible();
        }

        public bool InsertOrderTypeId(string orderTypeId)
        {
            return FluentElement.Instance
                .WaitForElement(OrderTypeIdField)
                .Insert(orderTypeId);
        }

        public bool InsertOrderTypeText(string orderType)
        {
            return FluentElement.Instance
                .WaitForElement(OrderTypeTextField)
                .Insert(orderType);
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool IsNewOrderTypeAdded(string orderType)
        {
             FluentElement.Instance
                .WaitUntilInvisible(AddRow);
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, orderType);
        }

        private OrderTypes() { }

        private static readonly Lazy<OrderTypes> Singleton = new Lazy<OrderTypes>(() => new OrderTypes());
    }
}
