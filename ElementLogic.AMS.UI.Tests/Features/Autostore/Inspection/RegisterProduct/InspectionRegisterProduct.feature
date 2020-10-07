Feature: Autostore Inspection Register Product
	As an admin user, I want to register product during AutoStore Inspection

Background: 
	Given I login to the Autostore port '01' as 'Admin' user
	When I Click on Inspection tile in AutoStore Main Menu
	Then The Inspection-Create task page is loaded

@Regression
@AS_Inspection_RegisterProduct
Scenario: Register product during Autostore Inspection
	Given I include an empty location to the location field in Autostore Inspection-Create Task page 
	When I click on confirm button in Autostore Inspection-Create Task page
	Then The Autostore Inspection mission page is loaded
	When I click on 'Register product' option item in Autostore Inspection mission page
	Then The Register Product popup is loaded in Autostore Inspection mission page
	Then I select 'ASIRP01' to the Product field on Autostore Inspection Register Product popup in Autostore Inspection mission page
	And I include '5' to the Location Quantity field in Autostore Inspection Register Product popup in Autostore Inspection mission page
	When I click the OK button in Autostore Inspection Register Product popup in Autostore Inspection mission page
	Then The Autostore Inspection mission page is loaded
	When I click on Confirm button in Autostore Inspection mission page
	Then The Autostore task Menu should be loaded
