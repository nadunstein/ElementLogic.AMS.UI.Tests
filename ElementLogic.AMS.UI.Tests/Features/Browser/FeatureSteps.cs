using NUnit.Framework;
using TechTalk.SpecFlow;
using ChromeBrowser = ElementLogic.AMS.UI.Tests.Pages.Browser.Browser;

namespace ElementLogic.AMS.UI.Tests.Features.Browser
{
    [Binding]
    public sealed class FeatureSteps
    {
        [Then(@"I open a new Chrome browser tab")]
        public void ThenIOpenANewChromeBrowserTab()
        {
            Assert.IsTrue(ChromeBrowser.Instance.OpenNewChromeBrowserTab(), "Unable to open a new Chrome browser tab");
            Assert.IsTrue(ChromeBrowser.Instance.SwitchToNewChromeBrowserTab(),
                "Unable to switch to the new opened Chrome browser tab");
        }

        [Then(@"I Switch to the previous Chrome browser tab")]
        public void ThenISwitchToThePreviousChromeBrowserTab()
        {
            Assert.IsTrue(ChromeBrowser.Instance.SwitchToPreviousChromeBrowserTab(),
                "Unable to switch to the previous Chrome browser tab");
        }

        [Then(@"I Switch to the new Chrome browser tab")]
        public void ThenISwitchToTheNewChromeBrowserTab()
        {
            Assert.IsTrue(ChromeBrowser.Instance.SwitchToNewChromeBrowserTab(),
                "Unable to switch to the new opened Chrome browser tab");
        }
    }
}
