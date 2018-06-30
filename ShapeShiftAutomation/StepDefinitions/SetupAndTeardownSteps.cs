using ShapeShiftAutomation.Common;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ShapeShiftAutomation.StepDefinitions
{
    [Binding]
    class SetupAndTeardownSteps
    {

        private static IWebDriver driver;

        [BeforeFeature]
        public static void BeforeFeatureStep()
        {
            driver = DriverHelper.GetDriver();

            // driver is accessible from FeatureContext
            FeatureContext.Current.Set<IWebDriver>(driver);
        }

        [AfterScenario]
        public static void AfterScenarioStep()
        {
            ScenarioContext.Current.Clear();
        }

        [AfterFeature]
        public static void AfterFeatureStep()
        {
            driver.Quit();
            FeatureContext.Current.Clear();
        }
    }
}
