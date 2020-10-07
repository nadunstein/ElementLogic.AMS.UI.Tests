Feature: Autostore Pick Max Quantity Popup
	As an admin user, I want to verify Autostore Pick Max Quantity Popup related Scenarios

@Pick
@AS_Pick_MaxQuantityPopup
Scenario: Verify the button focus of the input control popup
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Zero Quantity confirmation popup is displayed in Autostore Pick Mission page
	When I click on 'No' button on Zero Quantity confirmation popup in Autostore Pick Mission page
	Then The Confirm Quantity popup is displayed in Autostore Pick Mission page
	And I include the Quantity as '10005' to the quantity field on Confirm Quantity popup in Autostore Pick Mission page
	When I click on the Confirm button on Confirm Quantity popup in Autostore Pick Mission page
	Then The Changed confirm quantity popup is displayed in Autostore Pick Mission page
	And I check the focus is on No button on Changed confirm quantity popup in Autostore Pick Mission page