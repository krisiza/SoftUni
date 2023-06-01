using System;

namespace _02.EnglishNameoftheLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string numString = num.ToString();

            if(numString.EndsWith('1'))
            {
                Console.WriteLine("one");
            }
            else if(numString.EndsWith("2")) 
            {
                Console.WriteLine("two");
            }
            else if (numString.EndsWith("3"))
            {
                Console.WriteLine("three");
            }
            else if (numString.EndsWith("4"))
            {
                Console.WriteLine("four");
            }
            else if (numString.EndsWith("5"))
            {
                Console.WriteLine("five");
            }
            else if (numString.EndsWith("6"))
            {
                Console.WriteLine("six");
            }
            else if (numString.EndsWith("7"))
            {
                Console.WriteLine("seven");
            }
            else if (numString.EndsWith("8"))
            {
                Console.WriteLine("eight");
            }
            else if (numString.EndsWith("9"))
            {
                Console.WriteLine("nine");
            }
            else if (numString.EndsWith("0"))
            {
                Console.WriteLine("zero");
            }
        }
    }
}
