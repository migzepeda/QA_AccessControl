using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace QA_AccessControl.Pages
{
    public class MapPage
    {
        // Constructors
        private readonly IPage _user;

        public MapPage(Hooks.Hooks hooks)
        {
            _user = hooks.User;
        }

        // Selectors ?

        // Actions and Assertions
        public async Task AssertPageContent()
        {
            // Wait for page load
            await _user.WaitForLoadStateAsync();

            // Assert that the correct URL has been reached
            await Assertions.Expect(_user).ToHaveURLAsync(new Regex(".*home/map"));
        }

    }
}
