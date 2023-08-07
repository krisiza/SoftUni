using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for(int i = 0; i < n; i++) 
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if(dic.ContainsKey(word)) 
                {
                    dic[word].Add(synonim);
                }
                else
                {
                    dic.Add(word, new List<string>());
                    dic[word].Add(synonim);
                }
            }

            foreach(var d in dic)
            {
                Console.Write($"{d.Key} - ");
                Console.WriteLine(String.Join(", ", d.Value));
  
            }
        }
    }
}
