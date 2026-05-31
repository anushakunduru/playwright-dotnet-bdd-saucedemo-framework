using Microsoft.Playwright;

namespace PlaywrightDotNetBDDFramework.Utils;

public static class ScreenshotHelper
{
    public static async Task<string> CaptureScreenshotAsync(IPage page, string scenarioName)
    {
        var screenshotsDirectory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Screenshots");

        if (!Directory.Exists(screenshotsDirectory))
        {
            Directory.CreateDirectory(screenshotsDirectory);
        }

        var cleanScenarioName = scenarioName
            .Replace(" ", "_")
            .Replace(":", "")
            .Replace("/", "_")
            .Replace("\\", "_");

        var fileName = $"{cleanScenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

        var screenshotPath = Path.Combine(screenshotsDirectory, fileName);

        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = screenshotPath,
            FullPage = true
        });

        return screenshotPath;
    }
}