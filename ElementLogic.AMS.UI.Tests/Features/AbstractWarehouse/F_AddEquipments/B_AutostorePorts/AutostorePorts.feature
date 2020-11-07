Feature: Admin Add Autostore Ports
	As an admin user, I want to verify the scenarios related to Add Autostore Ports

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore port 01 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | 01                |
	| Name                | AS Port 01        |
	| Warehouse zone      | AutoStore Zone    |
	| Type                | AutoStore Station |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AS Port 01' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore port 02 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | 02                |
	| Name                | AS Port 02        |
	| Warehouse zone      | AutoStore Zone    |
	| Type                | AutoStore Station |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AS Port 02' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore port 03 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | 03                |
	| Name                | AS Port 03        |
	| Warehouse zone      | AutoStore Zone    |
	| Type                | AutoStore Station |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AS Port 03' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore port 04 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | 04                |
	| Name                | AS Port 04        |
	| Warehouse zone      | AutoStore Zone    |
	| Type                | AutoStore Station |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AS Port 04' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore port 05 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | 05                |
	| Name                | AS Port 05        |
	| Warehouse zone      | AutoStore Zone    |
	| Type                | AutoStore Station |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AS Port 05' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore port 06 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value             |
	| Code                | 06                |
	| Name                | AS Port 06        |
	| Warehouse zone      | AutoStore Zone    |
	| Type                | AutoStore Station |
	| Use pick containers | True              |
	| Active              | True              |
	| Width               | 100               |
	| Depth               | 100               |
	| Height              | 100               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AS Port 06' Equipment is listed in the search result grid in Equipment list page
