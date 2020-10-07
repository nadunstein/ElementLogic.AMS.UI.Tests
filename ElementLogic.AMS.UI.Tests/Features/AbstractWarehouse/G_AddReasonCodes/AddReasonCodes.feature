Feature: Admin Add Reason Codes
	As an admin user, I want to verify the scenarios related to Add Reason Codes

@Regression
@WarehouseImplementationTest
Scenario: Adding Reason codes to REASONCODE table
Given I add reason codes to REASONCODE table as follows:
| ReasonCodeID | ReasonText                            | UpdateCode |
| 1000         | Manual Adjustment                     | 75         |
| 1002         | Inventory                             | 70         |
| 1003         | breakage                              | 75         |
| 1004         | External Balance Correction           | 51         |
| 1005         | Adjustment For Wrong Price            | 75         |
| 1010         | Adjustment Submitted Incorrect Number | 75         |