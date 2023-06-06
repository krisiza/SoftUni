using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonSequence = Console.In.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (pokemonSequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int pokemonValue = 0;

                if (index >= 0 && index < pokemonSequence.Count)
                {
                    pokemonValue = pokemonSequence[index];
                    sum += pokemonValue;
                    pokemonSequence.RemoveAt(index);
                    IncreaseDecrease(pokemonSequence, index, pokemonValue);
                }
                else if (index < 0)
                {
                    index = 0;
                    pokemonValue = pokemonSequence[index];
                    sum += pokemonValue;
                    pokemonSequence[index] = pokemonSequence[pokemonSequence.Count - 1];
                    IncreaseDecrease(pokemonSequence, index, pokemonValue);
                }
                else
                {
                    index = pokemonSequence.Count - 1;
                    pokemonValue = pokemonSequence[index];
                    sum += pokemonValue;
                    pokemonSequence[index] = pokemonSequence[0];
                    IncreaseDecrease(pokemonSequence, index, pokemonValue);
                }
            }
            Console.WriteLine(sum);
        }
        static void IncreaseDecrease(List<int> sequence, int index, int value)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] <= value)
                    sequence[i] += value;
                else
                    sequence[i] -= value;
            }
        }
    }
}
