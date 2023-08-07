using System;

namespace _04.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            double counter1 = 0;
            double counter2 = 0;
            double counter3 = 0;
            double counter4 = 0;
            double sum = 0;
            for (int i = 1; i <= students; i++)
            {
                double note = double.Parse(Console.ReadLine());
                sum += note;

                if (note >= 5)
                    counter1++;
                if (note >= 4 && note < 5)
                    counter2++;
                if (note < 4 && note >= 3)
                    counter3++;
                if (note < 3)
                    counter4++;
            }

            Console.WriteLine($"Top students: {(counter1 / students * 100):F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(counter2 / students * 100):F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(counter3 / students * 100):F2}%");
            Console.WriteLine($"Fail: {(counter4 / students * 100):F2}%");
            Console.WriteLine($"Average: {(sum / students):F2}");
        }
    }
}
