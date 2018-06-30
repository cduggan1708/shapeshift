using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ShapeShiftAutomation.PageObjects
{
    class CoinsPageObject : BasePageObject
    {
        private const string Url = "https://shapeshift.io/#/coins";
        private const string ButtonNameDeposit = "deposit";
        private const string ButtonNameReceive = "receive";
        private const string AttributeNamePrice = "price";
        private const string AttributeNamePercentage = "percentage";

        // please add ids! and don't judge me for using xpath.. these particular xpaths are more reliable than css selector
        private const string DepositLabel = "//label[text()='Deposit']";
        private const string ReceiveLabel = "//label[text()='Receive']";
        private const string ButtonSelector = "/following-sibling::div/button";
        private const string ButtonNameSelector = "/span/h4/span";
        private By DepositButton = By.XPath(string.Format("{0}{1}", DepositLabel, ButtonSelector));
        private By ReceiveButton = By.XPath(string.Format("{0}{1}", ReceiveLabel, ButtonSelector));
        private By DepositAssetName = By.XPath(string.Format("{0}{1}{2}", DepositLabel, ButtonSelector, ButtonNameSelector));
        private By ReceiveAssetName = By.XPath(string.Format("{0}{1}{2}", ReceiveLabel, ButtonSelector, ButtonNameSelector));
        
        public CoinsPageObject()
        {
            GoToUrl(Url);
            VerifyPageLoaded();
            ScenarioContext.Current.Set<BasePageObject>(this);
        }

        public override void VerifyPageLoaded()
        {
            WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(DepositButton));
        }

        public void ClickButton(string buttonName)
        {
            switch (buttonName.ToLower())
            {
                case ButtonNameDeposit:
                    ClickElement(DepositButton);
                    break;
                case ButtonNameReceive:
                    ClickElement(ReceiveButton);
                    break;
                default:
                    Assert.Fail(string.Format("Button name [{0}] is not supported; please add it to CoinsPageObject.ClickButton()", buttonName));
                    break;
            }

            // switch to the Asset Selection page object
            ScenarioContext.Current.Set<BasePageObject>(new CoinsAssetSelectionPageObject());
        }

        public string GetAssetName(string assetAction)
        {
            string ret = string.Empty;

            switch (assetAction.ToLower())
            {
                case ButtonNameDeposit:
                    ret = GetElementText(DepositAssetName);
                    break;
                case ButtonNameReceive:
                    ret = GetElementText(ReceiveAssetName);
                    break;
                default:
                    Assert.Fail(string.Format("Asset Type [{0}] is not supported; please add it to CoinsPageObject.GetAssetName()", assetAction));
                    break;
            }

            return ret;
        }

        public string GetAssetAttribute(string assetAttribute, string assetName)
        {
            string ret = string.Empty;

            switch (assetAttribute.ToLower())
            {
                case AttributeNamePrice:
                    ret = GetElementText(By.XPath(string.Format("//strong[text()='{0}']/following-sibling::span", assetName)));
                    break;
                case AttributeNamePercentage:
                    ret = GetElementText(By.XPath(string.Format("//strong[text()='{0}']/following-sibling::span/following-sibling::span", assetName)));
                    break;
                default:
                    Assert.Fail(string.Format("Asset Attribute [{0}] is not supported; please add it to CoinsPageObject.GetAssetAttribute()", assetAttribute));
                    break;
            }

            return ret;
        }

        public void ClickAssetTicker(string assetName)
        {
            ClickElement(By.XPath(string.Format("//strong[text()='{0}']", assetName)));

            // switch to the Coin Cap page object
            ScenarioContext.Current.Set<BasePageObject>(new CoinCapPageObject());
        }
    }
}
