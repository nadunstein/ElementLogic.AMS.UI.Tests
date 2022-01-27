Feature: Autostore Pick with External Containers
	As an admin user, I want to verify the scenarios related to Autostore Picking with External Containers

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:ExternalContainer
Scenario: (A)Verify single step picking with one open external container
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'Empty' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The 'Scan value cannot be empty.' Validation message is displayed in Autostore Place in Container page
	And I include the container scan value as 'CO-1234567' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The 'Scanned container ID 'CO-1234567' is not valid' Validation message is displayed in Autostore Place in Container page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	And I add 'Externalbox1' container by clicking on New Container button in Autostore Pick Mission page
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-2345' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'2'
@Autostore:Pick:ExternalContainer
Scenario: (B)Verify two step picking with one open external container
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value as 'CO-1234567' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The 'Scanned container ID 'CO-1234567' is not valid' Validation message is displayed in Autostore Place in Container page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '2' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I add 'Externalbox1' container by clicking on New Container button in Autostore Pick Mission page
	And The successfully added a new container notification is displayed in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page	
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value as 'CO-2345' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'3'
@Autostore:Pick:ExternalContainer
Scenario: (C)Verify the behavior of Add new container popup with External and Internal containers
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	When I click on 'New container' option item in Autostore Pick Mission page
	Then The Add new container popup is displayed in Autostore Pick Mission page
	And I select the boxtype as 'Externalbox1' from container selection list in Add new container popup in Autostore Pick Mission page
	And I verify the scancode field is not displayed in Add new container popup in Autostore Pick Mission page
	When I click on 'Close' button on Add new container popup in Autostore Pick Mission page
	Then The Autostore pick mission '1' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	When I click on 'New container' option item in Autostore Pick Mission page
	Then The Add new container popup is displayed in Autostore Pick Mission page
	And I select the boxtype as 'Externalbox1' from container selection list in Add new container popup in Autostore Pick Mission page
	And I verify the scancode field value is displayed as 'CO-1234' in Add new container popup in Autostore Pick Mission page
	And I include the container scan value as 'CO-12345' to the container scan field in Add new container popup in Autostore Pick Mission page
	When I click on 'Update' button on Add new container popup in Autostore Pick Mission page
	Then The container validation popup is displayed in Add new container popup in AutoStore Pick Mission page
	And I click on OK button in container validation popup in Add new container popup in AutoStore Place in Container page
	And I select the boxtype as 'Externalbox2' from box type selection dropdown in Add new container popup in Autostore Pick Mission page
	And I verify the scancode field value is displayed as 'Empty' in Add new container popup in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Add new container popup in Autostore Pick Mission page
	When I click on 'Update' button on Add new container popup in Autostore Pick Mission page
	Then The container validation popup is displayed in Add new container popup in AutoStore Pick Mission page
	And I click on OK button in container validation popup in Add new container popup in AutoStore Place in Container page
	And I include the container scan value as 'CO-12345' to the container scan field in Add new container popup in Autostore Pick Mission page
	When I click on 'Update' button on Add new container popup in Autostore Pick Mission page	
	Then I select the boxtype as 'Externalbox2' from container selection list in Add new container popup in Autostore Pick Mission page
	Then I verify the scancode field value is displayed as 'CO-12345' in Add new container popup in Autostore Pick Mission page
	When I click on 'Close' button on Add new container popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on 'New container' option item in Autostore Pick Mission page
	Then The Add new container popup is displayed in Autostore Pick Mission page
	And I select the boxtype as 'Box1' from box type selection dropdown in Add new container popup in Autostore Pick Mission page
	When I click on 'Add' button on Add new container popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded	
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on 'New container' option item in Autostore Pick Mission page
	Then The Add new container popup is displayed in Autostore Pick Mission page
	And I select the boxtype as 'Box1' from container selection list in Add new container popup in Autostore Pick Mission page	
	And I select the boxtype as 'Externalbox1' from box type selection dropdown in Add new container popup in Autostore Pick Mission page
	And I verify the scancode field is not displayed in Add new container popup in Autostore Pick Mission page
	When I click on 'Update' button on Add new container popup in Autostore Pick Mission page
	When I click on 'Close' button on Add new container popup in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-2345' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'4'
@Autostore:Pick:ExternalContainer
Scenario: (D)Verify pick place previous mission with External containers
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	When I click on 'Place previous mission' option item in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I change the quantity of the Quantity field as '7' in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Add new container popup is displayed in AutoStore Place in Container page
	And I select the boxtype as 'Externalbox1' from box type selection dropdown in Add new container popup in Autostore Pick Mission page
	When I click on 'Add' button on Add new container popup in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the Quantity field value is '3' in Autostore Place in Container page
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The 'The scanned container 'CO-1234' has already been closed. Cannot scan a closed container' Validation message is displayed in Autostore Place in Container page
	And I include the container scan value as 'CO-1235' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'5'
@Autostore:Pick:ExternalContainer
Scenario: (E)Verify two step picking with two open external containers
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '2' is loaded
	And I add 'Externalbox1' container by clicking on New Container button in Autostore Pick Mission page
	And The successfully added a new container notification is displayed in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value as 'CO-1235' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore pick mission '3' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page	
	When I click on the confirm button in Autostore Pick Mission page
	Then The AutoStore Place in Container page is loaded
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'6'
@Autostore:Pick:ExternalContainer
Scenario: (F)Verify customer batch picking with External containers
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	And I add 'Externalbox1' container by clicking on New Container button in Autostore Pick Mission page
	And The successfully added a new container notification is displayed in Autostore Pick Mission page
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-2345' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'7'
@Autostore:Pick:ExternalContainer
Scenario: (G)Verify product batch picking with External containers
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The 'The scanned container ID 'CO-1234' is already in use' Validation message is displayed in AutoStore Pick Mission page
	And I include the container scan value as 'CO-1235' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1236' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'8'
@Autostore:Pick:ExternalContainer
Scenario: (H)Verify the container scanning is only required once for each order when using PTL and license plate with batch picking
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1234' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '2' is loaded
	And I verify the container scan field is displayed in Autostore Pick Mission page
	And I include the container scan value as 'CO-1235' to the container scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '3' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore pick mission '4' is loaded
	And I verify the container scan field is not displayed in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore task Menu is loaded