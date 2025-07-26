using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> transactions = new List<decimal>();

            while (true)
            {
                Console.WriteLine("Enter at least 20 transaction amounts separated by space or comma:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                string[] parts = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                transactions.Clear();

                bool allValid = true;
                foreach (var part in parts)
                {
                    if (decimal.TryParse(part.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal val))
                    {
                        transactions.Add(val);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid decimal value detected: '{part}'");
                        allValid = false;
                        break;
                    }
                }

                if (!allValid) continue;

                if (transactions.Count < 20)
                {
                    Console.WriteLine($"You entered {transactions.Count} values. Please enter at least 20.");
                    continue;
                }

                break;
            }

            var filtered = transactions.Where(t => t > 10000).ToList();
            decimal total = filtered.Sum();

            Console.WriteLine("\nTransactions above 10,000.00:");
            filtered.ForEach(t => Console.WriteLine(t.ToString("F2")));

            Console.WriteLine($"\nTotal of qualifying transactions: {total.ToString("F2")}");
        }
    }
}
