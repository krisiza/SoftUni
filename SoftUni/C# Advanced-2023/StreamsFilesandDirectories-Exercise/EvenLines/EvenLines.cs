namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] chars = "-,.!?"
                 .ToCharArray();

            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (counter % 2 == 0)
                    {
                        foreach (char c in chars)
                        {
                            line = line.Replace(c, '@');

                        }

                        string[] words = line.Split(' ').Reverse().ToArray();

                        Console.WriteLine(string.Join(" ", words));
                    }

                    counter++;
                }
            }


            return null;
        }
    }
}
