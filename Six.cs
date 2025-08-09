using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace act6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter at least 15 contact names separated by commas:");

            List<string> names;

            while (true)
            {
                string input = Console.ReadLine();
                names = input.Split(',')
                             .Select(n => n.Trim())
                             .Where(n => !string.IsNullOrEmpty(n))
                             .ToList();

                if (names.Count >= 15)
                    break;

                Console.WriteLine("You entered fewer than 15 names. Try again:");
            }

            var uniqueSortedNames = names
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(n => n, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("\nUnique, Sorted Contact Names:");
            foreach (var name in uniqueSortedNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
