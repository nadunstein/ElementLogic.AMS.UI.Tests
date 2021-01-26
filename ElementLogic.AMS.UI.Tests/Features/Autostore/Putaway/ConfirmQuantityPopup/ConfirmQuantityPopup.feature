Feature: Autostore Putaway
	As a user, I want to verify the scenarios related to confirm quantity

@Regression
@Scenario:'1'
@Autostore:Putaway:ConfirmQuantityPopup
Scenario: Verify autostore putaway max location quantity when BB_MaxQty is used
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPCQP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And The quantity field value should be '15' in Autostore putaway quantity confirm popup
	Then I verify max location quantity value is '100' in Autostore putaway quantity confirm popup