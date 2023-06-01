using System;
using System.CodeDom.Compiler;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string stringForNum = "";
            int sum = 0;          
            int num = int.Parse(Console.ReadLine());

            string numberS = num.ToString();

            int numberLength = num.ToString().Length;

            while (counter < numberLength)
            {
                int fak = 1;
                for (int i = 0; i < numberLength; i++)
                {
                    stringForNum += numberS[i];
                    int index = Convert.ToInt32(stringForNum);

                    for(int j = index; j >= 1; j--)
                    {
                        fak *= j;
                    }
                    sum += fak;
                    stringForNum = "";
                    fak = 1;
                    counter++;
                }
            }

            if (num == sum)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
