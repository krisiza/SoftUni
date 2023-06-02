using System;

namespace _01.Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cleaner = int.Parse(Console.ReadLine());

            string dishes = Console.ReadLine();

            int cleanerSum = cleaner * 750;
            int input = 0;
            int dishesSum = 0;
            int potsSum = 0;
            int counter = 0;
            while (dishes != "End")
            {
                input = int.Parse(dishes);

                if (counter == 2)
                {
                    input = input * 15;
                    counter = 0;
                    potsSum += input / 15;
                }
                else
                {
                    input = input * 5;
                    counter++;
                    dishesSum += input / 5;
                }
                cleanerSum -= input;
                if (cleanerSum < 0)
                    break;

                dishes = Console.ReadLine();
            }

            if (cleanerSum < 0)
                Console.WriteLine($"Not enough detergent, {Math.Abs(cleanerSum)} ml. more necessary!");
            if (dishes == "End")
                Console.WriteLine($"Detergent was enough!\n{dishesSum} dishes and {potsSum} pots were washed.\nLeftover detergent {cleanerSum} ml.");
        }
    }
}
