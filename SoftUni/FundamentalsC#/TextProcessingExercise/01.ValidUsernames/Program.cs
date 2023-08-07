using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            List<string> validUsers = new List<string>();

            foreach (string user in usernames)
            {
                if(user.Length >= 3 && user.Length <= 16)
                { 
                if (user.All(letter => char.IsLetterOrDigit(letter) || letter == '_' || letter == '-'))
                {
                    validUsers.Add(user);
                }
                }
            }

            Console.WriteLine(String.Join("\n", validUsers));
        }
    }
}
