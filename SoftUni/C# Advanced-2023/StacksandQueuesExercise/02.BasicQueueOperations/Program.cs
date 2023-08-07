namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new(elements);

            for (int i = 0; i < n[1]; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Count == 0)
                Console.WriteLine(0);
            else if (numbers.Contains(n[2]))
                Console.WriteLine("true");
            else
                Console.WriteLine(numbers.Min());
        }
    }
}