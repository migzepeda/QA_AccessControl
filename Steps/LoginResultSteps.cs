using Microsoft.Playwright;
using QA_AccessControl.Pages;

namespace QA_AccessControl.Steps
{
    [Binding]
    public class LoginResultSteps
    {
        private readonly MapPage _mapPage;

        public LoginResultSteps(MapPage mapPage)
        {
            _mapPage = mapPage;
        }

        [Then(@"the user is on the Map page")]
        public async Task ThenTheUserIsOnTheMapPage()
        {
            // Assert the page content
            await _mapPage.AssertPageContent();
        }

    }
}
