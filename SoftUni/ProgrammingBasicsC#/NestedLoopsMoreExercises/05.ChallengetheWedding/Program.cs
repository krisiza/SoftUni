using System;

namespace _05.ChallengetheWedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());

            int counter = 0;
            bool end = false;
            while (counter < tables)
            {
                if (end == true)
                    break;
                for (int y = 1; y <= men; y++)
                {
                    if (counter >= tables)
                        break;
                    for (int j = 1; j <= women; j++)
                    {
                        if (counter >= tables)
                            break;
                        else
                        {
                            Console.Write($"({y} <-> {j}) ");
                            counter++;
                            if (y == men && j == women)
                                break;
                        }
                    }
                    if (y == men)
                    {
                        end = true;
                        break;
                    }
                }
            }
        }
    }
}
