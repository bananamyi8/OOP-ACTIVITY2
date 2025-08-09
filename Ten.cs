using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace act10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> scores;
            do
            {
                Console.WriteLine("Enter at least 10 scores separated by commas:");
                scores = Console.ReadLine()
                    .Split(',')
                    .Select(s => s.Trim())
                    .Where(s => int.TryParse(s, out _))
                    .Select(int.Parse)
                    .ToList();
            } while (scores.Count < 10);

            scores.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine("\nLeaderboard BEFORE:");
            for (int i = 0; i < scores.Count; i++)
                Console.WriteLine($"{i + 1}. {scores[i]}");

            Console.WriteLine("\nEnter new player's score:");
            int newScore = int.Parse(Console.ReadLine());

            int index = scores.FindIndex(s => newScore > s);
            if (index == -1)
                scores.Add(newScore);
            else
                scores.Insert(index, newScore);

            Console.WriteLine("\nLeaderboard AFTER:");
            for (int i = 0; i < scores.Count; i++)
                Console.WriteLine($"{i + 1}. {scores[i]}");
        }
    }
}
