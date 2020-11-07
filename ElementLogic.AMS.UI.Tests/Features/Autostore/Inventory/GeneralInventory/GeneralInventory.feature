Feature: Autostore Inventory
	As an admin user, I want to verify the scenarios related to AutoStore Inventory

Background: 
	Given I login to the AdminModule as 'Admin' user
	And I navigate to the Inventory order list page
	When I click on the inventory add button of the Inventory order list page
	Then The Inventory details page is loaded
	And I include the productId as 'ASGINVP01' to the FromProductId field in the Inventory details page
	When I click on the Add button in the Inventory details page
	Then The Inventory count confirmation dialog is displayed in the Inventory details page
	When I click on the Yes button on inventory count confirmation dialog in the Inventory details page
	Then The inventory record is added to the inventory details grid in the Inventory details page
	And I click on the Activate menu item on the Inventory details page

@Regression
@Inventory
@Scenario:'1'
@Autostore:Inventory:GeneralInventory
Scenario: Perform a General Autostore Inventory
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the location quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Autostore inventory mission '2' is loaded
	And I include the location quantity as '20' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded