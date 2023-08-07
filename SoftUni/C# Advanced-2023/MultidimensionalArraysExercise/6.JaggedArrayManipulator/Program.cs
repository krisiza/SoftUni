int rows = int.Parse(Console.ReadLine());

int[][] jagged = new int[rows][];

for (int i = 0; i < rows; i++)
{
    jagged[i] = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
}

Analyse(jagged);

string[] commands = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

while (commands[0] != "End")
{
    string command = commands[0];
    int row = int.Parse(commands[1]);
    int column = int.Parse(commands[2]);
    int value = int.Parse(commands[3]);

    switch (command)
    {
        case "Add":
            if (row >= 0 && row < jagged.Length && column >= 0 && column < jagged[row].Length)
                jagged[row][column] += value;
            break;
        case "Subtract":
            if (row >= 0 && row < jagged.Length && column >= 0 && column < jagged[row].Length)
                jagged[row][column] -= value;
            break;
    }

    commands = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
}

foreach (int[] row in jagged)
    Console.WriteLine(string.Join(" ", row));

static void Analyse(int[][] jagged)
{
    for (int row = 0; row < jagged.Length - 1; row++)
    {
        if (jagged[row].Length == jagged[row + 1].Length)
        {
            for (int col = 0; col < jagged[row].Length; col++)
            {
                jagged[row][col] *= 2;
                jagged[row + 1][col] *= 2;
            }
        }
        else
        {
            for (int col = 0; col < jagged[row].Length; col++)
            {
                jagged[row][col] /= 2;
            }
            for (int col = 0; col < jagged[row + 1].Length; col++)
            {
                jagged[row + 1][col] /= 2;
            }
        }
    }
}

