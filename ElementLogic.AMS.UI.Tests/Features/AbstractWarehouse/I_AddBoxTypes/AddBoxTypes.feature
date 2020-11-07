Feature: Admin Add Box Types
	As an admin user, I want to verify the scenarios related to Add Box Types

@Regression
@WarehouseImplementationTest
Scenario: Adding box types to BoxTypes table
Given I add box types to BoxTypes table as follows:
| BoxTypeName  | IsExternalContainer | ExternalContainerRegEx |
| Box1         | 0                   | null                   |
| Box2         | 0                   | null                   |
| Externalbox1 | 1                   | CO-[0-9]{4}\b          |