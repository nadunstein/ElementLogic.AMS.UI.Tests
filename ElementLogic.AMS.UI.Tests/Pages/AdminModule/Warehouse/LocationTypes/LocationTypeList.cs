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
            string baseUrl = JsonFileReader.Instance.GetJsonKeyValue("Configuration/Environment.json", "Application:Url");
            PageObjectHelper.Instance.Navigate(baseUrl, locationTypeListPageUrl);
        }

        public bool IsPageLoaded()
        {
            return PageObjectHelper.Instance.IsPageLoaded(PageHeader, "Location type list");
        }

        public bool IsFirstSearchResultRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(FirstSearchResultRow, true);
        }

        public bool ClickAddButton()
        {
            return PageObjectHelper.Instance.Click(AddButton);
        }

        public bool IsAddEditRowDisplayed()
        {
            return PageObjectHelper.Instance.IsDisplayed(AddEditRow, true);
        }

        public bool InsertName(string value)
        {
            return PageObjectHelper.Instance.InsertField(NameField, value);
        }

        public bool InsertWidth(string value)
        {
            return PageObjectHelper.Instance.InsertField(WidthField, value);
        }

        public bool InsertDepth(string value)
        {
            return PageObjectHelper.Instance.InsertField(DepthField, value);
        }

        public bool InsertHeight(string value)
        {
           return PageObjectHelper.Instance.InsertField(HeightField, value);
        }

        public bool InsertCategory(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(CategoryField, value);
        }

        public bool InsertType(string value)
        {
            return PageObjectHelper.Instance.SelectDropDown(TypeField, value);
        }

        public bool ClickSaveButton()
        {
            return PageObjectHelper.Instance.Click(SaveButton);
        }

        public bool IsNewLocationTypeAdded(string locationType)
        {
            return PageObjectHelper.Instance.TableDataExists(ResultTable, 3, locationType);
        }

        private LocationTypeList() { }

        private static readonly Lazy<LocationTypeList> Singleton =
            new Lazy<LocationTypeList>(() => new LocationTypeList());
    }
}
