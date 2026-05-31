using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PlaywrightDotNetBDDFramework.Utils;

public static class ExtentReportManager
{
    private static ExtentReports? _extentReports;
    private static ExtentTest? _scenario;

    public static void InitializeReport()
    {
        var reportDirectory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Reports");

        if (!Directory.Exists(reportDirectory))
        {
            Directory.CreateDirectory(reportDirectory);
        }

        var reportPath = Path.Combine(
            reportDirectory,
            "AutomationReport.html");

        var sparkReporter = new ExtentSparkReporter(reportPath);

        _extentReports = new ExtentReports();
        _extentReports.AttachReporter(sparkReporter);

        _extentReports.AddSystemInfo("Project", "Playwright .NET BDD Framework");
        _extentReports.AddSystemInfo("Framework", ".NET 10");
        _extentReports.AddSystemInfo("Automation Tool", "Playwright");
        _extentReports.AddSystemInfo("BDD Tool", "Reqnroll");
    }

    public static void CreateScenario(string scenarioName)
    {
        _scenario = _extentReports!.CreateTest(scenarioName);
    }

    public static void LogPass(string message)
    {
        _scenario!.Pass(message);
    }

    public static void LogFail(string message, string screenshotPath)
    {
        _scenario!.Fail(message)
            .AddScreenCaptureFromPath(screenshotPath);
    }

    public static void FlushReport()
    {
        _extentReports!.Flush();
    }
}