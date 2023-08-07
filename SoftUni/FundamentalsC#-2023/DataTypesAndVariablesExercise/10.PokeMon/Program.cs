using System;

namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            int distanceTargets = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int originalValuePower = pokemonPower;
            int tagetsCount = 0;

            while (pokemonPower >= distanceTargets)
            {
                pokemonPower -= distanceTargets;

                tagetsCount++;


                if (pokemonPower == (double)(originalValuePower * 0.5) && exhaustionFactor != 0)
                        pokemonPower /= exhaustionFactor;

            }

            Console.WriteLine(pokemonPower);
            Console.WriteLine(tagetsCount);
        }
    }
}
