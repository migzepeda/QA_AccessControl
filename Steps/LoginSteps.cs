using Microsoft.Playwright;
using QA_AccessControl.Pages;

namespace QA_AccessControl.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IPage _user;
        private readonly LoginPage _loginPage;
        private readonly UserLoginPage _userLoginPage;

        public LoginSteps(Hooks.Hooks hooks, LoginPage loginPage, UserLoginPage userLoginPage)
        {
            _user = hooks.User;
            _loginPage = loginPage;
            _userLoginPage = userLoginPage;
        }

        [Given(@"the user is on the Access Control Login page")]
        public async Task GivenTheUserIsOnTheAccessControlLoginPage()
        {
            // Go to the login page
            await _user.GotoAsync("https://portal.cia-qa-1.aws.insomniaccia.com/auth/login");

            // Assert the page
            await _loginPage.AssertPageContent();
        }

        [When(@"the user logs in as an '(.*)'")]
        public async Task WhenTheUserLogsInAsAnAdmin(string userType)
        {
            // Click the login button
            await _loginPage.ClickLoginButton();

            // Assert the page
            await _userLoginPage.AssertPageContent();

            // Enter login credentials
            switch(userType)
            {
                case "Admin":
                    await _userLoginPage.EnterCredsAndLogin("cia.ota.qa+auto_system_admin@gmail.com", "Auto#M8!");
                    break;
            }
        }


    }
}
