using Microsoft.Playwright;

namespace PlaywrightDotNetBDDFramework.Pages;

public class CartPage : BasePage
{
    private const string CartItemName = ".inventory_item_name";
    private const string CheckoutButton = "#checkout";

    public CartPage(IPage page) : base(page)
    {
    }

    public async Task<string?> GetCartItemNameAsync()
    {
        return await GetTextAsync(CartItemName);
    }

    public async Task ClickCheckoutAsync()
    {
        await ClickAsync(CheckoutButton);
    }
}