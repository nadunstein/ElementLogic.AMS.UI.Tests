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
	Then The Autostore Inspection mission page is loaded
	And I include the actual quantity to the Location Quantity field in Autostore Inspection mission page
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore task Menu is loaded