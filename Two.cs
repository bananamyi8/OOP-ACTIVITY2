using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two
{
    internal class Event
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        static void Main(string[] args)
        {
            List<Event> events = new List<Event>();

            Console.WriteLine("Enter 5 events (name and date in MM/DD/YYYY format):");

            while (events.Count < 5)
            {
                Console.Write($"\nEvent #{events.Count + 1} name: ");
                string name = Console.ReadLine();

                Console.Write("Event date (MM/DD/YYYY): ");
                string inputDate = Console.ReadLine();

                DateTime date;
                if (!DateTime.TryParseExact(inputDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Invalid date format. Use MM/DD/YYYY.");
                    continue;
                }

                bool dateExists = events.Exists(e => e.Date == date);
                if (dateExists)
                {
                    Console.WriteLine("This date is already taken. Enter a unique date.");
                    continue;
                }

                events.Add(new Event { Name = name, Date = date });
            }

            events.Sort((a, b) => a.Date.CompareTo(b.Date));

            Console.WriteLine("\nSorted Events:");
            foreach (var ev in events)
            {
                Console.WriteLine($"{ev.Date.ToString("MM/dd/yyyy")} - {ev.Name}");
            }
        }
    }
}
