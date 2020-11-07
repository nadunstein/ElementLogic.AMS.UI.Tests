Feature: Autostore Pick SerialNumber Registration
	As an admin user, I want to verify the scenarios related to Autostore Picking SerialNumber Registration

@Pick
@Regression
@Scenario:'1'
@Autostore:Pick:SerialNumberRegistration
Scenario: Verify the serial number registration with single step picking
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (1 of 2)' in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page	
	Then The 'The scanned serial number is empty or too long' validation Popup is displayed in Autostore Serial Number Registration page
	When I click on OK button in Serial Number Validation Popup in Autostore Serial Number Registration page
	Then The Autostore Serial Number Registration page is loaded
	And I include the serial number scan value as '123' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page	
	Then The 'The scanned serial number does not have the correct format' validation Popup is displayed in Autostore Serial Number Registration page
	When I click on OK button in Serial Number Validation Popup in Autostore Serial Number Registration page
	Then The Autostore Serial Number Registration page is loaded
	And I include the serial number scan value as '12345' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Edit Previous Autostore Serial Number Registration page is loaded
	And I update the previously scanned serial number as '123' in Autostore Serial Number Registration page
	When I click on Update button in Autostore Serial Number Registration page
	Then The 'The scanned serial number does not have the correct format' validation Popup is displayed in Autostore Serial Number Registration page
	When I click on OK button in Serial Number Validation Popup in Autostore Serial Number Registration page
	Then The Autostore Serial Number Registration page is loaded
	And I update the previously scanned serial number as '12346' in Autostore Serial Number Registration page
	When I click on Update button in Autostore Serial Number Registration page
	Then The successfully updated serial number notification is displayed in Autostore Serial Number Registration page
	And I update the previously scanned serial number as '12345' in Autostore Serial Number Registration page
	When I click on Update button in Autostore Serial Number Registration page
	Then The successfully updated serial number notification is displayed in Autostore Serial Number Registration page
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (2 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12345' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The 'Serial number "12345" is already registered' validation Popup is displayed in Autostore Serial Number Registration page
	When I click on OK button in Serial Number Validation Popup in Autostore Serial Number Registration page
	Then The Edit Previous Autostore Serial Number Registration page is loaded
	And I include the serial number scan value as '12346' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Edit last Autostore Serial Number Registration page is loaded
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'2'
@Autostore:Pick:SerialNumberRegistration
Scenario: Verify the serial number registration with two step picking and one open container
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (1 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12348' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Edit Previous Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (2 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12349' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Edit last Autostore Serial Number Registration page is loaded
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The AutoStore Place in Container page is loaded
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'3'
@Autostore:Pick:SerialNumberRegistration
Scenario: Verify the serial number registration with two step picking and two open containers
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore pick mission '1' is loaded
	And I add 'Box1' container by clicking on New Container button in Autostore Pick Mission page
	Then The successfully added a new container notification is displayed in Autostore Pick Mission page
	And I include the product scan value to scan field in Autostore Pick Mission page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (1 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12350' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The AutoStore Place in Container page is loaded
	And I verify the Quantity field value is '1' in Autostore Place in Container page
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Edit Previous Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (2 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12351' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Edit last Autostore Serial Number Registration page is loaded
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The AutoStore Place in Container page is loaded
	And I verify the Quantity field value is '1' in Autostore Place in Container page
	And I verify the scan field is displayed in AutoStore Place in Container page
	And I include the container scan value to scan value field in AutoStore Place in Container page
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu is loaded

@Pick
@Regression
@Scenario:'4'
@Autostore:Pick:SerialNumberRegistration
Scenario: Verify the serial number registration without product scanning
	Given I login to the Autostore port '01' as 'Admin' user
	When I click on 'Normal AS' pick task type in AutoStore Main Menu
	Then The Autostore Serial Number Registration page is loaded
	And I verify the quantity field is displayed in Autostore Serial Number Registration page is loaded
	And I verify the autostore bin layout is displayed in Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (1 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12352' to serial number scan field in Autostore Serial Number Registration page
	When I click on the confirm button in Autostore Pick Mission page
	Then The Edit Previous Autostore Serial Number Registration page is loaded
	And I verify the name of the serial number scan field is displayed as 'Scan SERIAL (2 of 2)' in Autostore Serial Number Registration page
	And I include the serial number scan value as '12353' to serial number scan field in Autostore Serial Number Registration page
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The Edit last Autostore Serial Number Registration page is loaded
	When I click on the Confirm button in Autostore Serial Number Registration page
	Then The AutoStore Place in Container page is loaded
	When I click on the Confirm button in AutoStore Place in Container page
	Then The Autostore task Menu is loaded