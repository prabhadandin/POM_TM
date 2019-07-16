using System;
using TechTalk.SpecFlow;

namespace IC_TimeMaterial.HookUp
{
    [Binding]
    public class TMFeature
    {
        [Given(@"I have logged in to Time and Material portal successfully")]
        public void GivenIHaveLoggedInToTimeAndMaterialPortalSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have navigated to TM page")]
        public void GivenIHaveNavigatedToTMPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to create material with valid details successfully")]
        public void ThenIShouldBeAbleToCreateMaterialWithValidDetailsSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
