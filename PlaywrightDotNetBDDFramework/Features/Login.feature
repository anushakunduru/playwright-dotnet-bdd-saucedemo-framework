Feature: Login

  Scenario: Valid user can login successfully
    Given user navigates to SauceDemo login page
    When user logs in with valid credentials
    Then user should see the Products page