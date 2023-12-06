using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine(); 

            DateModifier dateModifier = new DateModifier();
            double difference = dateModifier.CalculateDifferenceInDays(firstDate, secondDate);

            Console.WriteLine(difference);
        }
    }
}
