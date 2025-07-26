using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[10];
            int[] scores = new int[10];

            Console.WriteLine("Enter names and scores for 10 students:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter name of student #{i + 1}: ");
                names[i] = Console.ReadLine();

                Console.Write($"Enter score of {names[i]}: ");
                while (!int.TryParse(Console.ReadLine(), out scores[i]))
                {
                    Console.Write("Invalid score. Try again: ");
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    if (scores[j] > scores[i] || (scores[j] == scores[i] && string.Compare(names[j], names[i]) < 0))
                    {
                        int tempScore = scores[i];
                        scores[i] = scores[j];
                        scores[j] = tempScore;

                        string tempName = names[i];
                        names[i] = names[j];
                        names[j] = tempName;
                    }
                }
            }

            Console.WriteLine("\nTop 3 Students:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Rank {i + 1}: {names[i]} - Score: {scores[i]}");
            }
        }
    }
}
