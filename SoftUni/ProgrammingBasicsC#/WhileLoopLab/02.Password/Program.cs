using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string input = "";
            bool corrPass = false;
            do
            {
                input = Console.ReadLine();
                if (input == password)
                    corrPass = true;
            }
            while (!corrPass);

            Console.WriteLine($"Welcome {username}!");
        }
    }
}
