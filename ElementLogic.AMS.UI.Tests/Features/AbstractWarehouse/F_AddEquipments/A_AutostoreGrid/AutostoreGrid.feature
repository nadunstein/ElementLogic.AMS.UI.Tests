Feature: Admin Add Autostore Grid
	As an admin user, I want to verify the scenarios related to Add Autostore Grid

@Regression
@WarehouseImplementationTest
Scenario: Adding a new equipment for AutoStore Grid in Equipment list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Equipment List page
	When I click on Add button in Equipment List page
	Then The Add/Edit equipment page is loaded
	And I enter values to the fields in Add/Edit equipment page as follows:
	| FieldName           | Value          |
	| Code                | AS             |
	| Name                | AutoStore Grid |
	| Warehouse zone      | AutoStore Zone |
	| Type                | AutoStore Grid |
	| Use pick containers | True           |
	| Active              | True           |
	| Width               | 100            |
	| Depth               | 100            |
	| Height              | 100            |
	
	Then I click on Save button in Add/Edit equipment page
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value               |
	| Shelves       | 1                   |
	| Type          | Pick                |
	| Location size | A 1/1 AutoStore Bin |
	| Positions     | 1                   |
	| Depths        | 1                   |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded
	
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AutoStore Grid' Equipment is listed in the search result grid in Equipment list page
	When I click on Equipment view button in Equipment list page	
	Then The Add/Edit equipment page is loaded

	When I click on Shelf edit button in Add/Edit equipment page
	Then The Edit shelf page is loaded
	And I Insert the Shelf number as '10001' in Edit shelf page
	When I click on Save button in Edit shelf page
	Then Shelf info popup is displayed in Edit shelf page
	And I click on Yes button on Shelf info popup in Edit shelf page
	When I click on Cancel button in Edit shelf page
	Then The Add/Edit equipment page is loaded
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value               |
	| Shelves       | 149                 |
	| Type          | Pick                |
	| Location size | A 1/1 AutoStore Bin |
	| Positions     | 1                   |
	| Depths        | 1                   |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded
	When I click on Shelf generator button in Add/Edit equipment page
	Then The Shelf generator popup is displayed in Add/Edit equipment page
	And I enter values to the fields in Shelf generator popup as follows:
	| FieldName     | Value               |
	| Shelves       | 50                  |
	| Type          | Pick                |
	| Location size | B 1/2 AutoStore Bin |
	| Positions     | 2                   |
	| Depths        | 1                   |

	When I click on Make shelves button
	Then The Add/Edit equipment page is loaded
	And I click on Save button in Add/Edit equipment page
	When I click on Cancel button in Add/Edit equipment page
	Then The Equipment list page is loaded
	And The newly added 'AutoStore Grid' Equipment is listed in the search result grid in Equipment list page