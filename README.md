# Playwright .NET Automation Framework

## Overview

A scalable UI test automation framework built using Playwright, C#, .NET 10, NUnit, and the Page Object Model (POM) design pattern. The framework automates end-to-end e-commerce workflows and demonstrates modern automation engineering practices including reusable page objects, configuration management, test data separation, and browser lifecycle management.

## Technology Stack

- C#
- .NET 10
- Playwright
- NUnit
- Page Object Model (POM)
- Git
- GitHub
- JSON Test Data

## Framework Features

- Reusable Page Object Model architecture
- Centralized browser management
- Externalized test data using JSON
- Configurable framework settings
- End-to-end workflow automation
- Cross-browser testing support (future enhancement)
- CI/CD integration ready

## Automated Test Scenarios

### Authentication

- Valid User Login
- User Logout

### Shopping Cart

- Add Product To Cart
- Verify Cart Contents

### Checkout

- Complete Purchase Flow
- Order Confirmation Validation

## Project Structure

```text
Config/
Drivers/
Pages/
TestData/
Utils/
Reports/
Screenshots/
```

## Test Execution

```bash
dotnet test
```

## Application Under Test

https://www.saucedemo.com

## Future Enhancements

- BDD Implementation using Reqnroll
- GitHub Actions CI/CD Pipeline
- HTML Reporting
- Screenshot Capture on Failure
- Parallel Execution
- Multi-Browser Execution
- Environment Configuration Support