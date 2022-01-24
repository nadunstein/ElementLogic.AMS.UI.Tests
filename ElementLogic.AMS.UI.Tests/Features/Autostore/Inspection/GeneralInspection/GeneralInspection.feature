Feature: Autostore General Inspection
	 As an admin user, I want to verify the scenarios related to AutoStore Inspection

Background:
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inspection tile in AutoStore Main Menu
	Then The Inspection-Create task page is loaded

@Regression
@Scenario:'1'
@Autostore:Inspection:GeneralInspection
Scenario: Perform a General Inspection 
	Given I include the location of 'ASIP01' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission '1' is loaded
	And I verify the Quantity field value is displayed in Autostore Inspection Mission page
	And I include the actual quantity to the Location Quantity field in Autostore Inspection mission page
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore task Menu is loaded

@Regression
@Scenario:'2'
@Autostore:Inspection:GeneralInspection
Scenario: Perform a General Inspection for a multiple compartment bin with empty locations
	Given I include the Bin Id of 'ASIP02' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission '1' is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore Inspection mission '2' is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore Inspection mission '3' is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore Inspection mission '4' is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore task Menu is loaded

@Regression
@Scenario:'3'
@Autostore:Inspection:GeneralInspection
Scenario: Verify only the correct product location(s) are listed when there is are products with EAN Id starting from the same product id of the inspecting product
	Given I include the product as 'ASIP03' to the Product field and select in Autostore Inspection-Create Task page
	When I click on Select Locations button in Autostore Inspection-Create Task page
	Then The Autostore Inspection-Select locations page is loaded
	And I verify the location count is '2' in Autostore Inspection-Select locations page
	And I click on Select all locations button in Autostore Inspection-Select locations page
	When I click on confirm button in Autostore Inspection-Select locations page
	Then The Autostore Inspection mission '1' is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore Inspection mission '2' is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore task Menu is loaded

@Regression
@Scenario:'4'
@Autostore:Inspection:GeneralInspection
Scenario: User does not complete the taskgroup and exits the Autostore Inspection page
	Given I include the location of 'ASIP04' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission '1' is loaded
	When I click on Exit button in Autostore Inspection Mission page
	Then The Delete mission popup is displayed in Autostore Inspection Mission page
	When I click on 'Yes' button on Delete mission popup in Autostore Inspection Mission page
	Then The Autostore task Menu is loaded

@Regression
@Scenario:'5'
@Autostore:Inspection:GeneralInspection
Scenario: Verify the quantity can be hidden from the parameter in Autostore Inspection page
	Given I include the location of 'ASIP05' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission '1' is loaded
	And I verify the Quantity field value is not displayed in Autostore Inspection Mission page

@Regression
@Scenario:'6'
@Autostore:Inspection:GeneralInspection
Scenario: Perform a General Inspection with batch Id
	Given I include the product as 'ASIP06' to the Product field and select in Autostore Inspection-Create Task page
	And I select the Batch Id as '20' to the Batch field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission '1' is loaded
	And I verify the Quantity field value is '20' in Autostore Inspection Mission page
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore task Menu is loaded