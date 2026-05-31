using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using PlaywrightDotNetBDDFramework.Pages;

namespace PlaywrightDotNetBDDFramework.StepDefinitions;

[Binding]
public class CheckoutSteps
{
    private readonly IPage _page;

    public CheckoutSteps(ScenarioContext scenarioContext)
    {
        _page = (IPage)scenarioContext["Page"];
    }

    [When("user proceeds to checkout")]
    public async Task WhenUserProceedsToCheckout()
    {
        var cartPage = new CartPage(_page);

        await cartPage.ClickCheckoutAsync();
    }

    [When("user enters checkout information")]
    public async Task WhenUserEntersCheckoutInformation()
    {
        var checkoutPage = new CheckoutPage(_page);

        await checkoutPage.EnterCustomerDetailsAsync(
            "Anusha",
            "Kunduru",
            "66212");
    }

    [When("user completes the order")]
    public async Task WhenUserCompletesTheOrder()
    {
        var checkoutPage = new CheckoutPage(_page);

        await checkoutPage.CompleteOrderAsync();
    }

    [Then("order confirmation message should be displayed")]
    public async Task ThenOrderConfirmationMessageShouldBeDisplayed()
    {
        var checkoutPage = new CheckoutPage(_page);

        var message =
            await checkoutPage.GetConfirmationMessageAsync();

        Assert.That(
            message,
            Is.EqualTo("Thank you for your order!"));
    }
}