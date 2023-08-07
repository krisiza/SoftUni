int rows = int.Parse(Console.ReadLine());

int[][] jagged = new int[rows][];

for(int i = 0; i < jagged.Length;i++)
{
    int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();

    jagged[i] = col;
}

string[] commands = Console.ReadLine().Split();

while (commands[0] != "END")
{
    string command = commands[0];
    int row = int.Parse(commands[1]);
    int col = int.Parse(commands[2]);
    int value = int.Parse(commands[3]);

    switch(command)
    {
        case "Add":
            if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                jagged[row][col] += value;
            else
                Console.WriteLine("Invalid coordinates");
            break;
        case "Subtract":
            if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                jagged[row][col] -= value;
            else
                Console.WriteLine("Invalid coordinates");
            break;
    }

    commands = Console.ReadLine().Split();
}

foreach (int[] row in jagged)
    Console.WriteLine(string.Join(" ", row));
