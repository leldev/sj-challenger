using SJ.Challenger.Services.Powerball;
using System;
using System.Linq;

namespace SJ.Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lottery = new PowerballService().GetLotteryNumbers();

            Console.WriteLine($"--> White numbers: {string.Join(" ", lottery.WhiteNumbers)}");
            Console.WriteLine($"--> Powerball number: {string.Join(" ", lottery.Powerball)}");
        }
    }
}
