Feature: Autostore Putaway More
	As a user, I want to verify the scenarios related to Autostore Putaway More

@Regression
@Scenario:'1'
@Autostore:Putaway:PutawayMore
Scenario: Verify autostore putaway more button is displayed in putaway mission
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPMP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And The quantity field value should be '15' in Autostore putaway quantity confirm popup
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The PutawayMore Button is not displayed in the Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And The PutawayMore Button is displayed in the Autostore putaway mission page
	When I click on PutawayMore button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page