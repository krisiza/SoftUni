namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int nubersOfSets = int.Parse(Console.ReadLine());

            int[][] jagged = new int[nubersOfSets][];

            for (int row = 0; row < nubersOfSets; row++)
            {
                int[] arr = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagged[row] = arr;
            }

            List<int[]> jaggedList = ChooseSets(jagged, universe);

            Console.WriteLine($"Sets to take ({jaggedList.Count}):");

            foreach (int[] arr in jaggedList)
            {
                Console.WriteLine($"{{ {string.Join(", ", arr)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();

            while(universe.Count > 0) 
            {
                int[] longestSet = sets.OrderByDescending(s => s.Count(x => universe.Contains(x)))
                    .FirstOrDefault();

                List<int> un = universe.ToList();

                un.RemoveAll(x => longestSet.Contains(x));

                universe = un;

                selectedSets.Add(longestSet);
            }

           return selectedSets;
        }
    }
}
