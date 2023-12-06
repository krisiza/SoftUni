namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if(number < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ParamName);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}