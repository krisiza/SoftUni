namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElements = new ();

            for(int i =0; i < n; i++) 
            {
                string[] arr = Console.ReadLine()
                    .Split(' ');

                chemicalElements.UnionWith(arr);
            }

            Console.WriteLine(String.Join(" ", chemicalElements));
        }
    }
}