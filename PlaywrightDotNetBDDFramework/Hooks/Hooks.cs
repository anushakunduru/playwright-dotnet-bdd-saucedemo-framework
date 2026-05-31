using Reqnroll;
using PlaywrightDotNetBDDFramework.Drivers;

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

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        _driver = new PlaywrightDriver();
        await _driver.InitializeAsync();

        _scenarioContext["Page"] = _driver.Page!;
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        await _driver.DisposeAsync();
    }
}