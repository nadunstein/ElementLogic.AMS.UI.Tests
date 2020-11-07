Feature: Autostore Putaway with Multiple Ports
	As a user, I want to verify that I can parallelly putaway same orderline which,
	is already started by another user from a different port

@Regression
@Scenario:'1'
@OpenBrowser_Browser01
@Autostore:Putaway:MultiplePortPutaway
Scenario: (A) Putaway partial quantity from an orderline
	Given I login to the Autostore port '02' as 'UserOne' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'PMPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I enter putaway quantity value as '10' in Autostore putaway quantity confirm popup
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on enter button after include max location quantity in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded

@Regression
@OpenBrowser_Browser02
Scenario: (B) Continue scenario "Putaway partial quantity from an orderline" from a different user in another port
	Given I login to the Autostore port '03' as 'UserTwo' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
	And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'PMPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on enter button after include max location quantity in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	When I click enter button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page
	And I click on Exit button in Autostore Putaway Selection page
	Then The Autostore task Menu is loaded
	When I click on Logout button in Autostore task menu
	Then The Autostore login page is loaded