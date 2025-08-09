using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace act15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers;
            int k;

            do
            {
                Console.WriteLine("Enter at least 10 integers separated by commas:");
                numbers = Console.ReadLine()
                    .Split(',')
                    .Select(s => int.TryParse(s.Trim(), out int n) ? n : int.MinValue)
                    .Where(n => n != int.MinValue)
                    .ToArray();
            } while (numbers.Length < 10);

            do
            {
                Console.WriteLine($"Enter window size k (<= {numbers.Length}):");
            } while (!int.TryParse(Console.ReadLine(), out k) || k <= 0 || k > numbers.Length);

            Console.WriteLine("\nSliding window sums:");
            for (int i = 0; i <= numbers.Length - k; i++)
            {
                int sum = 0;
                for (int j = i; j < i + k; j++)
                    sum += numbers[j];

                Console.WriteLine($"Window {i + 1} ({string.Join(", ", numbers.Skip(i).Take(k))}): Sum = {sum}");
            }
        }
    }
}
