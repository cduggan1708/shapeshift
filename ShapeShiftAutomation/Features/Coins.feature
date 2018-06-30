Feature: Coins
	Given I am a ShapeShift candidate trying to show off my UI automation skills
	When I write some scenarios to test the Coins page
	Then I will make it to the next round of interviews :)

  Scenario Outline: Choose a digital asset to deposit and receive
	Given I am a user on ShapeShift's Coins page
	When I click the "Deposit" button
	Then I should be directed to the "Coins Asset Selection" page
	When I click the asset "<assetToDeposit>"
	Then I should be directed to the "Coins" page
	And the asset to "deposit" is "<assetToDeposit>"
	When I click the "Receive" button
	Then I should be directed to the "Coins Asset Selection" page
	When I click the asset "<assetToReceive>"
	Then I should be directed to the "Coins" page
	And the asset to "receive" is "<assetToReceive>"
	Examples: 
	  | assetToDeposit | assetToReceive |
	  | Bitcoin Cash   | Bancor         |
	  | Decred         | Golem          |

  Scenario Outline: Verify asset price and percentage against CoinCap (note, data does not always appear to be in sync so tests often fail)
    Given I am a user on ShapeShift's Coins page
	When I get the "price" of the asset "<asset>"
	And I get the "percentage" of the asset "<asset>"
	When I click on the asset "<asset>" in the ticker
	Then I should be directed to the "Coin Cap" page in a new tab
	And the "percentage" should match the one on Coin Cap
	And the "price" should match the one on Coin Cap
	Examples: 
	  | asset |
	  | DASH  |
	  | ETC   |

	
