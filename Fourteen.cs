using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourteen
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                const int requiredCount = 25;
                List<string> zipCodes = new List<string>();

                Console.WriteLine($"Please enter at least {requiredCount} zip codes (5-digit numbers):");

                while (zipCodes.Count < requiredCount)
                {
                    Console.Write($"Zip code #{zipCodes.Count + 1}: ");
                    string input = Console.ReadLine()?.Trim();

                    if (IsValidZip(input))
                    {
                        zipCodes.Add(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid zip code. Please enter a 5-digit numeric zip code.");
                    }
                }

                var frequency = zipCodes
                    .GroupBy(z => z)
                    .Select(g => new { Zip = g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count)
                    .ThenBy(g => g.Zip);

                Console.WriteLine("\nZip Code | Frequency");
                Console.WriteLine("____________________");

                foreach (var item in frequency)
                {
                    Console.WriteLine($"{item.Zip,-8} | {item.Count}");
                }
        }

            static bool IsValidZip(string zip)
            {
                if (string.IsNullOrWhiteSpace(zip)) return false;
                if (zip.Length != 5) return false;
                return zip.All(char.IsDigit);
            }
    }
}
