using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> player1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> player2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (player1.Count > 0 && player2.Count > 0)
            {

                if (player1[0] > player2[0])
                {
                    player1.Add(player2[0]);
                    player2.Remove(player2[0]);
                    int temp = player1[0];
                    for (int j = 0; j < player1.Count - 1; j++)
                    {
                        player1[j] = player1[j + 1];
                    }
                    player1[player1.Count - 1] = temp;
                }
                else if (player1[0] < player2[0])
                {
                    player2.Add(player1[0]);
                    player1.Remove(player1[0]);
                    int temp = player2[0];
                    for (int j = 0; j < player2.Count - 1; j++)
                    {
                        player2[j] = player2[j + 1];
                    }
                    player2[player2.Count - 1] = temp;
                }
                else
                {
                    player1.Remove(player1[0]);
                    player2.Remove(player2[0]);
                }

            }
            if (player1.Count == 0)
                Console.WriteLine($"Second player wins! Sum: {player2.ToArray().Sum()}");
            else
                Console.WriteLine($"First player wins! Sum: {player1.ToArray().Sum()}");
        }
    }
}
