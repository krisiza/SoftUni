namespace _2.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            List<int> numbers = new List<int>();

            while (numbers.Count < 10)
            {
                try
                {
                    int number = ReadNumber(start, end);
                    numbers.Add(number);
                    start = number;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
        public static int ReadNumber(int start, int end)
        {
            int number = 0;

            number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException($"Your number is not in range {start} - 100!");
            }

            return number;
        }
    }
}