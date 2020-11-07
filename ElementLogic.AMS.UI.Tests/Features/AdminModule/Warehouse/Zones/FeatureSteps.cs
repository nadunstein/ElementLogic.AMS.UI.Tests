using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.Zones;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Warehouse.Zones
{
    [Binding]
    public class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Given(@"I navigate to Warehouse Zone List page")]
        public void GivenINavigateToWarehouseZoneListPage()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") && 
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            WarehouseZoneList.Instance.Navigate();
            Assert.IsTrue(WarehouseZoneList.Instance.IsPageLoaded(),
                "The Warehouse Zone List page is NOT loaded");
        }

        [Then(@"The Warehouse Zone\(s\) are listed in the search result grid in Warehouse Zone List page")]
        public void ThenTheWarehouseZoneSAreListedInTheSearchResultGridInWarehouseZoneListPage()
        {
            Assert.True(WarehouseZoneList.Instance.IsFirstSearchResultRowDisplayed(),
                "The Warehouse Zone(s) are NOT listed in the search result grid in Warehouse Zone List page");
        }

        [When(@"I click on Add button in Warehouse Zone List page")]
        public void WhenIClickOnAddButtonInWarehouseZoneListPage()
        {
            Assert.IsTrue(WarehouseZoneList.Instance.ClickAddButton(),
                "Unable to click on Add button in Warehouse Zone List page");
        }

        [Then(@"The Add/Edit Zone page is loaded")]
        public void ThenTheAddEditZonePageIsLoaded()
        {
            Assert.IsTrue(AddEditZone.Instance.IsPageLoaded(),
                "The Add/Edit Zone page is NOT loaded");
        }

        [Then(@"I enter values to the fields in Add/Edit Zone page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddEditZonePageAsFollows(Table table)
        {
            var zoneDetails = table.CreateDynamicSet();
            foreach (var zoneDetail in zoneDetails)
            {
                switch (zoneDetail.FieldName)
                {
                    case "Code":
                        Assert.IsTrue(AddEditZone.Instance.InsertCode(zoneDetail.Value),
                            "Unable to Insert Code in Add/Edit Zone page");
                        break;

                    case "Description":
                        Assert.IsTrue(AddEditZone.Instance.InsertDescription(zoneDetail.Value),
                            "Unable to Insert Description in Add/Edit Zone page");
                        break;

                    case "Location template":
                        Assert.IsTrue(AddEditZone.Instance.InsertLocationTemplate(zoneDetail.Value),
                            "Unable to Insert Location Template in Add/Edit Zone page");
                        break;

                    case "Zone type":
                        Assert.IsTrue(AddEditZone.Instance.SelectZoneTyp(zoneDetail.Value),
                            "Unable to Select Zone Type in Add/Edit Zone page");
                        break;

                    case "Warehouse":
                        Assert.IsTrue(AddEditZone.Instance.SelectWarehouse(zoneDetail.Value),
                            "Unable to Select Warehouse in Add/Edit Zone page");
                        break;

                    case "FiFo":
                        if (zoneDetail.Value.Equals("True"))
                        {
                            Assert.IsTrue(AddEditZone.Instance.SelectFifoCheckBox(),
                                "Unable to Select Fifo CheckBox in Add/Edit Zone page");
                        }

                        break;
                }
            }
        }

        [Then(@"I click on Save button in Add/Edit zone")]
        public void ThenIClickOnSaveButtonInAddEditZone()
        {
            Assert.IsTrue(AddEditZone.Instance.ClickSaveButton(), 
                "Unable to click on Save button in Add/Edit zone");
        }

        [When(@"I click on Cancel add button in Add/Edit zone")]
        public void WhenIClickOnCancelAddButtonInAddEditZone()
        {
            Assert.IsTrue(AddEditZone.Instance.ClickCancelButton(),
                "Unable to click on Cancel add button in Add/Edit zone");
        }

        [Then(@"The Warehouse Zone List page is loaded")]
        public void ThenTheWarehouseZoneListPageIsLoaded()
        {
            Assert.IsTrue(WarehouseZoneList.Instance.IsPageLoaded(),
                "The Warehouse Zone List page is NOT loaded");
        }

        [Then(@"The newly added '(.*)' warehouse zone is listed in the search result grid in Warehouse zone list page")]
        public void ThenTheNewlyAddedWarehouseZoneIsListedInTheSearchResultGridInWarehouseZoneListPage(string zoneCode)
        {
            Assert.True(WarehouseZoneList.Instance.IsNewZoneAdded(zoneCode),
                $"The newly added '{zoneCode}' warehouse zone is NOT listed in the search result grid in Warehouse zone list page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
