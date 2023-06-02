using System;

namespace _01.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 1;
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    if (counter > n)
                        break;

                    Console.Write(counter + " ");
                    counter++;
                }
                if (counter > n)
                    break;
                else
                    Console.WriteLine();
            }
        }
    }
}
