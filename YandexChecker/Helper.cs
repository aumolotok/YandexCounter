using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YandexChecker
{
    static class Helper
    {
        public static void WaitForLoad(this IPage page)
        {
            int i = 0;
            while (page.Browser.ExecuteScript("return document.readyState").ToString() != "complete" && i < 5)
            {
                i++;
                Thread.Sleep(1000);     
            }
        }
    }
}
