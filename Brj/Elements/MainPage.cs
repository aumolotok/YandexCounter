using Brj.Elements.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Brj.Elements
{
    class MainPage : IPage
    {
        public ChromeDriver Browser { get; }

        public GlassObject glassObject;

        public MainPage(ChromeDriver browser)
        {
            Browser = browser;
        }

        public MainPage Init()
        {
            glassObject = new GlassObject(this, By.XPath(".//tbody[@class = 'scrollStyle ask-table']"));
            return this;
        }
    }
}
