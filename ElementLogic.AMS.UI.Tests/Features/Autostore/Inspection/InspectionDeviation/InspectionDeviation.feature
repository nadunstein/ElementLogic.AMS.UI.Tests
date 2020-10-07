Feature: Autostore Inspection Deviation
	 As an admin user, I want to verify the scenarios related to AutoStore Inspection Deviation

Background: 
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inspection tile in AutoStore Main Menu
	Then The Inspection-Create task page is loaded

@Regression
@AS_Inspection_InspectionDeviation
Scenario: Perform an Inspection with Deviation
	Given I include the location of 'ASIDP01' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission page is loaded
	And I include a Quantity to the Location Quantity field which is less than the Original Quantity in Autostore Inspection mission page
	When I click on Confirm button in Autostore Inspection mission page
	Then The Change Quantity dialog is displayed in Autostore Inspection mission page
	When I Click on YES button on Change Quantity dialog in Autostore Inspection mission page
	Then The Autostore task Menu should be loaded

@Regression
@AS_Inspection_InspectionDeviationWithReasonCode
Scenario: Perform an Inspection with Deviation and Reason Code
	Given I include the location of 'ASIDP02' product to the location field in Autostore Inspection-Create Task page
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission page is loaded
	And I include a Quantity to the Location Quantity field which is less than the Original Quantity in Autostore Inspection mission page
	Then I Select the reason code as 'breakage' in Autostore Inspection page
	When I click on Confirm button in Autostore Inspection mission page
	Then The Change Quantity dialog is displayed in Autostore Inspection mission page
	When I Click on YES button on Change Quantity dialog in Autostore Inspection mission page
	Then The Autostore task Menu should be loaded