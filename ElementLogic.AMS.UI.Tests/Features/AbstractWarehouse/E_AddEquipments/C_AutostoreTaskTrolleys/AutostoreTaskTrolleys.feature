Feature: Admin Add Autostore Task trolleys
	As an admin user, I want to verify the scenarios related to Add Autostore Task trolleys

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore Task Trolley 01 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value                     |
	| Code                | AST1                      |
	| Name                | AutoStore Task Trolley 01 |
	| Warehouse zone      | AutoStore Zone            |
	| Type                | AutoStore Trolly          |
	| Use pick containers | True                      |
	| Active              | True                      |
	| Width               | 10                        |
	| Depth               | 10                        |
	| Height              | 10                        |
	| Task type           | Normal AS                 |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value      |
	| Shelves       | 10         |
	| Type          | Pick       |
	| Location size | AS Trolley |
	| Positions     | 1          |
	| Depths        | 1          |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AutoStore Task Trolley 01' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore Task Trolley 02 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value                     |
	| Code                | AST2                      |
	| Name                | AutoStore Task Trolley 02 |
	| Warehouse zone      | AutoStore Zone            |
	| Type                | AutoStore Trolly          |
	| Use pick containers | True                      |
	| Active              | True                      |
	| Width               | 10                        |
	| Depth               | 10                        |
	| Height              | 10                        |
	| Task type           | Internet                  |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value      |
	| Shelves       | 10         |
	| Type          | Pick       |
	| Location size | AS Trolley |
	| Positions     | 1          |
	| Depths        | 1          |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AutoStore Task Trolley 02' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore Task Trolley 03 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value                     |
	| Code                | AST3                      |
	| Name                | AutoStore Task Trolley 03 |
	| Warehouse zone      | AutoStore Zone            |
	| Type                | AutoStore Trolly          |
	| Use pick containers | True                      |
	| Active              | True                      |
	| Width               | 10                        |
	| Depth               | 10                        |
	| Height              | 10                        |
	| Task type           | Small Order               |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value      |
	| Shelves       | 10         |
	| Type          | Pick       |
	| Location size | AS Trolley |
	| Positions     | 1          |
	| Depths        | 1          |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AutoStore Task Trolley 03' Equipment is listed in the search result grid in Equipment list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore Task Trolley 04 in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value                     |
	| Code                | AST4                      |
	| Name                | AutoStore Task Trolley 04 |
	| Warehouse zone      | AutoStore Zone            |
	| Type                | AutoStore Trolly          |
	| Use pick containers | True                      |
	| Active              | True                      |
	| Width               | 10                        |
	| Depth               | 10                        |
	| Height              | 10                        |
	| Task type           | PrepTaskgroup             |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value      |
	| Shelves       | 1          |
	| Type          | Pick       |
	| Location size | AS Trolley |
	| Positions     | 1          |
	| Depths        | 1          |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded	
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AutoStore Task Trolley 04' Equipment is listed in the search result grid in Equipment list page