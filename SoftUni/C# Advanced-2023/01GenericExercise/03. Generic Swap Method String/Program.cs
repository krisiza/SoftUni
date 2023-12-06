namespace _01GenericBoxofString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new();
            box.Values = new List<string>();

            for (int i = 0; i < n; i++)
            {
                box.Values.Add(Console.ReadLine());
            }

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse) 
                .ToArray();

            box.Swap(indexes[0], indexes[1]);

            foreach(var str in box.Values)
            {
                Console.WriteLine($"{box.ToString()}: {str}");
            }
        }
    }
}