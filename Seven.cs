using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter matrix size N (N >= 3): ");
            int n = int.Parse(Console.ReadLine());

            if (n < 3)
            {
                Console.WriteLine("Matrix size must be at least 3.");
                return;
            }

            int[,] matrix = new int[n, n];

            Console.WriteLine("Enter the matrix values row by row (space-separated):");

            for (int i = 0; i < n; i++)
            {
                string[] values = Console.ReadLine().Split(' ');

                while (values.Length != n)
                {
                    Console.WriteLine($"Please enter exactly {n} integers for row {i + 1}:");
                    values = Console.ReadLine().Split(' ');
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < n; i++)
            {
                primarySum += matrix[i, i];            
                secondarySum += matrix[i, n - i - 1];   

            int difference = Math.Abs(primarySum - secondarySum);
            Console.WriteLine($"\nAbsolute difference between diagonal sums: {difference}");
            }
        }
    }
}
