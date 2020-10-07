Feature: Admin Add LocationTypes
	As an admin user, I want to verify the scenarios related to Add LocationTypes

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Location Types for Autostore 1/1 Bin in Location type list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Location Type List page
	When I click on Add button in Location Type List page
	Then The Location type adding row is displayed on the search result grid in Location Type List page
	And I enter values to the fields in adding row on the search result grid in Location Type List page as follows:
	| FieldName | Value               |
	| Name      | A 1/1 AutoStore Bin |
	| Width     | 600                 |
	| Depth     | 400                 |
	| Height    | 330                 |
	| Category  | AutoStoreGrid       |
	| Type      | Pick                |

	When I click on Save button in adding row on the search result grid in Location Type List page
	Then The newly added 'A 1/1 AutoStore Bin' Location Type is listed in the search result grid in Location Type List page
	
@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Location Types for Autostore 1/2 Bin in Location type list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Location Type List page
	When I click on Add button in Location Type List page
	Then The Location type adding row is displayed on the search result grid in Location Type List page
	And I enter values to the fields in adding row on the search result grid in Location Type List page as follows:
	| FieldName | Value               |
	| Name      | B 1/2 AutoStore Bin |
	| Width     | 600                 |
	| Depth     | 400                 |
	| Height    | 330                 |
	| Category  | AutoStoreGrid       |
	| Type      | Pick                |

	When I click on Save button in adding row on the search result grid in Location Type List page
	Then The newly added 'B 1/2 AutoStore Bin' Location Type is listed in the search result grid in Location Type List page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Location Types for Autostore Trolley in Location type list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Location Type List page
	When I click on Add button in Location Type List page
	Then The Location type adding row is displayed on the search result grid in Location Type List page
	And I enter values to the fields in adding row on the search result grid in Location Type List page as follows:
	| FieldName | Value            |
	| Name      | AS Trolley       |
	| Width     | 20               |
	| Depth     | 20               |
	| Height    | 20               |
	| Category  | AutoStoreTrolley |
	| Type      | Transport        |

	When I click on Save button in adding row on the search result grid in Location Type List page
	Then The newly added 'AS Trolley' Location Type is listed in the search result grid in Location Type List page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Location Types for Refill in Location type list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Location Type List page
	When I click on Add button in Location Type List page
	Then The Location type adding row is displayed on the search result grid in Location Type List page
	And I enter values to the fields in adding row on the search result grid in Location Type List page as follows:
	| FieldName | Value     |
	| Name      | Refill    |
	| Width     | 100       |
	| Depth     | 100       |
	| Height    | 100       |
	| Category  | Refill    |
	| Type      | Transport |

	When I click on Save button in adding row on the search result grid in Location Type List page
	Then The newly added 'Refill' Location Type is listed in the search result grid in Location Type List page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Location Types for PutToLight in Location type list page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Location Type List page
	When I click on Add button in Location Type List page
	Then The Location type adding row is displayed on the search result grid in Location Type List page
	And I enter values to the fields in adding row on the search result grid in Location Type List page as follows:
	| FieldName | Value            |
	| Name      | PutToLight       |
	| Width     | 5                |
	| Depth     | 5                |
	| Height    | 5                |
	| Category  | AutoStoreStation |
	| Type      | PutToLight       |

	When I click on Save button in adding row on the search result grid in Location Type List page
	Then The newly added 'PutToLight' Location Type is listed in the search result grid in Location Type List page