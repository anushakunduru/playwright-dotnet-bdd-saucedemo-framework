using Microsoft.Playwright;
using PlaywrightDotNetBDDFramework.Config;

namespace PlaywrightDotNetBDDFramework.Drivers;

public class PlaywrightDriver
{
    public IPlaywright? Playwright { get; private set; }
    public IBrowser? Browser { get; private set; }
    public IBrowserContext? Context { get; private set; }
    public IPage? Page { get; private set; }

    public async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = FrameworkConfig.Headless,
            SlowMo = 300
        });

        Context = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new ViewportSize
            {
                Width = 1366,
                Height = 768
            }
        });

        Page = await Context.NewPageAsync();
        Page.SetDefaultTimeout(FrameworkConfig.DefaultTimeout);
    }

    public async Task DisposeAsync()
    {
        if (Context != null)
            await Context.CloseAsync();

        if (Browser != null)
            await Browser.CloseAsync();

        Playwright?.Dispose();
    }
}