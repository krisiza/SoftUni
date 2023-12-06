namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new();

            foreach (int number in numbers) 
            {
                Stone stone = new();
                stone.Number= number;

                lake.Add(stone);
            }

            Console.WriteLine(string.Join(", ", lake.ToArray()));  

        }
    }
}