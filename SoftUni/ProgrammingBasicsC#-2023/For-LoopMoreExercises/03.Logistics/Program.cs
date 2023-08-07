using System;

namespace _03.Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double price = 0;
            double goods1 = 0;
            double goods2 = 0;
            double goods3 = 0;
            double goodsSum = 0;
            for (int i = 0; i < input; i++)
            {
                int t = int.Parse(Console.ReadLine());

                if (t <= 3)
                {
                    price = 200;
                    goods1 += t;
                }
                if (t >= 4 && t <= 11)
                {
                    price = 175;
                    goods2 += t;
                }
                if (t >= 12)
                {
                    price = 120;
                    goods3 += t;
                }

                goodsSum += t;
            }

            Console.WriteLine($"{((goods1 * 200 + goods2 * 175 + goods3 * 120) / goodsSum):F2}");
            Console.WriteLine($"{(goods1 / goodsSum * 100):F2}%");
            Console.WriteLine($"{(goods2 / goodsSum * 100):F2}%");
            Console.WriteLine($"{(goods3 / goodsSum * 100):F2}%");
        }
    }
}
