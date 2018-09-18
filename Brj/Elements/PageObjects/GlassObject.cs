using OpenQA.Selenium;

namespace Brj.Elements.PageObjects
{
    class GlassObject
    {
        private IWebElement wraptedElement;

        private IPage parentPage;
        
        public GlassObject ( IPage page, By locator)
        {
            parentPage = page;
            wraptedElement = page.Browser.FindElement(locator);
        }

        public IWebElement PriceElement => wraptedElement.FindElement(By.XPath(".//tr[last()]//td[1]"));

        public string GetValue() => PriceElement.Text;
    }
}
