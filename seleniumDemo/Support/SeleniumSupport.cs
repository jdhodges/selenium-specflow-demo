using System;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumDemo.Support {

    [Binding]
    public static class SeleniumSupport {
        public static IWebDriver driver { get; private set; }

        [BeforeTestRun]
        public static void BeforeTestRun() {
            driver = new ChromeDriver(@"C:\Tools\chrome-driver");
            driver.Navigate().GoToUrl("http://todomvc.com/examples/react/");
        }

        [AfterTestRun]
        public static void AfterTestRun() {
            driver.Quit();
        }
    }
}
