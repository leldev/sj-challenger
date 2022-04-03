using System;
using System.Collections.Generic;
using System.Linq;

namespace SJ.Challenger.Services.Powerball
{
    public class PowerballService
    {
        public Lottery GetLotteryNumbers()
        {
            var lottery = new Lottery()
            {
                Powerball = this.GetPowerballs(),
                WhiteNumbers = this.GetWriteNumbers()
            };

            return lottery;
        }

        private List<int> GetWriteNumbers()
        {
            var result = new List<int>();

            // Loop until result contains all numbers
            while (result.Count() < Lottery.cantWriterNumber)
            {
                var newNumber = this.GetLotteryNumber(Lottery.minNumber, Lottery.maxWriterNumber);

                // Check if number already exist
                if (!result.Any(x => x == newNumber))
                {
                    result.Add(newNumber);
                }
            }

            return result;
        }
        private int GetPowerballs()
        {
            return this.GetLotteryNumber(Lottery.minNumber, Lottery.maxPowerballNumber);
        }

        private int GetLotteryNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}