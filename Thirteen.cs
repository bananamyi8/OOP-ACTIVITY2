using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace act13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] durations;

            Console.WriteLine("Enter 10 durations in seconds, separated by commas:");

            while (true)
            {
                var input = Console.ReadLine();
                var parts = input.Split(',')
                                 .Select(s => s.Trim());

                if (parts.Count() == 10 && parts.All(p => int.TryParse(p, out _)))
                {
                    durations = parts.Select(int.Parse).ToArray();
                    break;
                }

                Console.WriteLine("Please enter exactly 10 valid integers separated by commas:");
            }

            Console.WriteLine("\nSeconds   | HH:MM:SS");

            foreach (var seconds in durations)
            {
                TimeSpan time = TimeSpan.FromSeconds(seconds);
                string formatted = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                                 time.Hours,
                                                 time.Minutes,
                                                 time.Seconds);

                Console.WriteLine($"{seconds,8} | {formatted}");
            }
        }
    }
}
