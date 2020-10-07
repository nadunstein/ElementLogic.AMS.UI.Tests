Feature: Admin Add WarehouseZones
	As an admin user, I want to verify the scenarios related to Add WarehouseZones

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Pick Zone in Warehouse zone list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Warehouse Zone List page
	When I click on Add button in Warehouse Zone List page
	Then The Add/Edit Zone page is loaded
	And I enter values to the fields in Add/Edit Zone page as follows:
	| FieldName         | Value          |
	| Code              | AS zone        |
	| Description       | AutoStore Zone |
	| Location template | %s-%2d-%2d-%2d |
	| Zone type         | Pick zone      |
	| Warehouse         | AutoStore Zone |
	| FiFo              | True           |

	Then I click on Save button in Add/Edit zone
	When I click on Cancel add button in Add/Edit zone
	Then The Warehouse Zone List page is loaded
	And The newly added 'AS zone' warehouse zone is listed in the search result grid in Warehouse zone list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Transport Zone in Warehouse zone list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Warehouse Zone List page
	When I click on Add button in Warehouse Zone List page
	Then The Add/Edit Zone page is loaded
	And I enter values to the fields in Add/Edit Zone page as follows:
	| FieldName         | Value             |
	| Code              | TP zone           |
	| Description       | Transport Putaway |
	| Location template | %s-%1d            |
	| Zone type         | Transport zone    |
	| Warehouse         | AutoStore Zone    |
	| FiFo              | False             |

	Then I click on Save button in Add/Edit zone
	When I click on Cancel add button in Add/Edit zone
	Then The Warehouse Zone List page is loaded
	And The newly added 'TP zone' warehouse zone is listed in the search result grid in Warehouse zone list page