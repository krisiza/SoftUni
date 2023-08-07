using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            var pieces = Console.ReadLine();

            int cake = width * height;
            int input = 0;
            int piecesSum = 0;
            while (pieces != "STOP")
            {
                input = int.Parse(pieces);
                cake -= input;

                if (cake < 0)
                {
                    break;
                }

                pieces = Console.ReadLine();
            }

            if (cake < 0)
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            if (pieces == "STOP")
            {
                Console.WriteLine(cake + " pieces are left.");
            }
        }
    }
}
