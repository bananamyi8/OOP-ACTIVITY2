using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace act3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ages = new int[20];

            int sum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;

            int under18 = 0;
            int between18and35 = 0;
            int between36and60 = 0;
            int over60 = 0;

            Console.WriteLine("Enter 20 age responses:");

            for (int i = 0; i < 20; i++)
            {
                Console.Write($"Age {i + 1}: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age < 0 || age > 120)
                {
                    Console.Write("Invalid. Enter an age between 0 and 120: ");
                }

                ages[i] = age;
                sum += age;

                if (age < min) min = age;
                if (age > max) max = age;

                // Categorize
                if (age < 18)
                    under18++;
                else if (age <= 35)
                    between18and35++;
                else if (age <= 60)
                    between36and60++;
                else
                    over60++;
            }

            double average = (double)sum / 20;

            Console.WriteLine($"Average Age       : {average:F2}");
            Console.WriteLine($"Minimum Age       : {min}");
            Console.WriteLine($"Maximum Age       : {max}");
            Console.WriteLine($"Count < 18        : {under18}");
            Console.WriteLine($"Count 18 - 35     : {between18and35}");
            Console.WriteLine($"Count 36 - 60     : {between36and60}");
            Console.WriteLine($"Count > 60        : {over60}");

        }
    }
}

