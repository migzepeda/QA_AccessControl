using Microsoft.Playwright;

namespace QA_AccessControl.Pages
{
    public class LoginPage
    {
        // Constructor
        private readonly IPage _user;

        public LoginPage(Hooks.Hooks hooks)
        {
            _user = hooks.User;
        }

        // Selectors
        private ILocator LoginButton => _user.Locator("button[type='button']");

        // Actions and Assertions
        public async Task AssertPageContent()
        {
            // Assert that the correct URL has been reached
            await Assertions.Expect(_user).ToHaveURLAsync("https://portal.cia-qa-1.aws.insomniaccia.com/auth/login");

            // Assert that the login button is visible
            await Assertions.Expect(LoginButton).ToBeVisibleAsync();
        }

        public async Task ClickLoginButton()
        {
            // Click the login button
            await LoginButton.ClickAsync();
        }
    }
}
