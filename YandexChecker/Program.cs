using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YandexChecker {
	class Program {
		static void Main(string[] args)
		{
			var Browser = new ChromeDriver();
			var a = Browser.Url;
			Browser.Navigate().GoToUrl("https://yandex.ru");

			var yandexMain = new YandexPageMain(Browser);
			yandexMain.Search("Конёк Горбунёк растущий стул");

			Browser.Quit();
		}
	}

	class YandexPageMain {
		private ChromeDriver Browser;

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

	class YandexSearchResults {
		private ChromeDriver Browser;

		public YandexSearchResults(ChromeDriver driver)
		{
			Browser = driver;
		}
	}
}
