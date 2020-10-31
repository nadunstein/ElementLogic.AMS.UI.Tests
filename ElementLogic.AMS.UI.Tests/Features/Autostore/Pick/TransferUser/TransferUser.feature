Feature: Autostore Pick Transfer User
	As an admin user, I want to verify Transferring Users for autostore pick orders related Scenarios

@Pick
@Scenario:'1'
@Autostore:Pick:TransferUser
Scenario: Verify Pick Order in AssignedUser state can be transferred To a different user
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	When I click on Exit button in Autostore Pick Mission page
	Then The Confirm Task Exit popup is displayed in Autostore Pick Mission page
	When I click on 'Yes' button on Confirm Task Exit popup in Autostore Pick Mission page
	Then The Autostore task Menu is displayed
	Given I navigate to User Activity page
	Then The User Activity page is loaded
	And I include Taskgroup id to the Task group ID field in User Activity page
	When I click on Search button in User Activity page
	Then The user activity is displayed in the search grid in User Activity page
	When I click on 'Transfer user' option by selecting the gear icon of the activity in User Activity page
	Then The Transfer User popup is displayed in User Activity Page
	And I select transfer user as 'NormalUser' from Transfer user dropdown in Transfer User popup in User Activity Page
	When I click on 'Confirm' button in Transfer User popup in User Activity Page
	Then I verify the UserCode of the activity is displayed as 'NormalUser' in User Activity page