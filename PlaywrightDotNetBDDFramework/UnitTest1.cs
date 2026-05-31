using NUnit.Framework;
using PlaywrightDotNetBDDFramework.Drivers;

namespace PlaywrightDotNetBDDFramework;

public class LoginTests
{
    private PlaywrightDriver _driver = null!;

    [SetUp]
    public async Task Setup()
    {
        _driver = new PlaywrightDriver();
        await _driver.InitializeAsync();
    }

    [Test]
    public async Task ValidUserCanLoginSuccessfully()
    {
        await _driver.Page!.GotoAsync("https://www.saucedemo.com");

        var loginPage = new Pages.LoginPage(_driver.Page);

        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await _driver.Page.WaitForTimeoutAsync(3000);

        var pageTitle = await _driver.Page.TextContentAsync(".title");

        Assert.That(pageTitle, Is.EqualTo("Products"));
    }
    
    [Test]
    public async Task UserCanLoginAndLogout()
    {
        await _driver.Page!.GotoAsync("https://www.saucedemo.com");

        var loginPage = new Pages.LoginPage(_driver.Page);
        var productsPage = new Pages.ProductsPage(_driver.Page);

        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await _driver.Page.WaitForTimeoutAsync(2000);

        await productsPage.LogoutAsync();

        await _driver.Page.WaitForTimeoutAsync(2000);

        Assert.That(
            await _driver.Page.IsVisibleAsync("#login-button"),
            Is.True);
    }
    
    [Test]
    public async Task UserCanAddProductToCart()
    {
        await _driver.Page!.GotoAsync("https://www.saucedemo.com");

        var loginPage = new Pages.LoginPage(_driver.Page);
        var productsPage = new Pages.ProductsPage(_driver.Page);
        var cartPage = new Pages.CartPage(_driver.Page);

        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await productsPage.AddBackpackToCartAsync();

        var cartCount = await productsPage.GetCartBadgeCountAsync();

        Assert.That(cartCount, Is.EqualTo("1"));

        await productsPage.OpenCartAsync();

        var itemName = await cartPage.GetCartItemNameAsync();

        Assert.That(itemName, Is.EqualTo("Sauce Labs Backpack"));
    }
    
    [Test]
    public async Task UserCanCompletePurchaseFlow()
    {
        await _driver.Page!.GotoAsync("https://www.saucedemo.com");

        var loginPage = new Pages.LoginPage(_driver.Page);
        var productsPage = new Pages.ProductsPage(_driver.Page);
        var cartPage = new Pages.CartPage(_driver.Page);
        var checkoutPage = new Pages.CheckoutPage(_driver.Page);

        await loginPage.LoginAsync("standard_user", "secret_sauce");

        await productsPage.AddBackpackToCartAsync();

        await productsPage.OpenCartAsync();

        await cartPage.ClickCheckoutAsync();

        await checkoutPage.EnterCustomerDetailsAsync(
            "Anusha",
            "Kunduru",
            "66212");

        await checkoutPage.CompleteOrderAsync();

        var confirmationMessage =
            await checkoutPage.GetConfirmationMessageAsync();

        Assert.That(
            confirmationMessage,
            Is.EqualTo("Thank you for your order!"));
    }

    [TearDown]
    public async Task TearDown()
    {
        await _driver.DisposeAsync();
    }
}