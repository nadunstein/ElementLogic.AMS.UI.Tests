Feature: Admin Add Users
	As an admin user, I want to verify the scenarios related to Add Users

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a User One in User list page
Given I login to the AdminModule as 'Admin' user
And I navigate to User list page
When I click on Add button in User list page
Then Add/Edit user page is loaded
And I enter values to the fields in Add/Edit User page as follows:
	| FieldName        | Value   |
	| Username         | UserOne |
	| First name       | User    |
	| Last name        | One     |
	| Password         | 2040    |
	| Confirm password | 2040    |
	| Activate         | true    |

Then I click on Save button in Add/Edit user page
When I click on Cancel button in Add/Edit user page
Then User list page is loaded
And The newly added 'UserOne' User is listed in the search result grid in User list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a User Two in User list page
Given I login to the AdminModule as 'Admin' user
And I navigate to User list page
When I click on Add button in User list page
Then Add/Edit user page is loaded
And I enter values to the fields in Add/Edit User page as follows:
	| FieldName        | Value   |
	| Username         | UserTwo |
	| First name       | User    |
	| Last name        | Two     |
	| Password         | 2040    |
	| Confirm password | 2040    |
	| Activate         | true    |

Then I click on Save button in Add/Edit user page
When I click on Cancel button in Add/Edit user page
Then User list page is loaded
And The newly added 'UserTwo' User is listed in the search result grid in User list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a User Three in User list page
Given I login to the AdminModule as 'Admin' user
And I navigate to User list page
When I click on Add button in User list page
Then Add/Edit user page is loaded
And I enter values to the fields in Add/Edit User page as follows:
	| FieldName        | Value     |
	| Username         | UserThree |
	| First name       | User      |
	| Last name        | Three     |
	| Password         | 2040      |
	| Confirm password | 2040      |
	| Activate         | true      |

Then I click on Save button in Add/Edit user page
When I click on Cancel button in Add/Edit user page
Then User list page is loaded
And The newly added 'UserThree' User is listed in the search result grid in User list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a User Four in User list page
Given I login to the AdminModule as 'Admin' user
And I navigate to User list page
When I click on Add button in User list page
Then Add/Edit user page is loaded
And I enter values to the fields in Add/Edit User page as follows:
	| FieldName        | Value    |
	| Username         | UserFour |
	| First name       | User     |
	| Last name        | Four     |
	| Password         | 2040     |
	| Confirm password | 2040     |
	| Activate         | true     |

Then I click on Save button in Add/Edit user page
When I click on Cancel button in Add/Edit user page
Then User list page is loaded
And The newly added 'UserFour' User is listed in the search result grid in User list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a User Five in User list page
Given I login to the AdminModule as 'Admin' user
And I navigate to User list page
When I click on Add button in User list page
Then Add/Edit user page is loaded
And I enter values to the fields in Add/Edit User page as follows:
	| FieldName        | Value    |
	| Username         | UserFive |
	| First name       | User     |
	| Last name        | Five     |
	| Password         | 2040     |
	| Confirm password | 2040     |
	| Activate         | true     |

Then I click on Save button in Add/Edit user page
When I click on Cancel button in Add/Edit user page
Then User list page is loaded
And The newly added 'UserFive' User is listed in the search result grid in User list page

@Regression
@RunTestsInline
@WarehouseImplementationTest
Scenario: Adding a User Six in User list page
Given I login to the AdminModule as 'Admin' user
And I navigate to User list page
When I click on Add button in User list page
Then Add/Edit user page is loaded
And I enter values to the fields in Add/Edit User page as follows:
	| FieldName        | Value   |
	| Username         | UserSix |
	| First name       | User    |
	| Last name        | Six     |
	| Password         | 2040    |
	| Confirm password | 2040    |
	| Activate         | true    |

Then I click on Save button in Add/Edit user page
When I click on Cancel button in Add/Edit user page
Then User list page is loaded
And The newly added 'UserSix' User is listed in the search result grid in User list page