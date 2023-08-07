using System;
using System.Globalization;

namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clicks = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 0; i < clicks; i++)
            {
                string num = Console.ReadLine();

                int digits = num.Length;
                int mainDigit = 0;

                string numString = num.ToString();

                if (numString.Contains('2'))
                    mainDigit = 2;
                if (numString.Contains('3'))
                    mainDigit = 3;
                if (numString.Contains('4'))
                    mainDigit = 4;
                if (numString.Contains('5'))
                    mainDigit = 5;
                if (numString.Contains('6'))
                    mainDigit = 6;
                if (numString.Contains('7'))
                    mainDigit = 7;
                if (numString.Contains('8'))
                    mainDigit = 8;
                if (numString.Contains('9'))
                    mainDigit = 9;
                if (numString.Contains('0'))
                    mainDigit = 0;

                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 0)
                {
                    message += " ";
                    continue;
                }

                if (mainDigit > 7)
                    message += (char)(97 + (mainDigit - 2) * 3 + digits);
                else
                    message += (char)(97 + (mainDigit - 2) * 3 + digits - 1);
            }

            Console.WriteLine(message);
        }
    }
}
