using System;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool correctPassword = false;
            bool userBlocked = false;
            int counter = 0;

            string username = Console.ReadLine();

            string password = "";

            for(int i = username.Length-1; i >= 0; i--) 
            {
                password += username[i];
            }

            while (!correctPassword)
            {
                string inputPass = Console.ReadLine();


                if (inputPass == password)
                {
                    correctPassword = true;
                    break;
                }
                else
                {
                    counter++;
                    if (counter >= 4)
                    {
                        userBlocked = true;
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }

            if (userBlocked)
                Console.WriteLine($"User {username} blocked!");
            else if (correctPassword)
                Console.WriteLine($"User {username} logged in.");
        }
    }
}
