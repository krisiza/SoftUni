using System;

namespace _3.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "subtract": Console.WriteLine(Substract(number, number2)); break;
                case "divide": Console.WriteLine(Divide(number, number2)); break;
                case "multiply": Console.WriteLine(Multiply(number, number2)); break;
                case "add":Console.WriteLine(Add(number, number2)); break;
            }

        }
        static int Substract(int a, int b)
        {
            return a - b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
