using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using PlaywrightDotNetBDDFramework.Pages;

namespace PlaywrightDotNetBDDFramework.StepDefinitions;

[Binding]
public class CartSteps
{
    private readonly IPage _page;

    public CartSteps(ScenarioContext scenarioContext)
    {
        _page = (IPage)scenarioContext["Page"];
    }

    [When("user adds Sauce Labs Backpack to the cart")]
    public async Task WhenUserAddsSauceLabsBackpackToTheCart()
    {
        var productsPage = new ProductsPage(_page);

        await productsPage.AddBackpackToCartAsync();
    }

    [Then("cart badge should show 1 item")]
    public async Task ThenCartBadgeShouldShow1Item()
    {
        var productsPage = new ProductsPage(_page);

        var count = await productsPage.GetCartBadgeCountAsync();

        Assert.That(count, Is.EqualTo("1"));
    }

    [When("user opens the shopping cart")]
    public async Task WhenUserOpensTheShoppingCart()
    {
        var productsPage = new ProductsPage(_page);

        await productsPage.OpenCartAsync();
    }

    [Then("Sauce Labs Backpack should be displayed in the cart")]
    public async Task ThenSauceLabsBackpackShouldBeDisplayedInTheCart()
    {
        var cartPage = new CartPage(_page);

        var itemName = await cartPage.GetCartItemNameAsync();

        Assert.That(itemName, Is.EqualTo("Sauce Labs Backpack"));
    }
}