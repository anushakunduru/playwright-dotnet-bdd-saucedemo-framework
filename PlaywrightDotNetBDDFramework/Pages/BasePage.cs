using Microsoft.Playwright;

namespace PlaywrightDotNetBDDFramework.Pages;

public class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }

    public async Task ClickAsync(string locator)
    {
        await Page.ClickAsync(locator);
    }

    public async Task EnterTextAsync(string locator, string text)
    {
        await Page.FillAsync(locator, text);
    }

    public async Task<string?> GetTextAsync(string locator)
    {
        return await Page.TextContentAsync(locator);
    }

    public async Task WaitForElementAsync(string locator)
    {
        await Page.WaitForSelectorAsync(locator);
    }

    public async Task<bool> IsVisibleAsync(string locator)
    {
        return await Page.IsVisibleAsync(locator);
    }
}