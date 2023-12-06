namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new(new List<string>());

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Create")
                {
                    listyIterator = new(tokens[1..].ToList());
                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else
                {
                    listyIterator.Print();
                }

                command = Console.ReadLine();
            }
        }
    }
}