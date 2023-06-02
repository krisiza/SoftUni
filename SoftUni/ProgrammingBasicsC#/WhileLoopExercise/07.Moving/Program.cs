using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * height * length;

            var boxes = Console.ReadLine();
            int input = 0;
            while (boxes != "Done")
            {
                input = int.Parse(boxes);
                freeSpace -= input;
                if (freeSpace < 0) break;

                boxes = Console.ReadLine();
            }

            if (freeSpace < 0)
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
            if (boxes == "Done")
                Console.WriteLine(freeSpace + " Cubic meters left.");
        }
    }
}
