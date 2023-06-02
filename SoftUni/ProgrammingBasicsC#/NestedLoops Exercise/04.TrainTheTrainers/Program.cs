using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            double noteSum = 0;
            double noteEnd = 0;
            int jury = int.Parse(Console.ReadLine());
            while (true)
            {
                string presentation = Console.ReadLine();
                if (presentation == "Finish")
                    break;

                double note = 0;
                for (int i = 0; i < jury; i++)
                {
                    note = double.Parse(Console.ReadLine());
                    noteSum += note;
                }
                Console.WriteLine($"{presentation} - {noteSum / jury:F2}.");
                noteEnd += noteSum;
                noteSum = 0;
                counter++;
            }
            Console.WriteLine($"Student's final assessment is {(noteEnd / (counter * jury)):F2}.");
        }
    }
}
