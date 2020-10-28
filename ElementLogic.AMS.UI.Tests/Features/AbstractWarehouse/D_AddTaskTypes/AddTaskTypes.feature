Feature: Admin Add TaskTypes
	As an admin user, I want to verify the scenarios related to Add TaskTypes

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Task Types for Normal Autostore Pick in Task types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Task Types page
	When I click on Add button in Task Types List page
	Then The Edit task page is loaded
	And I enter values to the fields in adding row on the search result grid in Edit task page as follows:
	| FieldName        | Value     |
	| Code             | 1         |
	| Name             | Normal AS |
	| Priority         | 1         |
	| Min Queue Length | 40        |
	| Max Queue Length | 400       |
	| Sequence         | 1         |
	| Shipment         | 1         |
	| Activity Type    | Picking   |

	When I click on Save button in Edit task page
	Then The Task types page is loaded
	And The newly added 'Normal AS' Task Type is listed in the search result grid in Task Type List page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Task Types for Internet Autostore Pick in Task types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Task Types page
	When I click on Add button in Task Types List page
	Then The Edit task page is loaded
	And I enter values to the fields in adding row on the search result grid in Edit task page as follows:
	| FieldName        | Value                                                                      |
	| Code             | 2                                                                          |
	| Name             | Internet                                                                   |
	| Priority         | 1                                                                          |
	| Min Queue Length | 40                                                                         |
	| Max Queue Length | 400                                                                        |
	| SQL              | select extpicklistid from orders where extpicklistid=? and ordertypeid=430 |
	| Sequence         | 2                                                                          |
	| Shipment         | 2                                                                          |
	| Activity Type    | Picking                                                                    |

	When I click on Save button in Edit task page
	Then The Task types page is loaded
	And The newly added 'Internet' Task Type is listed in the search result grid in Task Type List page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Task Types for Small Order Autostore Pick in Task types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Task Types page
	When I click on Add button in Task Types List page
	Then The Edit task page is loaded
	And I enter values to the fields in adding row on the search result grid in Edit task page as follows:
	| FieldName        | Value                                                                     |
	| Code             | 3                                                                         |
	| Name             | Small Order                                                               |
	| Priority         | 1                                                                         |
	| Min Queue Length | 40                                                                        |
	| Max Queue Length | 400                                                                       |
	| SQL              | select extpicklistid from orders where extpicklistid=? and ordertypeid=27 |
	| Sequence         | 3                                                                         |
	| Shipment         | 3                                                                         |
	| Activity Type    | Picking                                                                   |

	When I click on Save button in Edit task page
	Then The Task types page is loaded
	And The newly added 'Internet' Task Type is listed in the search result grid in Task Type List page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a new Task Types for PrepTaskgroup Autostore Pick in Task types page
	Given I login to the AdminModule as 'Admin' user
	And I navigate to Task Types page
	When I click on Add button in Task Types List page
	Then The Edit task page is loaded
	And I enter values to the fields in adding row on the search result grid in Edit task page as follows:
	| FieldName        | Value                                                                     |
	| Code             | 4                                                                         |
	| Name             | PrepTaskgroup                                                             |
	| Priority         | 1                                                                         |
	| Min Queue Length | 3                                                                         |
	| Max Queue Length | 5                                                                         |
	| SQL              | select extpicklistid from orders where extpicklistid=? and ordertypeid=28 |
	| Sequence         | 1                                                                         |
	| Shipment         | 4                                                                         |
	| Activity Type    | Picking                                                                   |

	When I click on Save button in Edit task page
	Then The Task types page is loaded
	And The newly added 'PrepTaskgroup' Task Type is listed in the search result grid in Task Type List page