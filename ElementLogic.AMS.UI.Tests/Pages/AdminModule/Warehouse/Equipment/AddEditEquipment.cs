using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment
{
    public class AddEditEquipment
    {
        private const string PageHeader =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_lblHeader";

        private const string CodeField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtCode_TextboxControl";

        private const string NameField =
           "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtName_TextboxControl";

        private const string WarehouseZoneField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlWarehouseZone";

        private const string GroupField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_cmbGroup_Input";

        private const string TypeField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlType";

        private const string DriverField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlDriver";

        private const string UsePickContainersCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_usePickContainersCheckBox";

        private const string ActiveCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_chkActive";

        private const string ManualCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_chkManual";

        private const string WidthField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtWidth_TextboxControl";

        private const string DepthField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtDepth_TextboxControl";

        private const string HeightField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_txtHeight_TextboxControl";

        private const string AutoAssignCheckBox =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_chkAutoAPL";

        private const string TaskTypeField =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_ddlTaskType";

        private const string SaveButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rtbTopBar li:nth-child(1) .rtbText";

        private const string CancelButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rtbTopBar li:nth-child(4) .rtbText";

        private const string ShelfGeneratorButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rtbTopBar .rtbUL li:nth-child(7) .rtbText";

        private const string ShelfEditButton =
            "#ctl00_ContentPlaceHolderContent_AddEditEquipmentView1_rdgShelves_ctl00_ctl04_gbccolumn";

        public static AddEditEquipment Instance => Singleton.Value;

        public bool IsPageLoaded()
        {
            return FluentElement.Instance
                .WaitForPageLoad()
                .WaitForElement(PageHeader)
                .Text()
                .Equals("Add/Edit equipment");
        }

        public bool InsertCode(string value)
        {
            return FluentElement.Instance
                .WaitForElement(CodeField)
                .Insert(value);
        }

        public bool InsertName(string value)
        {
            return FluentElement.Instance
                .WaitForElement(NameField)
                .Insert(value);
        }

        public bool SelectWarehouseZone(string value)
        {
            return FluentElement.Instance
                .WaitForElement(WarehouseZoneField)
                .SelectDropDown(value);
        }

        public bool SelectGroup(string value)
        {
            return FluentElement.Instance
                .WaitForElement(GroupField)
                .SelectDropDown(value);
        }

        public bool SelectType(string value)
        {
            return FluentElement.Instance
                .WaitForElement(TypeField)
                .SelectDropDown(value);
        }

        public bool SelectDriver(string value)
        {
            return FluentElement.Instance
                .WaitForElement(DriverField)
                .SelectDropDown(value);
        }

        public bool SelectUsePickContainersCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(UsePickContainersCheckBox)
                .Click();
        }

        public bool SelectActiveCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(ActiveCheckBox)
                .Click();
        }

        public bool SelectManualCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(ManualCheckBox)
                .Click();
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

        public bool SelectAutoAssignCheckBox()
        {
            return FluentElement.Instance
                .WaitForElement(AutoAssignCheckBox)
                .Click();
        }

        public bool SelectTaskType(string value)
        {
            return FluentElement.Instance
                .WaitForElement(TaskTypeField)
                .SelectDropDown(value);
        }

        public bool ClickSaveButton()
        {
            return FluentElement.Instance
                .WaitForElement(SaveButton)
                .Click();
        }

        public bool ClickCancelButton()
        {
            return FluentElement.Instance
                .WaitForElement(CancelButton)
                .Click();
        }

        public bool ClickShelfGeneratorButton()
        {
            return FluentElement.Instance
                .WaitForElement(ShelfGeneratorButton)
                .Click();
        }

        public bool ClickShelfEditButton()
        {
            return FluentElement.Instance
                .WaitForElement(ShelfEditButton)
                .Click();
        }

        private AddEditEquipment() { }

        private static readonly Lazy<AddEditEquipment> Singleton =
            new Lazy<AddEditEquipment>(() => new AddEditEquipment());
    }
}
