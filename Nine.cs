using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nine
{
    internal class Program
    {
        const int SIZE = 4;
        static char[,] grid = new char[SIZE, SIZE];
        static bool[,] matched = new bool[SIZE, SIZE];
        static void Main(string[] args)
        {
            InitializeGrid();
            int totalPairs = 8;
            int pairsFound = 0;

            while (pairsFound < totalPairs)
            {
                Console.Clear();
                PrintBoard();

                Console.WriteLine("Pick two different positions to reveal (e.g., 1 1):");

                var first = GetPosition("First pick");
                if (matched[first.Item1, first.Item2])
                {
                    Console.WriteLine("That card is already matched! Try again.");
                    Pause();
                    continue;
                }

                var second = GetPosition("Second pick");
                if (matched[second.Item1, second.Item2] || first == second)
                {
                    Console.WriteLine("Invalid second pick. Either matched or same as first.");
                    Pause();
                    continue;
                }

                Console.Clear();
                PrintBoard(first, second);

                char firstChar = grid[first.Item1, first.Item2];
                char secondChar = grid[second.Item1, second.Item2];

                if (firstChar == secondChar)
                {
                    Console.WriteLine("It's a MATCH!");
                    matched[first.Item1, first.Item2] = true;
                    matched[second.Item1, second.Item2] = true;
                    pairsFound++;
                }
                else
                {
                    Console.WriteLine("Not a match.");
                }

                Pause();
            }

            Console.Clear();
            PrintBoard();
            Console.WriteLine("🎉 Congratulations! You matched all pairs!");
        }

        static void InitializeGrid()
        {
            List<char> cards = new List<char>();
            for (char c = 'A'; c <= 'H'; c++)
            {
                cards.Add(c);
                cards.Add(c);
            }

            Random rnd = new Random();
            for (int i = 0; i < SIZE * SIZE; i++)
            {
                int index = rnd.Next(cards.Count);
                int row = i / SIZE;
                int col = i % SIZE;
                grid[row, col] = cards[index];
                cards.RemoveAt(index);
            }
        }

        static void PrintBoard((int, int)? first = null, (int, int)? second = null)
        {
            Console.WriteLine("    1 2 3 4");
            Console.WriteLine("   ---------");

            for (int row = 0; row < SIZE; row++)
            {
                Console.Write((row + 1) + " | ");
                for (int col = 0; col < SIZE; col++)
                {
                    if (matched[row, col])
                    {
                        Console.Write(grid[row, col] + " ");
                    }
                    else if ((first?.Item1 == row && first?.Item2 == col) ||
                             (second?.Item1 == row && second?.Item2 == col))
                    {
                        Console.Write(grid[row, col] + " ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static (int, int) GetPosition(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (row col): ");
                string input = Console.ReadLine();
                var parts = input.Split(' ');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int row) &&
                    int.TryParse(parts[1], out int col) &&
                    row >= 1 && row <= SIZE &&
                    col >= 1 && col <= SIZE)
                {
                    return (row - 1, col - 1);
                }

                Console.WriteLine("Invalid input. Please enter two numbers between 1 and 4.");
            }
        }

        static void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}