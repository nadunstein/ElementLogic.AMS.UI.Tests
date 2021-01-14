using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Warehouses;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Warehouse.Warehouses
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Given(@"I navigate to Warehouse List page")]
        public void GivenINavigateToWarehouseListPage()
        {
            WarehouseList.Instance.Navigate();
            Assert.IsTrue(WarehouseList.Instance.IsPageLoaded(),
                "The Warehouse List page is NOT loaded");
        }

        [When(@"I click on Add button in Warehouse List page")]
        public void WhenIClickOnAddButtonInWarehouseListPage()
        {
            Assert.IsTrue(WarehouseList.Instance.ClickAddButton(),
                "Unable to click on Add button in Warehouse List page");
        }

        [Then(@"The Warehouse adding row is displayed on the search result grid in Warehouse List page")]
        public void ThenTheWarehouseAddingRowIsDisplayedOnTheSearchResultGridInWarehouseListPage()
        {
            Assert.True(WarehouseList.Instance.IsAddEditRowDisplayed(),
                "The Warehouse adding row is NOT displayed on the search result grid in Warehouse List page");
        }

        [Then(
            @"I enter values to the fields in adding row on the search result grid in Warehouse List page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddingRowOnTheSearchResultGridInWarehouseListPageAsFollows(Table table)
        {
            var warehouseDetails = table.CreateDynamicSet();
            foreach (var warehouseDetail in warehouseDetails)
            {
                switch (warehouseDetail.FieldName)
                {
                    case "Code":
                        Assert.IsTrue(WarehouseList.Instance.InsertCode(warehouseDetail.Value),
                            "Unable to Insert Code in adding row on the search result grid in Warehouse List page");
                        break;

                    case "Description":
                        Assert.IsTrue(WarehouseList.Instance.InsertDescription(warehouseDetail.Value),
                            "Unable to Insert Description in adding row on the search result grid in Warehouse List page");
                        break;
                }
            }
        }

        [When(@"I click on Save button in adding row on the search result grid in Warehouse List page")]
        public void WhenIClickOnSaveButtonInAddingRowOnTheSearchResultGridInWarehouseListPage()
        {
            Assert.IsTrue(WarehouseList.Instance.ClickSaveButton(),
                "Unable to click on Save button in adding row on the search result grid in Warehouse List page");
        }

        [Then(@"The newly added Warehouse is listed in the search result grid in Warehouse List page")]
        public void ThenTheNewlyAddedWarehouseIsListedInTheSearchResultGridInWarehouseListPage()
        {
            Assert.True(WarehouseList.Instance.IsFirstSearchResultRowDisplayed(),
                "The newly added Warehouse is NOT listed in the search result grid in Warehouse List page");
        }
    }
}
