Feature: Autostore Putaway with Multiple Users
	As an Admin user, I want to verify the AutoStore Putaway order behavior with multiple users

@Regression	
@Scenario:'1'
@Autostore:Putaway:MultipleUserPutaway
Scenario: Verify a putaway order can be continued with two users
	Given I login to the Autostore port '04' as 'UserThree' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
    And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPMUP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on enter button after include max location quantity in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	When I click enter button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	When I click enter button in Autostore putaway mission page
	Then The Autostore putaway mission '3' is loaded
	When I click on Exit button in Autostore Putaway Mission page
	Then The Delete Incomplete Tasks popup is loaded in Autostore Putaway Mission page
    And I click Yes button in Delete Incomplete Tasks popup 
	Then I Navigate to Autostore Putaway Selection page
	And I click on Exit button in Autostore Putaway Selection page
	Then The Autostore task Menu is loaded
	When I click on Logout button in Autostore task menu
	Then The Autostore login page is loaded
	Given I login to the Autostore port '04' as 'UserFour' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
    And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASPMUP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And The quantity field value should be '30' in Autostore putaway quantity confirm popup
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on enter button after include max location quantity in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	When I click enter button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	When I click enter button in Autostore putaway mission page
	Then The Autostore putaway mission '3' is loaded
	When I click enter button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page
	And I click on Exit button in Autostore Putaway Selection page
	Then The Autostore task Menu is loaded
	When I click on Logout button in Autostore task menu
	Then The Autostore login page is loaded
