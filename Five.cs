using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Five
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] original = new int[10];
            int[] shifted = new int[10];

            Console.WriteLine("Enter 10 integers for the array:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Element #{i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out original[i]))
                {
                    Console.Write("Invalid input. Enter an integer: ");
                }
            }

            Console.Write("\nEnter the number of positions to shift (k): ");
            int k;
            while (!int.TryParse(Console.ReadLine(), out k))
            {
                Console.Write("Invalid input. Enter a valid number for k: ");
            }

            k = k % 10;

            for (int i = 0; i < 10; i++)
            {
                shifted[(i + k) % 10] = original[i];
            }

            Console.WriteLine("\nOriginal Array:");
            Console.WriteLine(string.Join(" ", original));

            Console.WriteLine("\nShifted Array:");
            Console.WriteLine(string.Join(" ", shifted));
        }
    }
}

