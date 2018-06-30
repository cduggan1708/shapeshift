using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ShapeShiftAutomation.Common
{
    class DriverHelper
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
