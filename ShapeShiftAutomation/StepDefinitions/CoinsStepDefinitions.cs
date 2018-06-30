using NUnit.Framework;
using ShapeShiftAutomation.PageObjects;
using TechTalk.SpecFlow;

namespace ShapeShiftAutomation.StepDefinitions
{
    [Binding]
    class CoinsStepDefinitions
    {

        [Given(@"I am a user on ShapeShift's Coins page")]
        public void GivenIAmAUserOnShapeShiftSCoinsPage()
        {
            new CoinsPageObject();
        }

        [When(@"I click the ""(.*)"" button")]
        public void WhenIClickTheButton(string buttonName)
        {
            ((CoinsPageObject)ScenarioContext.Current.Get<BasePageObject>()).ClickButton(buttonName);
        }

        [When(@"I click the asset ""(.*)""")]
        public void WhenIClickTheAsset(string assetName)
        {
            ((CoinsAssetSelectionPageObject)ScenarioContext.Current.Get<BasePageObject>()).ClickAsset(assetName);
        }

        [When(@"I get the ""(.*)"" of the asset ""(.*)""")]
        public void WhenIGetTheOfTheAsset(string assetAttribute, string assetName)
        {
            string assetAttributeValue = ((CoinsPageObject)ScenarioContext.Current.Get<BasePageObject>()).GetAssetAttribute(assetAttribute, assetName);

            // save the value to be compared in a subsequent step
            ScenarioContext.Current.Set<string>(assetAttributeValue, assetAttribute);
        }

        [When(@"I click on the asset ""(.*)"" in the ticker")]
        public void WhenIClickOnTheAssetInTheTicker(string assetName)
        {
            ((CoinsPageObject)ScenarioContext.Current.Get<BasePageObject>()).ClickAssetTicker(assetName);
        }

        [Then(@"the asset to ""(.*)"" is ""(.*)""")]
        public void ThenTheAssetToIs(string assetAction, string expectedAssetName)
        {
            string actualAssetName = ((CoinsPageObject)ScenarioContext.Current.Get<BasePageObject>()).GetAssetName(assetAction);
            Assert.True(actualAssetName.Equals(expectedAssetName), string.Format("Expected {0} to have asset with name [{1}] but found [{2}]", assetAction, expectedAssetName, actualAssetName));
        }

        [Then(@"the ""(.*)"" should match the one on Coin Cap")]
        public void ThenTheShouldMatchTheOneOnCoinCap(string assetAttribute)
        {
            string coinCapValue = ((CoinCapPageObject)ScenarioContext.Current.Get<BasePageObject>()).GetAssetAttribute(assetAttribute);
            string coinsValue = ScenarioContext.Current.Get<string>(assetAttribute);

            Assert.True(coinsValue.Equals(coinCapValue), string.Format("Expected Coins' {0} value to match Coin Cap's value [{1}] but actually is [{2}]", assetAttribute, coinCapValue, coinsValue));
        }

    }
}
