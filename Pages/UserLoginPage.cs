using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace QA_AccessControl.Pages
{
    public class UserLoginPage
    {
        // Constructor
        private readonly IPage _user;

        public UserLoginPage(Hooks.Hooks hooks)
        {
            _user = hooks.User;
        }

        // Selectors
        private ILocator EmailInput => _user.Locator("input[id='Email']");
        private ILocator PasswordInput => _user.Locator("input[id='Password']");
        private ILocator LoginButton => _user.Locator("button[type='submit']");

        // Actions and Assertions
        public async Task AssertPageContent()
        {
            // Assert that the correct URL has been reached
            await Assertions.Expect(_user).ToHaveURLAsync(new Regex(".*Account/Login"));

            // Assert that the email input is visible
            await Assertions.Expect(EmailInput).ToBeVisibleAsync();

            // Assert that the passowrd input is visible
            await Assertions.Expect(PasswordInput).ToBeVisibleAsync();

            // Assert that the login button is visible
            await Assertions.Expect(LoginButton).ToBeVisibleAsync();
        }

        public async Task EnterCredsAndLogin(string userEmail, string userPassword)
        {
            // Enter the user email
            await EmailInput.TypeAsync(userEmail);

            // Enter the user password
            await PasswordInput.TypeAsync(userPassword);

            // Asser that the inputs have the text entered
            var emailInputInnerText = await EmailInput.InputValueAsync();
            var passwordInputInnerText = await PasswordInput.InputValueAsync();
            emailInputInnerText.Should().Be(userEmail);
            passwordInputInnerText.Should().Be(userPassword);

            // Click the login button
            await LoginButton.ClickAsync();

        }
    }
}
