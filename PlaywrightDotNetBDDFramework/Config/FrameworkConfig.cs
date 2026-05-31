namespace PlaywrightDotNetBDDFramework.Config;

public static class FrameworkConfig
{
    public static string BaseUrl => "https://www.saucedemo.com";

    public static bool Headless => false;

    public static int DefaultTimeout => 30000;

    public static string Browser => "chromium";
}