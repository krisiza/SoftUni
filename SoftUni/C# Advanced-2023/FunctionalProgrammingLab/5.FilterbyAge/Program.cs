using System.Transactions;

namespace _5.FilterbyAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person();
                person.Name = personInfo[0];
                person.Age = int.Parse(personInfo[1]);

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();


            people = people.Where(Filter(condition, age)).ToList();

            Action<Person> filter = GerPrinter(format);

            foreach (var p in people)
            {
                filter(p);
            }

        }

        static Func<Person, bool> Filter(string condition, int age)
        {
            if (condition == "older")
                return person => person.Age >= age;
            else
                return person => person.Age < age;
        }
        static Action<Person> GerPrinter(string formatType)
        {
            switch (formatType)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                case "age":
                    return p => Console.WriteLine($"{p.Age}");
                case "name":
                    return p => Console.WriteLine($"{p.Name}");
                default:
                    return null;

            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}