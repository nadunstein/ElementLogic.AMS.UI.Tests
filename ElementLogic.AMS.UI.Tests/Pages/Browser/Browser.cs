using System;
using SeleniumEssential;

namespace ElementLogic.AMS.UI.Tests.Pages.Browser
{
    public class Browser
    {
        public static Browser Instance => Singleton.Value;

        public bool OpenNewChromeBrowserTab()
        {
            return PageObjectHelper.Instance.OpenNewBrowserTab();
        }

        public bool SwitchToNewChromeBrowserTab()
        {
            var openedBrowserTabCount = PageObjectHelper.Instance.GetOpenedBrowserTabCount();
            return PageObjectHelper.Instance.SwitchToBrowserTab(openedBrowserTabCount);
        }

        public bool SwitchToPreviousChromeBrowserTab()
        {
            var openedBrowserTabCount = PageObjectHelper.Instance.GetOpenedBrowserTabCount();
            return PageObjectHelper.Instance.SwitchToBrowserTab(openedBrowserTabCount - 1);
        }

        private Browser() { }

        private static readonly Lazy<Browser> Singleton = new Lazy<Browser>(() => new Browser());
    }
}
