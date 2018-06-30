using NUnit.Framework;
using ShapeShiftAutomation.PageObjects;
using TechTalk.SpecFlow;

namespace ShapeShiftAutomation.StepDefinitions
{
    [Binding]
    class CommonStepDefinitions
    {
        private const string CoinsPage = "Coins";
        private const string CoinsAssetSelectionPage = "Coins Asset Selection";
        private const string CoinCapPage = "Coin Cap";

        [Then(@"I should be directed to the ""(.*)"" page")]
        public void ThenIShouldBeDirectedToThePage(string pageName)
        {
            switch (pageName)
            {
                case CoinsPage:
                    ((CoinsPageObject)ScenarioContext.Current.Get<BasePageObject>()).VerifyPageLoaded();
                    break;
                case CoinsAssetSelectionPage:
                    ((CoinsAssetSelectionPageObject)ScenarioContext.Current.Get<BasePageObject>()).VerifyPageLoaded();
                    break;
                default:
                    Assert.Fail(string.Format("Page [{0}] not implemented; please add to CommonStepDefinitions.ThenIShouldBeDirectedToThePage", pageName));
                    break;
            }

        }

        [Then(@"I should be directed to the ""(.*)"" page in a new tab")]
        public void ThenIShouldBeDirectedToThePageInANewTab(string pageName)
        {
            switch (pageName)
            {
                case CoinCapPage:
                    BasePageObject po = ((CoinCapPageObject)ScenarioContext.Current.Get<BasePageObject>());
                    po.SwitchToNewTab();
                    po.VerifyPageLoaded();
                    break;
                default:
                    Assert.Fail(string.Format("Page [{0}] not implemented; please add to CommonStepDefinitions.ThenIShouldBeDirectedToThePageInANewTab", pageName));
                    break;
            }
        }
    }    
}
