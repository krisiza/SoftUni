using System;

namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capaxity = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling((double)numberOfPeople / capaxity));
        }
    }
}
