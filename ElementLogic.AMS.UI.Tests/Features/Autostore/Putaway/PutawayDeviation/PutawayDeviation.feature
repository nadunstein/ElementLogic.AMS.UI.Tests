Feature: Autostore Putaway Deviation
	As a user, I want to verify the scenarios related to Autostore Putaway Deviation

@Regression
@Scenario:'1'
@Autostore:Putaway:PutawayDeviation
Scenario: Verify Autostore putaway deviation and proposing a new bin for the deviated quantity
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPDP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I Include max location quantity value as '20' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And I verify the Quantity field value is '20' in Autostore Putaway Mission page
	And I change the quantity of the Quantity field as '10' in Autostore putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The maximum bin quantity popup is displayed in Autostore putaway Mission page
	When I click on 'Yes' button on maximum bin quantity popup in Autostore putaway Mission page
	Then The Autostore putaway mission '1' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page	
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page
	And I verify a new autostore bin is proposed for the putaway mission in Autostore Putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page

@Regression
@Scenario:'2'
@Autostore:Putaway:PutawayDeviation
Scenario: Verify Autostore putaway deviation without putaway quantity confirm popup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'B 1/2 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPMBP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The '2' putaway orders are listed for product in Autostore Putaway Selection page
	When I click on first Select button of the product 'ASPMBP01' from order list in Autostore Putaway Selection page
	Then The Autostore putaway mission '1' is loaded
	And I verify the Quantity field value is '20' in Autostore Putaway Mission page
	And I change the quantity of the Quantity field as '10' in Autostore putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The maximum bin quantity popup is displayed in Autostore putaway Mission page
	When I click on 'Yes' button on maximum bin quantity popup in Autostore putaway Mission page
	Then The Autostore putaway mission '1' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page	
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page
	And I Include Product Id as 'ASPMBP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The Autostore putaway mission '1' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page

@Regression
@Scenario:'3'
@Autostore:Putaway:PutawayDeviation
Scenario: Verify Autostore putaway deviation with zero quantity
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'B 1/2 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPDP02' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And I verify the Quantity field value is '10' in Autostore Putaway Mission page
	And I change the quantity of the Quantity field as '0' in Autostore putaway Mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The maximum bin quantity popup is displayed in Autostore putaway Mission page
	When I click on 'No' button on maximum bin quantity popup in Autostore putaway Mission page
	Then The Change quantity popup is displayed in Autostore putaway Mission page
	When I click on 'Yes' button on change quantity popup in Autostore putaway Mission page
	Then The Confirm new putaway creation popup is displayed in Autostore putaway Mission page
	When I click on 'No' button on confirm new putaway creation popup in Autostore putaway Mission page
	Then I Navigate to Autostore Putaway Selection page