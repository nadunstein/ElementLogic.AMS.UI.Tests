Feature: Autostore Multiple Ports Simultaneous Login
	 As an admin user, I want to verify the scenarios related to Autostore Multiple Ports Simultaneous Login

@Regression
Scenario: Verify user can be logged in to Autostore with multiple ports simultaneously
	Given I login to the Autostore port '03' as 'UserTwo' user
	Then The Autostore task Menu is loaded
	Given I login to the Autostore port '04' as 'UserTwo' user
	Then The Duplicate login confirmation popup is displayed in Autostore Task Menu Page
	When I click on 'Yes' button on Duplicate login confirmation popup in Autostore Task Menu Page
	Then The Autostore task Menu is loaded
	When I click on Logout button in Autostore task menu
	Then The Autostore login page is loaded
	