using Microsoft.Playwright;
using Reqnroll;
using NUnit.Framework;
using PlaywrightDotNetBDDFramework.Pages;

namespace PlaywrightDotNetBDDFramework.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IPage _page;

    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _page = (IPage)_scenarioContext["Page"];
    }

    [Given("user navigates to SauceDemo login page")]
    public async Task GivenUserNavigatesToSauceDemoLoginPage()
    {
        await _page.GotoAsync("https://www.saucedemo.com");
    }

    [When("user logs in with valid credentials")]
    public async Task WhenUserLogsInWithValidCredentials()
    {
        var loginPage = new LoginPage(_page);

        await loginPage.LoginAsync(
            "standard_user",
            "secret_sauce");
    }

    [Then("user should see the Products page")]
    public async Task ThenUserShouldSeeTheProductsPage()
    {
        var title =
            await _page.TextContentAsync(".title");

        Assert.That(title, Is.EqualTo("Products"));
    }
}