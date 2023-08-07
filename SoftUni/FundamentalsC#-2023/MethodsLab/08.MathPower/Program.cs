using System;

namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine()); 

            Console.WriteLine(NumberPower(number, power));
        }
        static decimal NumberPower(double number, double power)
        {
            return (decimal)Math.Pow(number,power);
        }
    }
}   
