namespace ListyIterator
{
    internal class Program
    {
        /*
4
Peter 20
Petter 20
George 15
Peter 21
        */
        static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new HashSet<Person>();
            SortedSet<Person> peopleSortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person()
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1])
                };

                    peopleHashSet.Add(person);
                    peopleSortedSet.Add(person);
            }

            Console.WriteLine(peopleSortedSet.Count);
            Console.WriteLine(peopleHashSet.Count);
        }
    }
}