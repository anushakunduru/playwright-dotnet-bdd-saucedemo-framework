using Microsoft.Playwright;

namespace PlaywrightDotNetBDDFramework.Pages;

public class CheckoutPage : BasePage
{
    private const string FirstNameTextbox = "#first-name";
    private const string LastNameTextbox = "#last-name";
    private const string PostalCodeTextbox = "#postal-code";
    private const string ContinueButton = "#continue";
    private const string FinishButton = "#finish";
    private const string ConfirmationMessage = ".complete-header";

    public CheckoutPage(IPage page) : base(page)
    {
    }

    public async Task EnterCustomerDetailsAsync(string firstName, string lastName, string postalCode)
    {
        await EnterTextAsync(FirstNameTextbox, firstName);
        await EnterTextAsync(LastNameTextbox, lastName);
        await EnterTextAsync(PostalCodeTextbox, postalCode);
        await ClickAsync(ContinueButton);
    }

    public async Task CompleteOrderAsync()
    {
        await ClickAsync(FinishButton);
    }

    public async Task<string?> GetConfirmationMessageAsync()
    {
        return await GetTextAsync(ConfirmationMessage);
    }
}