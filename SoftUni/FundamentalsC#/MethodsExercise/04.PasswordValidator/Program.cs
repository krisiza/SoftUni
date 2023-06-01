using System;

namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (!CheckIfPasswordContainEnougthChar(password))
                Console.WriteLine("Password must be between 6 and 10 characters");
            if (!CheckIfPasswordHaveOnlyLattersAndDigits(password))
                Console.WriteLine("Password must consist only of letters and digits");
            if (!CheckIfPasswordHave2Digits(password))
                Console.WriteLine("Password must have at least 2 digits");

            if (CheckIfPasswordContainEnougthChar(password) && CheckIfPasswordHaveOnlyLattersAndDigits(password) && CheckIfPasswordHave2Digits(password))
                Console.WriteLine("Password is valid");
        }
        private static bool CheckIfPasswordContainEnougthChar(string password) 
        {
            if (password.Length >= 6 && password.Length <= 10) 
                return true;
            else
                return false;
        }
        private static bool CheckIfPasswordHaveOnlyLattersAndDigits(string password) 
        {
            bool passOk = false;

            for(int i = 0; i < password.Length; i++) 
            {
                if (password[i] >= 48 && password[i] <= 57 ||
                    password[i] >= 65 && password[i] <= 90 ||
                    password[i] >= 97 && password[i] <= 122)
                    passOk = true;
                else

                {
                    passOk = false;
                    break;
                }
            }

            return passOk;
        }
        private static bool CheckIfPasswordHave2Digits(string password) 
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                    count++;      
            }

            if(count >= 2)
                return true;
            else
                return false;
        }
    }
}
