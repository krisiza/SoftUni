using System;

namespace _1.DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            int isInt;
            float isFloat;
            string isString;
            char isChar;
            bool isBool;

            string type = "";
            while(command != "END")
            {
                if (int.TryParse(command, out isInt))
                    type = "integer type";
                else if (float.TryParse(command, out isFloat))
                    type = "floating point type";
                else if (char.TryParse(command, out isChar))
                    type = "character type";
                else if (bool.TryParse(command, out isBool))
                    type = "boolean type";
                else
                    type = "string type";


                Console.WriteLine($"{command} is {type}");

                command = Console.ReadLine();
            }
        }
    }
}
