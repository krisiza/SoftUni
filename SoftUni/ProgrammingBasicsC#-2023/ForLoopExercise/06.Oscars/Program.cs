using System;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool oscar = false;

            string actor = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int jury = int.Parse(Console.ReadLine());

            double sumPoints = points;
            for (int i = 1; i <= jury; i++)
            {
                string name = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());

                int nameL = name.Length;

                sumPoints += (juryPoints * nameL) / 2;

                if (sumPoints >= 1250.5)
                {
                    oscar = true;
                    break;
                }
            }
            if (oscar)
                Console.WriteLine($"Congratulations, {actor} got a nominee for leading role with {sumPoints:F1}!");
            else
                Console.WriteLine($"Sorry, {actor} you need {(1250.5 - sumPoints):F1} more!");
        }
    }
}
