using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> inventory = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Enter book titles and quantities (type 'done' to finish):");

            while (true)
            {
                Console.Write("Book title: ");
                string title = Console.ReadLine()?.Trim();

                if (string.Equals(title, "done", StringComparison.OrdinalIgnoreCase))
                    break;

                if (string.IsNullOrWhiteSpace(title))
                    continue;

                Console.Write("Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid quantity. Try again.");
                    continue;
                }

                if (inventory.ContainsKey(title))
                    inventory[title] += quantity;
                else
                    inventory[title] = quantity;
            }

            Console.Write("\nEnter a book title to search and update: ");
            string search = Console.ReadLine()?.Trim();

            if (inventory.ContainsKey(search))
            {
                Console.WriteLine($"Found '{search}' with quantity: {inventory[search]}");
                Console.Write("Enter new quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newQty) && newQty >= 0)
                    inventory[search] = newQty;
                else
                    Console.WriteLine("Invalid quantity. No update made.");
            }
            else
            {
                Console.WriteLine("Book not found in inventory.");
            }

            Console.WriteLine("\nInventory:");
            foreach (var item in inventory)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}