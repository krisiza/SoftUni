using System;

namespace FirstStepsInCodingExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double usd = Convert.ToDouble(Console.ReadLine());
            double bgn = usd * 1.79549;
            Console.WriteLine(bgn);
        }
    }
}
