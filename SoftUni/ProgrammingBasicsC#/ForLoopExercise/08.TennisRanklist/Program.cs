using System;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournament = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            double counter = 0;
            int Points = startPoints;
            for (int i = 1; i <= tournament; i++)
            {
                string position = Console.ReadLine();

                switch (position)
                {
                    case "W":
                        Points += 2000;
                        counter++;
                        break;
                    case "F":
                        Points += 1200;
                        break;
                    case "SF":
                        Points += 720;
                        break;
                }
            }

            Console.WriteLine("Final points: " + Points);
            Console.WriteLine("Average points: " + (Points - startPoints) / tournament);
            Console.WriteLine($"{((counter / tournament) * 100):F2}%");
        }
    }
}
