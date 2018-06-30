using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ShapeShiftAutomation.PageObjects
{
    class CoinCapPageObject : BasePageObject
    {
        private By CoinCapContainer = By.Id("CoinCap");
        private const string AttributeNamePrice = "price";
        private const string AttributeNamePercentage = "percentage";

        private By PriceValue = By.CssSelector(".coin_market_info_price span:nth-child(1)");
        private By PercentageValue = By.CssSelector(".coin_market_info_price span:nth-child(2)");

        public override void VerifyPageLoaded()
        {
            WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(CoinCapContainer));
        }

        public string GetAssetAttribute(string assetAttribute)
        {
            string ret = string.Empty;

            switch (assetAttribute.ToLower())
            {
                case AttributeNamePrice:
                    ret = GetElementText(PriceValue);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        Decimal dec = Decimal.Parse(ret.Trim('$'));
                        ret = "$" + Decimal.Parse(dec.ToString("F4")).ToString();
                    }
                    break;
                case AttributeNamePercentage:
                    ret = GetElementText(PercentageValue);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ret = ret.Trim('(').Trim(')');
                    }
                    break;
                default:
                    Assert.Fail(string.Format("Asset Attribute [{0}] is not supported; please add it to CoinCapPageObject.GetAssetAttribute()", assetAttribute));
                    break;
            }

            return ret;
        }
    }
}
