namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!dic.ContainsKey(number))
                    dic.Add(number, 0);

                dic[number]++;
            }

            int result = dic.Single(nc => nc.Value % 2 == 0).Key;

            Console.WriteLine(result);
        }
    }
}