namespace _01GenericBoxofString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i =0; i < n; i++) 
            {
                Box<int> box = new();
                box.TProperty = int.Parse(Console.ReadLine());
                Console.WriteLine($"{box.ToString()}: {box.TProperty}");
            }
        }
    }
}