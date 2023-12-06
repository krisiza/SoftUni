using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int members = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < members; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
              
                family.AddMember(person);
            }

            List<Person> moreThan30 = family.MoreThan30();

            foreach (Person person in moreThan30) 
            { 
                Console.WriteLine(person.Name + " - " + person.Age);
            }
        }
    }
}
