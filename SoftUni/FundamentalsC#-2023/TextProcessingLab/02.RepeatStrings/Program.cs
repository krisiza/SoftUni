using System;
using System.Text;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            StringBuilder result = new StringBuilder();

            for(int i = 0; i < arr.Length; i++) 
            {
                string word = arr[i];

                for(int j = 0; j < word.Length;j++) 
                {
                    result.Append(word);
                }

            }
            Console.WriteLine(result);
        }
    }
}
