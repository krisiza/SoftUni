using System;

namespace _07.SafePasswordsGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int password = int.Parse(Console.ReadLine());

            int counter = 0;
            int aA = 35;
            int bB = 64;


            for (int j = 1; j <= a; j++)
            {
                if (counter >= password)
                    break;
                for (int k = 1; k <= b; k++)
                {
                    if (counter >= password)
                        break;

                    Console.Write($"{(char)aA}{(char)bB}{j}{k}{(char)bB}{(char)aA}|");
                    aA++;
                    if (aA > 55)
                        aA = 35;
                    bB++;
                    if (bB > 96)
                        bB = 64;
                    counter++;

                }
            }
        }
    }
}
