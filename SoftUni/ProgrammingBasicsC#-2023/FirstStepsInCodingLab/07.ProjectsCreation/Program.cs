using System;

namespace _07.ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {firstName} will need {projects * 3} hours to complete {projects} project/s.");
        }
    }
}
