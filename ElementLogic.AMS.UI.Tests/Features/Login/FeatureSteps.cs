using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using LoginPage = ElementLogic.AMS.UI.Tests.Pages.Login.Login;

namespace ElementLogic.AMS.UI.Tests.Features.Login
{
    [Binding]
    public class FeatureSteps
    {
        private static ScenarioContext _scenarioContext;

        [Then(@"The Admin module login page is loaded")]
        [Then(@"The Autostore login page is loaded")]
        public void ThenTheLoginPageIsLoaded()
        {
            Assert.IsTrue(LoginPage.Instance.IsPageLoaded(), "The Autostore login page is not loaded");
        }

        [Given(@"I login to the AdminModule as '(.*)' user")]
        [Then(@"I login to the AdminModule as '(.*)' user")]
        public void GivenILoginToTheAdminModuleAsUser(string nameOfTheUser)
        {
            if (_scenarioContext.ScenarioInfo.Tags.Contains("RunTestsInline") &&
                bool.Parse(_scenarioContext["RunTestsInline"].ToString()))
            {
                return;
            }

            LoginPage.Instance.NavigateToAdminModule();
            LoginPage.Instance.LoginToApplication(nameOfTheUser);
        }

        [Given(@"I login to the Autostore port '(.*)' as '(.*)' user")]
        public void GivenILoginToTheAutostorePortAsUser(string portNumber, string nameOfTheUser)
        {
            LoginPage.Instance.NavigateToAutoStore(portNumber);
            LoginPage.Instance.LoginToApplication(nameOfTheUser);
        }

        private FeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
