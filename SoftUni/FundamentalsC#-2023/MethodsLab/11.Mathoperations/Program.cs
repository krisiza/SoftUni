using System;

namespace _11.Mathoperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string @operatorr = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(firstNumber, secondNumber, operatorr));
        }
        private static double Calculate(int a, int b, string @operator)
        {
            switch (@operator)
            {
                case "-":
                    return a - b;
                    break;
                case "+":
                    return a + b;
                    break;
                case "*":
                    return a * b;
                    break;
                case "/":
                    return a / b;
                    break;
                default: return 0;
            }
        }
    }
}
