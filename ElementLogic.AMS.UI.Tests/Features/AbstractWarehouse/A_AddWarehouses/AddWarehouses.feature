Feature: Admin Add Warehouses
	As an admin user, I want to verify the scenarios related to Add Warehouses

@Regression
@WarehouseImplementationTest
Scenario: Adding a new Warehouse in Warehouse list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Warehouse List page
	When I click on Add button in Warehouse List page
	Then The Warehouse adding row is displayed on the search result grid in Warehouse List page
	And I enter values to the fields in adding row on the search result grid in Warehouse List page as follows:
	| FieldName   | Value          |
	| Code        | AS             |
	| Description | AutoStore Zone |
	When I click on Save button in adding row on the search result grid in Warehouse List page
	Then The newly added Warehouse is listed in the search result grid in Warehouse List page