using System;

namespace WhileLoopLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            bool stop = false;
            do
            {
                text = Console.ReadLine();
                if (text == "Stop")
                {
                    stop = true;
                }
                else if (text != "Stop")
                {
                    Console.WriteLine(text);
                }
            }
            while (!stop);
        }
    }
}
