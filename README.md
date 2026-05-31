# Playwright .NET BDD SauceDemo Framework

A modern UI automation framework built using Playwright, .NET, NUnit, and Reqnroll BDD following the Page Object Model design pattern.

## Features

* Playwright browser automation
* Reqnroll BDD framework
* NUnit test execution
* Page Object Model (POM)
* JSON-driven test data
* Screenshot capture on failure
* Extent HTML reporting
* GitHub Actions CI/CD integration
* Multi-layer framework structure

## Tech Stack

* C#
* .NET 10
* Playwright
* NUnit
* Reqnroll
* Extent Reports
* GitHub Actions
* Git

## Framework Architecture

Feature Files

↓

Step Definitions

↓

Page Objects

↓

Playwright Driver

↓

Browser

↓

Application Under Test

## Project Structure

PlaywrightDotNetBDDFramework

├── Config

├── Drivers

├── Features

│ ├── Login.feature

│ ├── Cart.feature

│ └── Checkout.feature

├── Hooks

├── Pages

│ ├── LoginPage

│ ├── ProductsPage

│ ├── CartPage

│ └── CheckoutPage

├── StepDefinitions

├── TestData

├── Utils

├── Reports

└── Screenshots

## Automated Scenarios

### Login

* Valid user login

### Cart

* Add product to cart
* Verify cart badge
* Verify cart contents

### Checkout

* Complete purchase flow
* Verify order confirmation

## Reporting

The framework generates Extent HTML reports after execution.

Reports include:

* Test execution status
* Pass / Fail results
* Execution duration
* Failure screenshots

## Continuous Integration

GitHub Actions automatically performs:

* Restore packages
* Build solution
* Install Playwright browsers
* Execute automated tests

on every push to the main branch.

## Running Tests

Run all tests:

dotnet test

Run Playwright browser installation:

powershell playwright.ps1 install

## Author

Anusha Kunduru
