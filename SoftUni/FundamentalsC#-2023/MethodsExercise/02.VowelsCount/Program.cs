using System;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetVowels(input));
        }
        private static int GetVowels(string word)
        {
            int count = 0;
            for(int i =0; i < word.Length; i++) 
            {
                if (word[i] == 65 || word[i] == 69 || word[i] == 73 || 
                    word[i] == 79 || word[i] == 85 || word[i] == 97 || 
                    word[i] == 101|| word[i] == 105 || word[i] == 111|| word[i] == 117)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
