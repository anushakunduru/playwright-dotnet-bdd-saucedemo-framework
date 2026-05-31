using Microsoft.Playwright;

namespace PlaywrightDotNetBDDFramework.Pages;

public class LoginPage : BasePage
{
    private const string UsernameTextbox = "#user-name";
    private const string PasswordTextbox = "#password";
    private const string LoginButton = "#login-button";

    public LoginPage(IPage page) : base(page)
    {
    }

    public async Task LoginAsync(string username, string password)
    {
        await EnterTextAsync(UsernameTextbox, username);
        await EnterTextAsync(PasswordTextbox, password);
        await ClickAsync(LoginButton);
    }
}