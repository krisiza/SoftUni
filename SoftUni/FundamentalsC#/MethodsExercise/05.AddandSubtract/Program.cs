using System;

namespace _05.AddandSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            double result = Subtract(GetSum(num1,num2), num3);

            Console.WriteLine(result);
        }
        private static int GetSum(int num, int num2) 
        {
            return num + num2;
        }
        private static double Subtract(int num, int num2) 
        {
            return num - num2;
        }
    }
}
