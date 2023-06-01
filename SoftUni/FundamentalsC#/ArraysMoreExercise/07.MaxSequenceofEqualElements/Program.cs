using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MaxSequenceofEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int index = 0;
            int counter = 1;
            int maxSeq = int.MinValue;
            for(int i = 0; i < arr.Length-1; i++) 
            {                
                if (arr[i] == arr[i+1])
                {
                    counter++;
                    if(maxSeq < counter)
                    {
                        maxSeq = counter;
                        index = arr[i];
                    }
                }
                else
                    counter = 1;
            }

            string result = new StringBuilder().Insert(0, $"{index} ",maxSeq).ToString();
            Console.WriteLine(result);
         
        }
    }
}
