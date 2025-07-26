using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int days = 7;
            decimal[] prices = new decimal[days];
            decimal[] gains = new decimal[days - 1]; // gains from Day 2 to Day 7

            Console.WriteLine("Enter stock prices for 7 consecutive days:");

            for (int i = 0; i < days; i++)
            {
                Console.Write($"Day {i + 1} price: ");
                while (!decimal.TryParse(Console.ReadLine(), out prices[i]) || prices[i] <= 0)
                {
                    Console.Write("Invalid input. Enter a positive number: ");
                }
            }

            int highestGainDay = 1;
            decimal maxGain = decimal.MinValue;

            Console.WriteLine("\nPercentage Gains Table:");
            Console.WriteLine("+________+______________________+");
            Console.WriteLine("|  Day   |   % Gain from Prev   |");
            Console.WriteLine("+________+______________________+");

            for (int i = 1; i < days; i++)
            {
                gains[i - 1] = ((prices[i] - prices[i - 1]) / prices[i - 1]) * 100;
                Console.WriteLine($"| Day {i + 1,-4} | {gains[i - 1],8:F2}%  |");

                if (gains[i - 1] > maxGain)
                {
                    maxGain = gains[i - 1];
                    highestGainDay = i + 1;
                }
            }

            Console.WriteLine("+________+______________________+");
            Console.WriteLine($"\nHighest Gain: Day {highestGainDay} ({maxGain:F2}%)");
        }
    }
}