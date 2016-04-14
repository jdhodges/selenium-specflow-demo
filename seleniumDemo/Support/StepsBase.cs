using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDemo.Support {
    public abstract class StepsBase {
        protected IWebDriver driver { get; }

        protected Actions actions { get; }

        public StepsBase() {
            driver = SeleniumSupport.driver;
            actions = new Actions(driver);
        }
    }
}
