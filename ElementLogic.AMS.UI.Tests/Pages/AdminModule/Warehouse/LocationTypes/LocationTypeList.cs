using System;
using ElementLogic.AMS.UI.Tests.Integration;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.LocationTypes
{
    public class LocationTypeList
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_lblHeader";

        private const string ResultTable = ".rgMasterTable > tbody";

        private const string AddButton =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl00_rtbGridTopBar .rtbText";
        
        private const string AddEditRow = ".rgMasterTable .rgEditRow";
        
        private const string NameField =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_txtName";
        
        private const string WidthField =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_txtWidth";
        
        private const string DepthField =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_txtDepth";
        
        private const string HeightField =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_txtHeight";
        
        private const string CategoryField =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_ddlCategory";

        private const string TypeField =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_ddlLocationType";

        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00_ctl02_ctl03_PerformInsertButton";
        
        private const string FirstSearchResultRow =
            "#ctl00_ContentPlaceHolderContent_LocationtypesView1_radgridLocationType_ctl00__0";

        public static LocationTypeList Instance => Singleton.Value;

        public void Navigate()
        {
            const string locationTypeListPageUrl = "/Pages/Warehouse/Locationtypes.aspx";
            var baseUrl = JsonFileReader.Instance
                .GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            var pageUrl = baseUrl + locationTypeListPageUrl;
            FluentElement.Instance
                .Navigate(pageUrl);
        }

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Location type list");
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(FirstSearchResultRow)
                .IsVisible();
        }

        public bool ClickAddButton()
        {
            return FluentElement.Instance
                .WaitForElement(AddButton)
                .Click();
        }

        public bool IsAddEditRowDisplayed()
        {
            return FluentElement.Instance
                .WaitForElement(AddEditRow)
                .IsVisible();
        }

        public bool InsertName(string value)
        {
            return FluentElement.Instance
                .WaitForElement(NameField)
                .Insert(value);
        }

        public bool InsertWidth(string value)
        {
            return FluentElement.Instance
                .WaitForElement(WidthField)
                .Insert(value);
        }

        public bool InsertDepth(string value)
        {
            return FluentElement.Instance
                .WaitForElement(DepthField)
                .Insert(value);
        }

        public bool InsertHeight(string value)
        {
           return FluentElement.Instance
               .WaitForElement(HeightField)
               .Insert(value);
        }

        public bool InsertCategory(string value)
        {
            return FluentElement.Instance
                .WaitForElement(CategoryField)
                .SelectDropDown(value);
        }

        public bool InsertType(string value)
        {
            return FluentElement.Instance
                .WaitForElement(TypeField)
                .SelectDropDown(value);
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool IsNewLocationTypeAdded(string locationType)
        {
            return FluentElement.Instance
                .WaitForElement(ResultTable)
                .GetTableElements()
                .FindRowElements(3, locationType)
                .IsExists();
        }

        private LocationTypeList() { }

        private static readonly Lazy<LocationTypeList> Singleton =
            new Lazy<LocationTypeList>(() => new LocationTypeList());
    }
}
