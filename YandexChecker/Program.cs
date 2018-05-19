using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace YandexChecker {
	class Program {
		static void Main(string[] args)
		{
			var Browser = new ChromeDriver();
			var a = Browser.Url;
			Browser.Navigate().GoToUrl("https://yandex.ru");

			var yandexMain = new YandexPageMain(Browser);
            YandexSearchResults yandexResult = yandexMain.Search("Конёк Горбунёк растущий стул");


            int number = yandexResult.CheckLink("kon-gor.com");

            //yandexResult.WaitForResultsLoad();
            yandexResult.GoToOtherResultTab();
            yandexResult.GoToOtherResultTab();
            yandexResult.GoToOtherResultTab();
            yandexResult.GoToOtherResultTab();
            yandexResult.GoToOtherResultTab();


            Browser.Quit();
		}
	}

	class YandexPageMain : IPage{
		public ChromeDriver Browser { get; set; }

        public YandexPageMain(ChromeDriver driver)
		{
			Browser = driver;
		}

		public YandexSearchResults Search(string pathRequest)
		{
			var ReqString = Browser.FindElementById("text");
			ReqString.SendKeys(pathRequest);
			ReqString.Submit();
			return new YandexSearchResults(Browser);
		}
	}

	class YandexSearchResults: IPage {
		public YandexSearchResults(ChromeDriver driver)
		{
			Browser = driver;
		}


		public ChromeDriver Browser { get; set; }

        public List<IWebElement> Results => Browser.FindElementsByXPath("//li[@class='serp-item']/parent::ul/li[not(@aria-label)]").ToList();

        
        public int CheckLink(string link)
        {
            int i = 1;
            foreach (var result in Results)
            {
                var a = result.FindElement(By.ClassName("link_outer_yes"));
                if(a.Text == link)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }
        
        public void GoToOtherResultTab() {

            WaitForResultsLoad();

            WebDriverWait wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.XPath("//div[@aria-label = 'Страницы']/a[text() = 'дальше']")).Displayed == true);
            IWebElement ContinueButton = Browser.FindElementByXPath("//div[@aria-label = 'Страницы']/a[text() = 'дальше']");
            ContinueButton.Click();
        }

        public void WaitForResultsLoad()
        {   
            for(int i = 0; i < 100; i++)
            {
                if (Browser.FindElementByXPath("//body").GetAttribute("aria-busy") == null)
                {
                    break;
                }

                if (Browser.FindElementByXPath("//body").GetAttribute("aria-busy").ToString() == "true")
                {
                    Thread.Sleep(100);
                }
            } 
        }
	}


}