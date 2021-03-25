Feature: Autostore Putaway Confirm Quantity Popup
	As an Admin user, I want to verify theAutostore Putaway Confirm Quantity Popup related scenarios

@Regression
@Scenario:'1'
@Autostore:Putaway:ConfirmQuantityPopup
Scenario: Verify max location quantity when BB_MaxQty is used for existing product for autostore direct putaway
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPCQPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	Then I verify max location quantity value is '123' in Autostore putaway quantity confirm popup

@Regression
@Scenario:'2'
@Autostore:Putaway:ConfirmQuantityPopup
Scenario: Verify max location quantity when BB_MaxQty is used for new product for autostore direct putaway
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPCQPP02' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	Then I verify max location quantity value is '123' in Autostore putaway quantity confirm popup