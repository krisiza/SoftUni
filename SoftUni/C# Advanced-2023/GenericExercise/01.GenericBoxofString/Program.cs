namespace _01GenericBoxofString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i =0; i < n; i++) 
            {
                Box<string> box = new Box<string>();
                box.TProperty = Console.ReadLine();
                Console.WriteLine($"{box.ToString()}: {box.TProperty}");
            }
        }
    }
}