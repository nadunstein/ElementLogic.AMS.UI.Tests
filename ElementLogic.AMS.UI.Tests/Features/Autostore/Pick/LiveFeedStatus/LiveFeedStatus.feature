Feature: Autostore Pick Live Feed Status
	As an admin user, I want to verify autostore Pick Live Feed Status related Scenarios

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:LiveFeedStatus
Scenario: Verify the live feed for port and bin when starting a pick taskgroup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I open a new Chrome browser tab
	Given I navigate to Autostore Equipment List page
	When I select the Autostore equipment as 'AS Port 01' in Autostore Equipment List page
	Then The Live feed status page is loaded
	And I verify 'openport' action is listed on Live feed table in Live Feed Status page
	And I verify the 'Request' for 'openport' action with following details on Live feed table in Live Feed Status page:
	| TagName  | Value |
	| port_id  | 1     |
	| category | 5     |

	And I verify 'openbin' action is listed on Live feed table in Live Feed Status page
	And I verify the 'Request' for 'openbin' action with following details on Live feed table in Live Feed Status page:
	| TagName      | Value   |
	| port_id      | 1       |
	| task_id      | 0       |
	| taskgroup_id | 0       |
	| shipment     | 0       |

	When I click on Show/hide responses button in Live Feed Status page
	Then The 'openbin' live feed Response is displayed on Live feed table in Live Feed Status page
	And I verify the 'Response' for 'openbin' action with following details on Live feed table in Live Feed Status page:
	| TagName | Value        |
	| port_id | 1            |
	| bin_id  | Key[bin_id]  |
	| task_id | Key[task_id] |

	And I Switch to the previous Chrome browser tab
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded
	And I Switch to the new Chrome browser tab
	And I verify 'closebin' action is listed on Live feed table in Live Feed Status page
	And I verify the 'Request' for 'closebin' action with following details on Live feed table in Live Feed Status page:
	| TagName      | Value        |
	| port_id      | 1            |
	| bin_id       | Key[bin_id]  |
	| task_id      | Key[task_id] |
	| taskcomplete | true         |
	| content      | 1010         |