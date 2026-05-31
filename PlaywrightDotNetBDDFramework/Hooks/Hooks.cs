using Reqnroll;
using PlaywrightDotNetBDDFramework.Drivers;
using PlaywrightDotNetBDDFramework.Utils;

namespace PlaywrightDotNetBDDFramework.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private PlaywrightDriver _driver = null!;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ExtentReportManager.InitializeReport();
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        _driver = new PlaywrightDriver();
        await _driver.InitializeAsync();

        _scenarioContext["Page"] = _driver.Page!;

        ExtentReportManager.CreateScenario(
            _scenarioContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        if (_scenarioContext.TestError != null)
        {
            var screenshotPath =
                await ScreenshotHelper.CaptureScreenshotAsync(
                    _driver.Page!,
                    _scenarioContext.ScenarioInfo.Title);

            ExtentReportManager.LogFail(
                _scenarioContext.TestError.Message,
                screenshotPath);
        }
        else
        {
            ExtentReportManager.LogPass("Scenario passed successfully");
        }

        await _driver.DisposeAsync();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        ExtentReportManager.FlushReport();
    }
}