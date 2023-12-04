namespace LineNumbers
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader streamReader = new StreamReader(inputFilePath);
            using StreamWriter streamWriter= new StreamWriter(outputFilePath);

            int counter = 1;
            while(!streamReader.EndOfStream) 
            {
                string line = streamReader.ReadLine();
                int letters = line.Count(x => char.IsLetter(x));
                int punctuations = line.Count(x => char.IsPunctuation(x));

                streamWriter.WriteLine($"Line {counter}: {line} ({letters})({punctuations})");

                counter++;
            }
        }
    }
}
