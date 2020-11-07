Feature: Admin Add AddedInfoRules
	As an admin user, I want to verify the scenarios related to Add AddedInfoRules

@Regression
@WarehouseImplementationTest
Scenario: Adding box types to BoxTypes table
Given I add added info rule to AddedInfoRules table as follows:
| Id | AddedInfoRuleName | ExactQuantity | AddedInfoRegEx |
| 1  | SERIAL            | 1             | ^\d{5}$        |