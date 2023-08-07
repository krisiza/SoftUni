using System;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());


            int headsetTrashes = 0;
            int mouseTrashes = 0;
            int keyboardTrashes = 0;
            int displayTrashes = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                    headsetTrashes++;

                if (i % 3 == 0)
                    mouseTrashes++;

                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardTrashes++;

                    if (keyboardTrashes != 0 && keyboardTrashes % 2 == 0)
                        displayTrashes++;
                }

            }

            double sumPrice = (headsetPrice * headsetTrashes) + (mousePrice * mouseTrashes) + (keyboardPrice * keyboardTrashes) + (displayPrice * displayTrashes);

            Console.WriteLine($"Rage expenses: {sumPrice:f2} lv.");
        }
    }
}
