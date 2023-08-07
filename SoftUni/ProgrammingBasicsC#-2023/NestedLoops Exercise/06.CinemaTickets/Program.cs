using System;
using System.Data;

namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ouble counterStudent = 0;
            double counterStandart = 0;
            double counterKid = 0;
            double sumKid = 0;
            double sumStandart = 0;
            double sumStudent = 0;
            string film = "";
            int freeChair = 0;
            string ticket = "";
            while (true)
            {
                film = Console.ReadLine();
                if (film == "Finish")
                    break;
                freeChair = int.Parse(Console.ReadLine());

                for (int i = 0; i < freeChair; i++)
                {
                    ticket = Console.ReadLine();
                    if (ticket == "End")
                        break;

                    switch (ticket)
                    {
                        case "student":
                            counterStudent++;
                            break;
                        case "standard":
                            counterStandart++;
                            break;
                        case "kid":
                            counterKid++;
                            break;
                    }
                }
                Console.WriteLine($"{film} - {((counterStandart + counterKid + counterStudent) / freeChair * 100):F2}% full.");
                sumKid += counterKid;
                sumStandart += counterStandart;
                sumStudent += counterStudent;
                counterKid = 0;
                counterStudent = 0;
                counterStandart = 0;
            }
            Console.WriteLine($"Total tickets: {sumStudent + sumStandart + sumKid}");
            Console.WriteLine($"{(sumStudent / (sumStudent + sumStandart + sumKid) * 100):F2}% student tickets.");
            Console.WriteLine($"{(sumStandart / (sumStudent + sumStandart + sumKid) * 100):F2}% standard tickets.");
            Console.WriteLine($"{(sumKid / (sumStudent + sumStandart + sumKid) * 100):F2}% kids tickets.");
        }
    }
}
