Feature: Shopping Cart

Scenario: User can add a product to the cart
    Given user navigates to SauceDemo login page
    When user logs in with valid credentials
    And user adds Sauce Labs Backpack to the cart
    Then cart badge should show 1 item
    When user opens the shopping cart
    Then Sauce Labs Backpack should be displayed in the cart