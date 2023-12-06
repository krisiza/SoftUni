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

            string element = Console.ReadLine();

            int counter = box.Compare(box.Values, element);

            Console.WriteLine(counter);

        }
    }
}