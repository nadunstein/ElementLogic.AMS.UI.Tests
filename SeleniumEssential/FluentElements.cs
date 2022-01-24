using System;

namespace SeleniumEssential
{
    public class FluentElements : WebDriverBase
    {
        public static FluentElements Instance => Singleton.Value;

        public FluentElement Navigate(string pageUrl)
        {
            Driver.Url = pageUrl;
            return FluentElement.Instance;
        }

        public FluentElement RefreshWebPage()
        {
            Driver.Navigate().Refresh();
            return FluentElement.Instance;
        }

        private FluentElements() { }

        private static readonly Lazy<FluentElements>
            Singleton = new Lazy<FluentElements>(() => new FluentElements());
    }
}
