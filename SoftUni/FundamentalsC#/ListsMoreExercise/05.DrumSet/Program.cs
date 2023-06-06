using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal savings = decimal.Parse(Console.ReadLine());
            List <int> quality = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> copiedList = new List<int>();
            for(int i = 0; i < quality.Count; i++)
            {
                copiedList.Add(quality[i]);
            }

            string input = Console.ReadLine();

            while(input != "Hit it again, Gabsy!")            
            {
                int hitPower = int.Parse(input);
                decimal drumPris = 0;

                for(int i = 0; i < quality.Count; i++) 
                {
                    quality[i] -= hitPower;

                    if (quality[i] <= 0)
                    {
                        drumPris = copiedList[i] * 3;

                        if (drumPris <= savings)
                        {
                            quality[i] = copiedList[i];
                            savings -= drumPris;
                        }
                        else
                        {
                            quality.Remove(quality[i]);
                            copiedList.RemoveAt(i);
                            i--;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", quality));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
