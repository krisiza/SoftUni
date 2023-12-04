using System.Linq;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dic = new();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dic.ContainsKey(input[i]))
                    dic.Add(input[i], 0);

                dic[input[i]]++;
            }

            foreach (var s in dic)
            {
                Console.WriteLine($"{s.Key}: {s.Value} time/s");
            }     
        }
    }
}