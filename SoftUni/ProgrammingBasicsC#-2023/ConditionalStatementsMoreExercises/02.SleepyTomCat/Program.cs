using System;

namespace _02.SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());
            int workDays = 365 - freeDays;

            int playHours = (workDays * 63) + (freeDays * 127);

            int diff = Math.Abs(30000 - playHours);
            int h = diff / 60;
            int m = diff % 60;


            if (playHours < 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{h} hours and {m} minutes less for play");
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{h} hours and {m} minutes more for play");
            }
        }
    }
}
