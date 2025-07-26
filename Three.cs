using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ages = new List<int>();

            Console.WriteLine("Enter at least 20 age values:");

            while (ages.Count < 20)
            {
                Console.Write($"Enter age #{ages.Count + 1}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int age) && age >= 0)
                {
                    ages.Add(age);
                }
                else
                {
                    Console.WriteLine("Please enter a valid non-negative number.");
                }
            }

            int sum = 0, min = int.MaxValue, max = int.MinValue;
            int bracketUnder18 = 0, bracket18to35 = 0, bracket36to60 = 0, bracketOver60 = 0;

            foreach (int age in ages)
            {
                sum += age;
                if (age < min) min = age;
                if (age > max) max = age;

                if (age < 18)
                    bracketUnder18++;
                else if (age <= 35)
                    bracket18to35++;
                else if (age <= 60)
                    bracket36to60++;
                else
                    bracketOver60++;
            }

            double average = (double)sum / ages.Count;

            // Output table
            Console.WriteLine("\nSurvey Statistics:");
            Console.WriteLine("+__________________+________+");
            Console.WriteLine("| Category          | Value |");
            Console.WriteLine("+__________________+________+");
            Console.WriteLine($"| Total Entries     | {ages.Count,6} |");
            Console.WriteLine($"| Average Age       | {average,6:F1} |");
            Console.WriteLine($"| Youngest Age      | {min,6} |");
            Console.WriteLine($"| Oldest Age        | {max,6} |");
            Console.WriteLine("+__________________+________+");

            Console.WriteLine("\nAge Bracket Distribution:");
            Console.WriteLine("+__________________+________+");
            Console.WriteLine("| Age Bracket          | Count  |");
            Console.WriteLine("+______________________+________+");
            Console.WriteLine($"| Under 18 | {bracketUnder18,6} |");
            Console.WriteLine($"| 18 to 35 | {bracket18to35,6} |");
            Console.WriteLine($"| 36 to 60 | {bracket36to60,6} |");
            Console.WriteLine($"| Over 60  | {bracketOver60,6} |");
            Console.WriteLine("+______________________+________+");
        }
    }
}