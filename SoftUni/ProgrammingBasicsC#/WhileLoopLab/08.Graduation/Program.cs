using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = 0;
            int counter = 0;
            bool fail = false;
            double grade2 = 0;

            string name = Console.ReadLine();
            while (counter < 12 && !fail)
            {
                grade = double.Parse(Console.ReadLine());
                counter++;
                if (grade < 4)
                {
                    fail = true;
                    break;
                }
                grade2 += grade;
            }
            if (fail)
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            else
            {
                grade = grade2 / counter;
                Console.WriteLine($"{name} graduated. Average grade: {grade:F2}");
            }
        }
    }
}
