using System;

namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());

            double plusLightsabers = Math.Ceiling(countOfStudents * 0.1);
            double lightsabersSum = priceOfLightsabers * (countOfStudents + plusLightsabers);

            int beltDiscount = 0;
            for(int i = 1; i <= countOfStudents; i++) 
            {
                if(i % 6 == 0)
                    beltDiscount++;
            }

            double beltsSum = priceOfBelts * (countOfStudents - beltDiscount);
            double robesSum = priceOfRobes * countOfStudents;

            double sum = beltsSum + robesSum + lightsabersSum;

            if (sum <= amountOfMoney)
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            else
                Console.WriteLine($"John will need {(sum - amountOfMoney):f2}lv more.");
        }
    }
}
