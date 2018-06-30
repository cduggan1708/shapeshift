using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace ShapeShiftAutomation.PageObjects
{
    abstract class BasePageObject
    { 
        private IWebDriver driver;

        private const int DefaultTimeoutSeconds = 30;

        public BasePageObject()
        {
            driver = FeatureContext.Current.Get<IWebDriver>();
        }

        public abstract void VerifyPageLoaded();

        public void GoToUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void SwitchToNewTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        protected IWebElement GetElement(By identifier)
        {
            return WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(identifier));
        }

        protected IWebElement GetClickableElement(By identifier)
        {
            return WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(identifier));
        }

        protected void ClickElement(By identifier)
        {
            GetClickableElement(identifier).Click();
        }

        protected string GetElementText(By identifier)
        {
            string ret = string.Empty;

            IWebElement elem = GetElement(identifier);
            if (elem != null)
            {
                ret = elem.Text;
            }

            return ret;
        }
        
        protected IWebElement WaitUntil(Func<IWebDriver, IWebElement> expectedCondition)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeoutSeconds)).Until(expectedCondition);
        }

        protected bool WaitUntil(Func<IWebDriver, bool> expectedCondition)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeoutSeconds)).Until(expectedCondition);
        }
    }
}
