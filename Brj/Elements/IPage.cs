﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace Brj
{
    interface IPage
    {
        ChromeDriver Browser { get; }
    }
}
