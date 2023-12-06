namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            int exceptionsCount = 0;
            while (exceptionsCount < 3)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (commands[0] == "Replace")
                    {
                        int index = int.Parse(commands[1]);
                        int element = int.Parse(commands[2]);

                        numbers.RemoveAt(index);
                        numbers.Insert(index, element);
                    }
                    if (commands[0] == "Show")
                    {
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(numbers[index]);
                    }
                    if (commands[0] == "Print")
                    {
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        List<int> result = new List<int>();

                        for(int i = startIndex; i <= endIndex; i++) 
                        {
                            result.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", result));
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}