using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Zones
{
    public class AddEditZone
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_lblHeader";
        
        private const string CodeField =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_txtCode_TextboxControl";
        
        private const string DescriptionField =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_txtDes_TextboxControl";
       
        private const string LocationTemplateField =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_txtTemplate_TextboxControl";
        
        private const string ZoneTypeDropDown =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_ddlzoneType";
       
        private const string WarehouseDropDown =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_ddlWarehouse";
        
        private const string FifoCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_chkFifo";
        
        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_rtbTopBar .rtbText";
        
        private const string CancelButton =
            "#ctl00_ContentPlaceHolderContent_AddEditWarehouseZoneView1_rtbTopBar li:nth-child(4) .rtbText";

        public static AddEditZone Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Add/Edit zone");
        }

        public bool InsertCode(string value)
        {
            return FluentElement.Instance
                .WaitForElement(CodeField)
                .Insert(value);
        }

        public bool InsertDescription(string value)
        {
            return FluentElement.Instance
                .WaitForElement(DescriptionField)
                .Insert(value);
        }

        public bool InsertLocationTemplate(string value)
        {
            return FluentElement.Instance
                .WaitForElement(LocationTemplateField)
                .Insert(value);
        }

        public bool SelectZoneTyp(string value)
        {
            return FluentElement.Instance
                .WaitForElement(ZoneTypeDropDown)
                .SelectDropDown(value);
        }

        public bool SelectWarehouse(string value)
        {
            return FluentElement.Instance
                .WaitForElement(WarehouseDropDown)
                .SelectDropDown(value);
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool SelectFifoCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(FifoCheckBox)
                .Click();
        }

        public bool ClickCancelButton()
        {
            return FluentElement.Instance
                .WaitForElement(CancelButton)
                .Click();
        }

        private AddEditZone() { }

        private static readonly Lazy<AddEditZone> Singleton = new Lazy<AddEditZone>(() => new AddEditZone());
    }
}
