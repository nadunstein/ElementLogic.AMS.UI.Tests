using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElementLogic.AMS.UI.Tests.Pages.Autostore.Putaway.Mission;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ElementLogic.AMS.UI.Tests.Features.Autostore.Putaway.PutawayMore
{
    [Binding]
    public sealed class FeatureSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"PutawayMore Button is not displayed in the Autostore putaway mission page")]
        public void ThenPutawayMoreButtonIsNotDisplayedInTheAutostorePutawayMissionPage()
        {
            Assert.False(PutawayMission.Instance.IsPutawayMoreButtonDisplayed(), "PutawayMore Button is displayed in the Autostore putaway mission page.");
        }

        [Then(@"PutawayMore Button is displayed in the Autostore putaway mission page")]
        public void ThenPutawayMoreButtonIsDisplayedInTheAutostorePutawayMissionPage()
        {
            Assert.True(PutawayMission.Instance.IsPutawayMoreButtonDisplayed(), "PutawayMore Button is not displayed in the Autostore putaway mission page.");
        }

        [When(@"I click on PutawayMore button in Autostore putaway mission page")]
        public void WhenIClickOnPutawayMoreButtonInAutostorePutawayMissionPage()
        {
            Assert.True(PutawayMission.Instance.ClickPutawayMoreButton(), "Unable to click on PutawayMore button in Autostore putaway mission page.");
        }
        //Putaway.AutoStore.AllowMultipleLinesPerLocation
    }
}
