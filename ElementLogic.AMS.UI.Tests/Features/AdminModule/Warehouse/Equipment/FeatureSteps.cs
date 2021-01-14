using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Equipment;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Warehouse.Equipment
{
    [Binding]
    public sealed class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Given(@"I navigate to Equipment List page")]
        public void GivenINavigateToEquipmentListPage()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            EquipmentList.Instance.Navigate();
            Assert.IsTrue(EquipmentList.Instance.IsPageLoaded(),
                "The Equipment List page is NOT loaded");
        }

        [When(@"I click on the Search button in Equipment List page")]
        public void WhenIClickOnTheSearchButtonInEquipmentListPage()
        {
            Assert.IsTrue(EquipmentList.Instance.ClickSearchButton(),
                "Unable to click on the Search button in Equipment List page");
        }

        [When(@"I click on Add button in Equipment List page")]
        public void WhenIClickOnAddButtonInEquipmentListPage()
        {
            Assert.IsTrue(EquipmentList.Instance.ClickAddButton(),
                "Unable to click on Add button in Equipment List page");
        }

        [Then(@"The Add/Edit equipment page is loaded")]
        public void ThenTheAddEditEquipmentPageIsLoaded()
        {
            Assert.IsTrue(AddEditEquipment.Instance.IsPageLoaded(),
                "The Add/Edit equipment page is NOT loaded");
        }

        [Then(@"I enter values to the fields in Add/Edit equipment page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddEditEquipmentPageAsFollows(Table table)
        {
            var equipmentDetails = table.CreateDynamicSet();
            foreach (var equipmentDetail in equipmentDetails)
            {
                switch (equipmentDetail.FieldName)
                {
                    case "Code":
                        Assert.IsTrue(AddEditEquipment.Instance.InsertCode(equipmentDetail.Value is int
                            ? equipmentDetail.Value.ToString("D2")
                            : equipmentDetail.Value), "Unable to insert Code in Add/Edit equipment page");
                        break;

                    case "Name":
                        Assert.IsTrue(AddEditEquipment.Instance.InsertName(equipmentDetail.Value),
                            "Unable to insert Name in Add/Edit equipment page");
                        break;

                    case "Warehouse zone":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectWarehouseZone(equipmentDetail.Value),
                            "Unable to select Warehouse Zone in Add/Edit equipment page");
                        break;

                    case "Group":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectGroup(equipmentDetail.Value),
                            "Unable to select Group in Add/Edit equipment page");
                        break;

                    case "Type":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectType(equipmentDetail.Value),
                            "Unable to select Type in Add/Edit equipment page");
                        break;

                    case "Driver":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectDriver(equipmentDetail.Value),
                            "Unable to select Driver in Add/Edit equipment page");
                        break;

                    case "Use pick containers":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectUsePickContainersCheckBox(),
                            "Unable to select Use PickContainers CheckBox in Add/Edit equipment page");
                        break;

                    case "Active":
                        AddEditEquipment.Instance.SelectActiveCheckBox();
                        Assert.True(EquipmentInfoPopUp.Instance.IsPopUpDisplayed(),
                            "The Activation Info popup is not displayed");
                        EquipmentInfoPopUp.Instance.ClickYesButton();
                        Assert.IsTrue(AddEditEquipment.Instance.IsPageLoaded(),
                            "The Add/Edit equipment page is NOT loaded");
                        break;

                    case "Manual":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectManualCheckBox(),
                            "Unable to select Manual CheckBox in Add/Edit equipment page");
                        break;

                    case "Width":
                        Assert.IsTrue(AddEditEquipment.Instance.InsertWidth(equipmentDetail.Value.ToString()),
                            "Unable to insert Width in Add/Edit equipment page");
                        break;

                    case "Depth":
                        Assert.IsTrue(AddEditEquipment.Instance.InsertDepth(equipmentDetail.Value.ToString()),
                            "Unable to insert Depth in Add/Edit equipment page");
                        break;

                    case "Height":
                        Assert.IsTrue(AddEditEquipment.Instance.InsertHeight(equipmentDetail.Value.ToString()),
                            "Unable to insert Height in Add/Edit equipment page");
                        break;

                    case "Auto-assign":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectAutoAssignCheckBox(),
                            "Unable to select AutoAssign CheckBox in Add/Edit equipment page");
                        break;

                    case "Task type":
                        Assert.IsTrue(AddEditEquipment.Instance.SelectTaskType(equipmentDetail.Value),
                            "Unable to select TaskType in Add/Edit equipment page");
                        break;
                }
            }
        }

        [Then(@"I click on Save button in Add/Edit equipment page")]
        public void ThenIClickOnSaveButtonInAddEditEquipmentPage()
        {
            Assert.IsTrue(AddEditEquipment.Instance.ClickSaveButton(),
                "Unable to click on Save button in Add/Edit equipment page");
        }

        [When(@"I click on Shelf generator button in Add/Edit equipment page")]
        public void WhenIClickOnShelfGeneratorButtonInAddEditEquipmentPage()
        {
            Assert.IsTrue(AddEditEquipment.Instance.ClickShelfGeneratorButton(),
                "Unable to click on Shelf generator button in Add/Edit equipment page");
        }

        [Then(@"The Shelf generator popup is displayed in Add/Edit equipment page")]
        public void ThenTheShelfGeneratorPopupIsDisplayedInAddEditEquipmentPage()
        {
            Assert.True(ShelfGeneratorPopUp.Instance.IsPopupDisplayed(),
                "The Shelf generator popup is NOT displayed in Add/Edit equipment page");
        }

        [Then(@"I enter values to the fields in Shelf generator popup as follows:")]
        public void ThenIEnterValuesToTheFieldsInShelfGeneratorPopupAsFollows(Table table)
        {
            var shelfDetails = table.CreateDynamicSet();
            foreach (var shelfDetail in shelfDetails)
            {
                switch (shelfDetail.FieldName)
                {
                    case "Shelves":
                        Assert.IsTrue(ShelfGeneratorPopUp.Instance.InsertShelves(shelfDetail.Value.ToString()),
                            "Unable to Insert Shelves in Shelf generator popup");
                        break;

                    case "Type":
                        Assert.IsTrue(ShelfGeneratorPopUp.Instance.SelectType(shelfDetail.Value),
                            "Unable to select Type in Shelf generator popup");
                        break;

                    case "Location size":
                        Assert.IsTrue(ShelfGeneratorPopUp.Instance.SelectLocationSize(shelfDetail.Value),
                            "Unable to Select Location Size in Shelf generator popup");
                        break;

                    case "Positions":
                        Assert.IsTrue(ShelfGeneratorPopUp.Instance.InsertPositions(shelfDetail.Value.ToString()),
                            "Unable to Insert Positions in Shelf generator popup");
                        break;

                    case "Depths":
                        Assert.IsTrue(ShelfGeneratorPopUp.Instance.InsertDepths(shelfDetail.Value.ToString()),
                            "Unable to Insert Depths in Shelf generator popup");
                        break;
                }
            }
        }

        [When(@"I click on Make shelves button")]
        public void WhenIClickOnMakeShelvesButton()
        {
            Assert.IsTrue(ShelfGeneratorPopUp.Instance.ClickMakeShelvesButton(),
                "Unable to click on Make shelves button");
        }

        [When(@"I click on Cancel button in Add/Edit equipment page")]
        public void WhenIClickOnCancelButtonInAddEditEquipmentPage()
        {
            Assert.IsTrue(AddEditEquipment.Instance.ClickCancelButton(),
                "Unable to click on Cancel button in Add/Edit equipment page");
        }

        [Then(@"The Equipment list page is loaded")]
        public void ThenTheEquipmentListPageIsLoaded()
        {
            Assert.IsTrue(EquipmentList.Instance.IsPageLoaded(),
                "The Equipment List page is NOT loaded");
        }

        [Then(@"The newly added '(.*)' Equipment is listed in the search result grid in Equipment list page")]
        public void ThenTheNewlyAddedEquipmentIsListedInTheSearchResultGridInEquipmentListPage(string equipmentName)
        {
            Assert.IsTrue(EquipmentList.Instance.InsertName(equipmentName),
                "Unable to Inert Equipment name in Equipment list page");
            Assert.IsTrue(EquipmentList.Instance.ClickSearchButton(),
                "Unable to click on Search button in Equipment list page");
            Assert.IsTrue(EquipmentList.Instance.IsResultTableDisplayed(),
                "The result table is not displayed in Equipment list page");
            Assert.IsTrue(EquipmentList.Instance.IsNewEquipmentAdded(equipmentName),
                $"The newly added '{equipmentName}' equipment is NOT listed in the search result grid in Equipment list page");
        }

        [When(@"I click on Equipment view button in Equipment list page")]
        public void WhenIClickOnEquipmentViewButtonInEquipmentListPage()
        {
            Assert.IsTrue(EquipmentList.Instance.ClickEquipmentViewButton(),
                "Unable to click on Equipment view button in Equipment list page");
        }

        [When(@"I click on Shelf edit button in Add/Edit equipment page")]
        public void WhenIClickOnShelfEditButtonInAddEditEquipmentPage()
        {
            Assert.IsTrue(AddEditEquipment.Instance.ClickShelfEditButton(),
                "Unable to click on Shelf edit button in Add/Edit equipment page");
        }

        [Then(@"The Edit shelf page is loaded")]
        public void ThenTheEditShelfPageIsLoaded()
        {
            Assert.IsTrue(EditShelf.Instance.IsPageLoaded(),
                "The Edit shelf page is NOT loaded");
        }

        [Then(@"I Insert the Shelf number as '(.*)' in Edit shelf page")]
        public void ThenIInsertTheShelfNumberAsInEditShelfPage(int shelfNumber)
        {
            Assert.IsTrue(EditShelf.Instance.InsertShelfNumber(shelfNumber),
                "Unable to Insert the Shelf number in Edit shelf page");
        }

        [When(@"I click on Save button in Edit shelf page")]
        public void WhenIClickOnSaveButtonInEditShelfPage()
        {
            Assert.IsTrue(EditShelf.Instance.ClickSaveButton(), "Unable to click on Save button in Edit shelf page");
        }

        [When(@"I click on Cancel button in Edit shelf page")]
        public void WhenIClickOnCancelButtonInEditShelfPage()
        {
            Assert.IsTrue(EditShelf.Instance.ClickCancelButton(),
                "Unable to click on Cancel button in Edit shelf page");
        }

        [Then(@"Shelf info popup is displayed in Edit shelf page")]
        public void ThenShelfInfoPopupIsDisplayedInEditShelfPage()
        {
            Assert.True(ShelfInfoPopUp.Instance.IsPopupDisplayed(),
                "Shelf info popup is NOT displayed in Edit shelf page");
        }

        [Then(@"I click on Yes button on Shelf info popup in Edit shelf page")]
        public void ThenIClickOnYesButtonOnShelfInfoPopupInEditShelfPage()
        {
            Assert.IsTrue(ShelfInfoPopUp.Instance.ClickYesButton(),
                "Unable to click on Yes button on Shelf info popup in Edit shelf page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
