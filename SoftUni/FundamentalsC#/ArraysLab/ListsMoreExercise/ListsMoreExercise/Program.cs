using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsMoreExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            List<char> charList = input.ToCharArray().ToList();

            string message = string.Empty;
            for (int i = 0; i < numbers.Count; i++)
            {
                string num = numbers[i].ToString();
                int sum = 0;

                for (int j = 0; j < num.Length; j++)
                {
                    sum += num[j] - '0';
                }

                while (sum > charList.Count - 1)
                    sum -= charList.Count;

                message += charList[sum];
                charList.RemoveAt(sum);
            }
            Console.WriteLine(message);
        }
    }
}
