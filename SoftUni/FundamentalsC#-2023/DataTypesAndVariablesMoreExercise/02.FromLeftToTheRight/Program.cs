using System;
using System.Numerics;

namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string sum1 = "", sum2 = "";
                double sum = 0D;

                long[] intArray = new long[2];

                string input = Console.ReadLine();

                string[] stringArray = input.Split(' ');

                for (int j = 0; j < stringArray.Length; j++)
                {
                    intArray[j] = Convert.ToInt64(stringArray[j]);
                }

                if (intArray[0] >= intArray[1])
                {
                    string index = Math.Abs(intArray[0]).ToString();
                    for (int j = 0; j < index.Length; j++)
                    {
                        sum1 += index[j];
                        sum += Convert.ToInt64(sum1);
                        sum1 = "";
                    }

                    Console.WriteLine(sum);
                }
                else if (intArray[1] >= intArray[0])
                {
                    string index = intArray[1].ToString();
                    for (int j = 0; j <index.Length; j++)
                    {
                        sum2 += index[j];
                        sum += Convert.ToInt64(sum2);
                        sum2 = "";

                    }
                    Console.WriteLine(sum);
                }

            }
        }
    }
}
