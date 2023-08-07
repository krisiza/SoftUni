using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            double biggestKeg = int.MinValue;
            string biggerstKegName = string.Empty;
            for(int i = 0; i < lines; i++) 
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double sumKeg = Math.PI * Math.Pow(radius, 2) * height;

                if (sumKeg > biggestKeg)
                {
                    biggestKeg = sumKeg;
                    biggerstKegName = model;
                }
            }

            Console.WriteLine(biggerstKegName);
        }
    }
}
