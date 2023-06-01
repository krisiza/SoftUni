using System;

namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grad = double.Parse(Console.ReadLine());
            GradCheck(grad);
        }
        static void GradCheck(double grad) 
        {
            if (grad >= 2 && grad <= 2.99)
                Console.WriteLine("Fail");
            else if (grad <= 3.49)
                Console.WriteLine("Poor");
            else if (grad <= 4.49)
                Console.WriteLine("Good");
            else if (grad <= 5.49)
                Console.WriteLine("Very good");
            else if (grad <= 6)
                Console.WriteLine("Excellent");
        }
    }
}
