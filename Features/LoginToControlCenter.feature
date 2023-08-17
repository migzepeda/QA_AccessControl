Feature: LoginToControlCenter

Login to the Access Control Center


Scenario: Go to Access Control and Login
	Given the user is on the Access Control Login page
	When the user logs in as an 'Admin'
	Then the user is on the Map page
