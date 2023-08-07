using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderbyAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
            List<Person> people = new List<Person>();   
            while (input != "End") 
            {
                string[] arr = input.Split();

                string personName = arr[0];
                string perosonId = arr[1];
                int perosonAge = int.Parse(arr[2]);

                Person person = new Person(personName, perosonId, perosonAge);

                var found = people.Find(x => x.ID == person.ID);
                if(found != null) 
                {
                    found.Age = perosonAge;
                    found.Name = personName;
                }

                people.Add(person);

                input = Console.ReadLine();
            }

            List<Person> orderedList = people.OrderBy(x => x.Age).ToList();

           orderedList.ForEach(x => { Console.WriteLine($"{x.Name} with ID: {x.ID} is {x.Age} years old."); });
        }
    }
    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }    
        public string ID { get; set; }
        public int Age { get; set; }



    }
}
