namespace _6.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];

                if (!clothes.ContainsKey(color))
                    clothes.Add(color, new Dictionary<string, int>());

                for (int j = 1; j < tokens.Length; j++)
                {
                    if (!clothes[color].ContainsKey(tokens[j]))
                    {
                        clothes[color].Add(tokens[j], 0);
                    }

                    clothes[color][tokens[j]]++;
                }
            }

            string[] searchedItem = Console.ReadLine()
                .Split();

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (color.Key == searchedItem[0] && item.Key == searchedItem[1])
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    else
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}