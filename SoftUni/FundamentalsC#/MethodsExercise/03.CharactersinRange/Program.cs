using System;

namespace _03.CharactersinRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch1 = char.Parse(Console.ReadLine());
            char ch2 = char.Parse(Console.ReadLine());

            GetChar(ch1, ch2);
        }
        private static void GetChar(char ch, char ch2) 
        { 
            if(ch > ch2)
            {
                char index = ch;
                ch = ch2;
                ch2 = index;
            }
            for(int i = ch+1; i < ch2; i++) 
            {
                Console.Write(Convert.ToChar(i) + " ");
            }
        }
    }
}
