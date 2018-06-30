using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ShapeShiftAutomation.PageObjects
{
    class CoinsAssetSelectionPageObject : BasePageObject
    {
        private By SearchBox = By.CssSelector("input[ng-model='search']");
        private By Modal = By.CssSelector("body > div.modal-backdrop.fade.in");

        public override void VerifyPageLoaded()
        {
            WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SearchBox));
        }

        public void ClickAsset(string assetName)
        {
            IWebElement modal = GetElement(Modal);
            ClickElement(By.XPath(string.Format("//strong[text()='{0}']", assetName)));

            // verify modal closed
            WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(modal));

            // switch to the Coins page object
            ScenarioContext.Current.Set<BasePageObject>(new CoinsPageObject());
        }
    }
}
