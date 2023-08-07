using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"{GetFactorial(number1) / GetFactorial(number2):f2}");
        }
        private static double GetFactorial(int number) 
        {
            double sum = 1;
            for(int i = number; i > 0; i--) 
            {
                sum *= i;
            }
            return sum;
        }
    }
}
