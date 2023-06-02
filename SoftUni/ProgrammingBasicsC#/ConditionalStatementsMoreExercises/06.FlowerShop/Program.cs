using System;

namespace _06.FlowerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mon = int.Parse(Console.ReadLine());
            int zum = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int cac = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double sum = (mon * 3.25) + (zum * 4) + (rose * 3.5) + (cac * 8);
            double tax = (5 * sum) / 100;
            double winn = sum - tax;

            if (winn < giftPrice)
            {
                double rest = Math.Ceiling(giftPrice - winn);
                Console.WriteLine($"She will have to borrow {Math.Abs(rest)} leva.");
            }
            else if (winn >= rose)
            {
                int rest = (int)(giftPrice - winn);
                Console.WriteLine($"She is left with {Math.Abs(rest)} leva.");
            }
        }
    }
}
