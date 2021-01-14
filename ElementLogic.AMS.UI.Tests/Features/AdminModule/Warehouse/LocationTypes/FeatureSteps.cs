using ElementLogic.AMS.UI.Tests.Pages.AdminModule.Warehouse.LocationTypes;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ElementLogic.AMS.UI.Tests.Features.AdminModule.Warehouse.LocationTypes
{
    [Binding]
    public sealed class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Given(@"I navigate to Location Type List page")]
        public void GivenINavigateToLocationTypeListPage()
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            LocationTypeList.Instance.Navigate();
            Assert.IsTrue(LocationTypeList.Instance.IsPageLoaded(),
                "The Location Type List page is NOT loaded");
        }

        [Then(@"The Location Type\(s\) are listed in the search result grid in Location Type List page")]
        public void ThenTheLocationTypeSAreListedInTheSearchResultGridInLocationTypeListPage()
        {
            Assert.True(LocationTypeList.Instance.IsFirstSearchResultRowDisplayed(),
                "The Location Type(s) are NOT listed in the search result grid in Location Type List page");
        }

        [When(@"I click on Add button in Location Type List page")]
        public void WhenIClickOnAddButtonInLocationTypeListPage()
        {
            Assert.IsTrue(LocationTypeList.Instance.ClickAddButton(),
                "Unable to click on Add button in Location Type List page");
        }

        [Then(@"The Location type adding row is displayed on the search result grid in Location Type List page")]
        public void ThenTheLocationTypeAddingRowIsDisplayedOnTheSearchResultGridInLocationTypeListPage()
        {
            Assert.True(LocationTypeList.Instance.IsAddEditRowDisplayed(),
                "The Location type adding row is NOT displayed on the search result grid in Location Type List page");
        }

        [Then(@"I enter values to the fields in adding row on the search result grid in Location Type List page as follows:")]
        public void ThenIEnterValuesToTheFieldsInAddingRowOnTheSearchResultGridInLocationTypeListPageAsFollows(Table table)
        {
            var warehouseDetails = table.CreateDynamicSet();
            foreach (var warehouseDetail in warehouseDetails)
            {
                switch (warehouseDetail.FieldName)
                {
                    case "Name":
                        Assert.IsTrue(LocationTypeList.Instance.InsertName(warehouseDetail.Value),
                            "Unable to Insert Name in adding row on the search result grid in Location Type List page");
                        break;

                    case "Width":
                        Assert.IsTrue(LocationTypeList.Instance.InsertWidth(warehouseDetail.Value.ToString()),
                            "Unable to Insert Width in adding row on the search result grid in Location Type List page");
                        break;

                    case "Depth":
                        Assert.IsTrue(LocationTypeList.Instance.InsertDepth(warehouseDetail.Value.ToString()),
                            "Unable to Insert Depth in adding row on the search result grid in Location Type List page");
                        break;

                    case "Height":
                        Assert.IsTrue(LocationTypeList.Instance.InsertHeight(warehouseDetail.Value.ToString()),
                            "Unable to Insert Height in adding row on the search result grid in Location Type List page");
                        break;

                    case "Category":
                        Assert.IsTrue(LocationTypeList.Instance.InsertCategory(warehouseDetail.Value),
                            "Unable to Insert Category in adding row on the search result grid in Location Type List page");
                        break;

                    case "Type":
                        Assert.IsTrue(LocationTypeList.Instance.InsertType(warehouseDetail.Value),
                            "Unable to Insert Type in adding row on the search result grid in Location Type List page");
                        break;
                }
            }
        }

        [When(@"I click on Save button in adding row on the search result grid in Location Type List page")]
        public void WhenIClickOnSaveButtonInAddingRowOnTheSearchResultGridInLocationTypeListPage()
        {
            Assert.IsTrue(LocationTypeList.Instance.ClickSaveButton(),
                "Unable to click on Save button in adding row on the search result grid in Location Type List page");
        }

        [Then(@"The newly added '(.*)' Location Type is listed in the search result grid in Location Type List page")]
        public void ThenTheNewlyAddedLocationTypeIsListedInTheSearchResultGridInLocationTypeListPage(string locationType)
        {
            Assert.True(LocationTypeList.Instance.IsFirstSearchResultRowDisplayed(),
                "The Location Type result table is NOT displayed in Location Type List page");
            Assert.True(LocationTypeList.Instance.IsNewLocationTypeAdded(locationType),
                $"The newly added '{locationType}' Location Type is NOT listed in the search result grid in Location Type List page");
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
