using System;

namespace _01.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string datatyp = Console.ReadLine();
            string input = Console.ReadLine();

            if (datatyp == "int")
            {
                int inputInt = int.Parse(input);
                ChangeInput(inputInt);
            }
            if (datatyp == "string")
                ChangeInput(input);
            if (datatyp == "real")
            {
                double inputDouble = double.Parse(input);
                ChangeInput(inputDouble);
            }
        }
        private static void ChangeInput(string input)
        {
            Console.WriteLine($"${input}$");
        }
        private static void ChangeInput(double input)
        {
            Console.WriteLine($"{(input * 1.5):f2}");
        }
        private static void ChangeInput(int input)
        {
            Console.WriteLine(input * 2);
        }
    }
}
