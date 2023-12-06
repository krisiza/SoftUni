namespace _01GenericBoxofString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<int> box = new();
            box.Values = new List<int>();

            for (int i = 0; i < n; i++)
            {
                box.Values.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse) 
                .ToArray();

            box.Swap(indexes[0], indexes[1]);

            foreach(var intiger in box.Values)
            {
                Console.WriteLine($"{box.ToString()}: {intiger}");
            }
        }
    }
}