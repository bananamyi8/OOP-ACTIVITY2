using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace act12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 10 integers separated by commas:");
            int[] numbers;
            while (true)
            {
                var input = Console.ReadLine();
                var parts = input.Split(',').Select(s => s.Trim());
                if (parts.Count() == 10 && parts.All(p => int.TryParse(p, out _)))
                {
                    numbers = parts.Select(int.Parse).ToArray();
                    break;
                }
                Console.WriteLine("Please enter exactly 10 valid integers:");
            }

            Console.WriteLine("Enter an expression using 'x' as variable (e.g. (2*x + 3) % 5):");
            string expr = Console.ReadLine();

            int[] results = new int[10];
            var table = new DataTable();

            for (int i = 0; i < numbers.Length; i++)
            {
                string replaced = expr.Replace("x", numbers[i].ToString());
                try
                {
                    var val = table.Compute(replaced, "");
                    results[i] = Convert.ToInt32(val);
                }
                catch
                {
                    Console.WriteLine($"Error evaluating expression for x={numbers[i]}");
                    results[i] = 0;
                }
            }

            Console.WriteLine("\nOriginal array: " + string.Join(", ", numbers));
            Console.WriteLine("Evaluated array: " + string.Join(", ", results));
        }
    }
}
