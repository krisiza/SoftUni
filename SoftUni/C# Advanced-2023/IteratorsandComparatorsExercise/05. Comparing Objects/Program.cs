namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person
                {
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    Town = tokens[2]
                };


                people.Add(person);

                command = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            n--;

            int countOfMatches = 0;
            int countOfNotEquealPeople = 0;

            Person personToMatch = people[n];

            for (int i = 0; i < people.Count; i++)
            {

                if (personToMatch.CompareTo(people[i]) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEquealPeople++;
                }
            }

            if (countOfMatches == 1)
                Console.WriteLine("No matches");
            else
                Console.WriteLine($"{countOfMatches} {countOfNotEquealPeople} {people.Count}");

        }
    }
}