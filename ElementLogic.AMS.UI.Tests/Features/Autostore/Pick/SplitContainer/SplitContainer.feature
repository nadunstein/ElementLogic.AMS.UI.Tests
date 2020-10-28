Feature: Autostore Pick Split Container
	As an admin user, I want to Verify Split Container related Scenarios

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:SplitContainer
Scenario: Verify the container can be split for a PickOrder when the taskgroup has a single mission
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the Quantity field value is '7' in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I change the quantity of the Quantity field as '5' in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Add new container popup is displayed in AutoStore Place in Container page
	When I click on 'Add' button on Add new container popup in AutoStore Place in Container page
	Then The AutoStore Place in Container page is loaded
	And I verify the Quantity field value is '2' in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu is displayed