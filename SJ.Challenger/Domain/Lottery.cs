using System.Collections.Generic;

namespace SJ.Challenger.Services.Powerball
{
    public class Lottery
    {
        public static int minNumber = 1;
        public static int maxWriterNumber = 69;
        public static int maxPowerballNumber = 26;
        public static int cantWriterNumber = 5;

        public IReadOnlyList<int> WhiteNumbers { get; set; }

        public int Powerball { get; set; }
    }
}
