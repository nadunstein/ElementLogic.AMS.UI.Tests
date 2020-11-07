Feature: Autostore Pick TaskGroups Preparation
	As an admin user, I want to Verify TaskGroups Preparation in autostore picking

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:TaskGroupsPreparation
Scenario: Verify Autostore taskgroup preparation when prepared taskgroup count goes below the minimum value
	Given I login to the Autostore port '01' as 'Admin' user
	Then I verify the prepared taskgroup count is '5' for 'PrepTaskgroup' pick task type in AutoStore Main Menu
	When I click on 'PrepTaskgroup' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The taskgroup completed popup is displayed in Autostore Pick Mission page
	When I click on 'Continue' button on taskgroup completed popup in Autostore Pick Mission page
	Then The new order popup is displayed in Autostore Pick Mission page
	When I click OK button on new order popup in Autostore Pick Mission page
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The taskgroup completed popup is displayed in Autostore Pick Mission page
	When I click on 'Exit' button on taskgroup completed popup in Autostore Pick Mission page
	Then The Autostore task Menu is loaded
	When I click on 'PrepTaskgroup' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	When I click on Exit button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded
	Then I verify the prepared taskgroup count is '5' for 'PrepTaskgroup' pick task type in AutoStore Main Menu