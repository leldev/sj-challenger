using Shouldly;
using SJ.Challenger.Services.Powerball;
using System.Linq;
using TechTalk.SpecFlow;

namespace SJ.Challenger.Specs.StepDefinitions
{
    [Binding]
    public class PowerballStepDefinitions
    {
        private PowerballService powerballService;
        private Lottery lottery;

        [Given(@"A lottery game")]
        public void GivenALotteryGame()
        {
            this.powerballService = new PowerballService();
        }

        [When(@"A request lottery numbers")]
        public void WhenARequestLotteryNumbers()
        {
            this.lottery = this.powerballService.GetLotteryNumbers();
        }

        [Then(@"I should get unique white numbers")]
        public void ThenIShouldGetUniqueWhiteNumbers()
        {
            var whiteNumbers = this.lottery.WhiteNumbers;

            whiteNumbers.ShouldNotBeNull();
            whiteNumbers.ShouldNotBeEmpty();
            whiteNumbers.Count().ShouldBe(Lottery.cantWriterNumber);

            foreach (var item in whiteNumbers)
            {
                item.ShouldBeInRange(Lottery.minNumber, Lottery.maxWriterNumber);
                whiteNumbers.Count(x => x == item).ShouldBe(1);
            }
        }

        [Then(@"I should get unique powerball number")]
        public void ThenIShouldGetUniquePowerballNumber()
        {
            var powerball = this.lottery.Powerball;

            powerball.ShouldBeInRange(Lottery.minNumber, Lottery.maxPowerballNumber);
        }

    }
}
