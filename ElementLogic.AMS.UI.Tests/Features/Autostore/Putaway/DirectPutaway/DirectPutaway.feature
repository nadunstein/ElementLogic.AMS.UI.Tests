Feature: Autostore Putaway Direct Putaway
	As an Admin user, I want to verify the AutoStore Direct Putaway related scenarios

Background: 
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'A 1/1 AutoStore Bin' putaway tile in AutoStore Main Menu
	Then I Navigate to Autostore Putaway Selection page
    And I Select the search on as 'Order line' in Autostore Putaway Selection page
	And I Include Product Id as 'ASDPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page

@Regression
@Scenario:'1'
@Autostore:Putaway:DirectPutaway
Scenario: Autostore Direct Putaway to single compartment bins
	Given I Select the search on as 'Mission ID' in Autostore Putaway Selection page
	Then I Include Product Id as 'ASDPP01' to the Scan field in Autostore Putaway Selection page
	When I click Enter button in Autostore Putaway Selection page
	Then The putaway quantity confirm popup is displayed
    And I enter putaway quantity value as '16' in Autostore putaway quantity confirm popup
	And I Include max location quantity value as '10' in Autostore putaway quantity confirm popup
	When I click on Confirm button in Autostore putaway quantity confirm popup
	Then The Autostore putaway mission '1' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then The Autostore putaway mission '2' is loaded
	And The putaway order information is loaded in the Autostore putaway mission page
	When I click on Confirm button in Autostore putaway mission page
	Then I Navigate to Autostore Putaway Selection page