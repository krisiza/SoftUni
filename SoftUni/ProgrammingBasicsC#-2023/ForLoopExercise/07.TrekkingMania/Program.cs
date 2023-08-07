using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());

            double counterMus = 0;
            double counterMon = 0;
            double counterKilim = 0;
            double counterK2 = 0;
            double counterE = 0;
            double sumParticipants = 0;
            for (int i = 1; i <= groups; i++)
            {
                int participants = int.Parse(Console.ReadLine());
                sumParticipants += participants;
                if (participants <= 5)
                    counterMus += participants;
                if (participants >= 6 && participants <= 12)
                    counterMon += participants;
                if (participants >= 13 && participants <= 25)
                    counterKilim += participants;
                if (participants >= 26 && participants <= 40)
                    counterK2 += participants;
                if (participants >= 41)
                    counterE += participants;

            }

            Console.WriteLine($"{(counterMus / sumParticipants * 100):F2}%");
            Console.WriteLine($"{(counterMon / sumParticipants * 100):F2}%");
            Console.WriteLine($"{(counterKilim / sumParticipants * 100):F2}%");
            Console.WriteLine($"{(counterK2 / sumParticipants * 100):F2}%");
            Console.WriteLine($"{(counterE / sumParticipants * 100):F2}%");
        }
    }
}
