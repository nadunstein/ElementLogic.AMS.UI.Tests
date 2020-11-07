Feature: Autostore pick Secure Picking
	As an admin user, I want to check the confirm quantity field is displayed in pick mission page 
	if ValidateQuantityAbove field in orderline table has value of '1' for pickorder

@Pick
@Scenario:'1'
@Autostore:Pick:SecurePicking
Scenario: Verify the confirm quantity field is displayed in pick mission page
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Internet' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the confirm quantity field is displayed in Autostore Pick Mission page
	And I verify the focus is on the confirm quantity field in Autostore Pick Mission page
	And I include the pick quantity to confirm quantity field in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the confirm quantity field is displayed in Autostore Pick Mission page
	And I verify the focus is on the confirm quantity field in Autostore Pick Mission page
	And I include the pick quantity to confirm quantity field in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded