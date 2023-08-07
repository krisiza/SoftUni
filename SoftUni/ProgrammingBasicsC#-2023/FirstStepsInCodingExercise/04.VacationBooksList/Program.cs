using System;

namespace _04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int hourPages = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int readTime = pages / hourPages;
            int hours = readTime / days;

            Console.WriteLine(hours);
        }
    }
}
