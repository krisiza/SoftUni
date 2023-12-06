namespace _2.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factiorial(n));
        }
        public static int Factiorial(int n)
        {
            if(n == 0)
            {
                return 1;
            }

            return n * Factiorial(--n);
        }
    }
}