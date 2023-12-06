namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            int[] coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int desiredSum = int.Parse(Console.ReadLine());

            try
            {
                Dictionary<int, int> coinsDic = ChooseCoins(coins, desiredSum);

                Console.WriteLine($"Number of coins to take: {coinsDic.Values.Sum()}");

                foreach (var coin in coinsDic)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            int[] sortedCoins = coins.OrderByDescending(x => x).ToArray();

            Dictionary<int, int> keyValuePairs = new();

            int currentSum = 0;
            int coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Length)
            {
                int currentCoinValue = sortedCoins[coinIndex];

                int remainder = targetSum - currentSum;

                int numberOfCoins = remainder / currentCoinValue;

                if (currentSum + currentCoinValue <= targetSum)
                {
                    if (!keyValuePairs.ContainsKey(currentCoinValue))
                    {
                        keyValuePairs.Add(currentCoinValue, numberOfCoins);
                    }

                    currentSum += currentCoinValue * numberOfCoins;
                }

                coinIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException();
            }

            return keyValuePairs;
        }
    }
}