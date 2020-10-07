Feature: Autostore pick Two Steps On Last Mission
	As an admin user, I want to Verify Autostore pick with TwoStep On Last Mission related Scenarios

@Pick
@AS_Pick_TwoStepsOnLastMission
Scenario: Verify pick place page is loading for the last mission of the pick taskgroup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu should be loaded