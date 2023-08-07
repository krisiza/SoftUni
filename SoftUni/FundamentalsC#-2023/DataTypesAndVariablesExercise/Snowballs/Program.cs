using System;
using System.Numerics;

namespace Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberSnowballs = int.Parse(Console.ReadLine());

            int snowballSnowMax = 0;
            int snowballTimeMax = 0;
            int snowballQualityMax = 0;
            BigInteger highestSnowballValue = 0;

            for (int i = 0; i < numberSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

               BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballValue = snowballValue;
                    snowballQualityMax = snowballQuality;
                    snowballSnowMax = snowballSnow;
                    snowballTimeMax= snowballTime;
                }
            }

            Console.WriteLine($"{snowballSnowMax} : {snowballTimeMax} = {highestSnowballValue} ({snowballQualityMax})");
        }
    }
}
