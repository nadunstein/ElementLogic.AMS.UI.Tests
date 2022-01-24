Feature: Autostore Pick Reassign
	As an admin user, I want to verify the scenarios related to Autostore Pick Reassign

@Pick
@Regression
@Inventory
@Scenario:'1'
@Autostore:Pick:PickReassign
Scenario: Verify reassign pick missions when quantity is reduced during Inventory
	Given I login to the AdminModule as 'Admin' user
	And I navigate to the Inventory order list page
	When I click on the inventory add button of the Inventory order list page
	Then The Inventory details page is loaded
	And I include the locationId as the pick order reserved location of the product 'ASPRP01' to the FromLocationId field in the Inventory details page
	When I click on the Add button in the Inventory details page
	Then The Inventory count confirmation dialog is displayed in the Inventory details page
	When I click on the Yes button on inventory count confirmation dialog in the Inventory details page
	Then The inventory record is added to the inventory details grid in the Inventory details page
	And I click on the Activate menu item on the Inventory details page
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inventory tile in AutoStore Main Menu
	Then The Autostore inventory mission '1' is loaded
	And I include the location quantity as '5' to the Location quantity field in Autostore inventory mission page
	When I click on Confirm button in Autostore inventory mission page
	Then The Confirm Quantity popup is displayed in Autostore inventory page
	When I click on 'Yes' button on Confirm Quantity popup in Autostore inventory page
	Then No more tasks popup is displayed in Autostore inventory mission page
	When I click on OK button on No more tasks popup in Autostore inventory mission page
	Then The Autostore task Menu is loaded
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the Quantity field value is '5' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the Quantity field value is '5' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Inventory
@Scenario:'2'
@Autostore:Pick:PickReassign
Scenario: Verify reassign pick missions when quantity is reduced during Inspection
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inspection tile in AutoStore Main Menu
	Then The Inspection-Create task page is loaded
	And I include the location of 'ASPRP02' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission '1' is loaded
	And I include the location quantity as '5' to the Location quantity field in Autostore Inspection mission page
	When I click on Confirm button in Autostore Inspection mission page
	Then The Change Quantity dialog is displayed in Autostore Inspection mission page
	When I Click on YES button on Change Quantity dialog in Autostore Inspection mission page
	Then The Autostore task Menu is loaded
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the Quantity field value is '5' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the Quantity field value is '5' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded