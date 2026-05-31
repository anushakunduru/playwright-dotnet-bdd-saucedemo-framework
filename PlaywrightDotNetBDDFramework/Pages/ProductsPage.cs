using Microsoft.Playwright;

namespace PlaywrightDotNetBDDFramework.Pages;

public class ProductsPage : BasePage
{
    private const string MenuButton = "#react-burger-menu-btn";
    private const string LogoutLink = "#logout_sidebar_link";
    private const string ProductsTitle = ".title";
    private const string BackpackAddToCartButton = "#add-to-cart-sauce-labs-backpack";
    private const string ShoppingCartIcon = ".shopping_cart_link";
    private const string ShoppingCartBadge = ".shopping_cart_badge";

    public ProductsPage(IPage page) : base(page)
    {
    }

    public async Task<string?> GetProductsTitleAsync()
    {
        return await GetTextAsync(ProductsTitle);
    }

    public async Task AddBackpackToCartAsync()
    {
        await ClickAsync(BackpackAddToCartButton);
    }

    public async Task OpenCartAsync()
    {
        await ClickAsync(ShoppingCartIcon);
    }

    public async Task<string?> GetCartBadgeCountAsync()
    {
        return await GetTextAsync(ShoppingCartBadge);
    }

    public async Task LogoutAsync()
    {
        await ClickAsync(MenuButton);
        await ClickAsync(LogoutLink);
    }
}