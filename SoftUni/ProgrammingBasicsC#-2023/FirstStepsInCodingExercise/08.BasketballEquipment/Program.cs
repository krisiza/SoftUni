using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearPrice = int.Parse(Console.ReadLine());

            double shoesPrice = yearPrice - ((yearPrice * 40) / 100);
            double trainingset = shoesPrice - ((shoesPrice * 20) / 100);
            double ballPrice = (trainingset * 25) / 100;
            double accessories = (ballPrice * 20) / 100;

            double sum = yearPrice + shoesPrice + trainingset + ballPrice + accessories;
            Console.WriteLine(sum);
        }
    }
}
