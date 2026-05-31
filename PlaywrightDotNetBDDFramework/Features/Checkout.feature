Feature: Checkout

Scenario: User can complete purchase successfully
    Given user navigates to SauceDemo login page
    When user logs in with valid credentials
    And user adds Sauce Labs Backpack to the cart
    And user opens the shopping cart
    And user proceeds to checkout
    And user enters checkout information
    And user completes the order
    Then order confirmation message should be displayed