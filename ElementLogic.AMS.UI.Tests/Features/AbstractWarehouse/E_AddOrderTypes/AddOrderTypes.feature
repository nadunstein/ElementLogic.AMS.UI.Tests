Feature: Admin Add Order Types
	As an admin user, I want to verify the scenarios related to Add Order Types

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new order type for Normal Autostore pick in order types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Order Types page
	When I click on Add button in Order Types page
	Then The Add row is displayed in Order Types page
	And I enter values to the fields in adding row in Order Types page as follows:
	| FieldName     | Value     |
	| OrderTypeId   | 25        |
	| OrderTypeText | Normal AS |

	When I click on Save button in Order Types page
	Then The newly added 'Normal AS' order type is listed in Order Types page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new order type for Internet Autostore pick in order types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Order Types page
	When I click on Add button in Order Types page
	Then The Add row is displayed in Order Types page
	And I enter values to the fields in adding row in Order Types page as follows:
	| FieldName     | Value    |
	| OrderTypeId   | 430      |
	| OrderTypeText | Internet |

	When I click on Save button in Order Types page
	Then The newly added 'Internet' order type is listed in Order Types page
	
@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new order type for PrepTaskgroup Autostore pick in order types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Order Types page
	When I click on Add button in Order Types page
	Then The Add row is displayed in Order Types page
	And I enter values to the fields in adding row in Order Types page as follows:
	| FieldName     | Value         |
	| OrderTypeId   | 28            |
	| OrderTypeText | PrepTaskgroup |

	When I click on Save button in Order Types page
	Then The newly added 'PrepTaskgroup' order type is listed in Order Types page
