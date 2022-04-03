using Shouldly;
using SJ.Challenger.Services.TextFormat;
using TechTalk.SpecFlow;

namespace SJ.Challenger.Specs.StepDefinitions
{
    [Binding]
    public class TextFormatStepDefinitions
    {
        private string text;
        private TextFormatService textFormatService;
        private bool result;

        [Given(@"A (.*) with format")]
        public void GivenAHelloWithFormat(string text)
        {
            this.text = text;
            this.textFormatService = new TextFormatService();
        }

        [When(@"A validate if text is formatted")]
        public void WhenAValidateIfTextIsFormatted()
        {
            result = this.textFormatService.IsTextFormatted(this.text);
        }

        [Then(@"I should get formatter (.*)")]
        public void ThenIShouldGetFormatterTrue(bool result)
        {
            this.result.ShouldBe(result);
        }
    }
}
