using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<char> charList = input.ToCharArray().ToList();

            List<int> numbers = new List<int>();
            for (int i = charList.Count - 1; i >= 0; i--)
            {
                if (charList[i] >= 48 && charList[i] <= 57)
                {
                    numbers.Add(charList[i] - '0');
                    charList.RemoveAt(i);
                }
            }
            numbers.Reverse();

            List<int> oddList = new List<int>();
            List<int> evenList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                    evenList.Add(numbers[i]);
                else
                    oddList.Add(numbers[i]);
            }

            int sumSkiped = 0;
            string message = string.Empty;

            int indexEven = 0;
            int indexOdd = 0;
            while (indexEven < evenList.Count && indexOdd < oddList.Count)
            {
                for(int i = sumSkiped; i < sumSkiped + evenList[indexEven] && i < charList.Count; i++) 
                {
                    message += charList[i];
                }

                sumSkiped += oddList[indexOdd] + evenList[indexEven];
                indexOdd++;
                indexEven++;
            }

            Console.WriteLine(message);
        }
    }
}
