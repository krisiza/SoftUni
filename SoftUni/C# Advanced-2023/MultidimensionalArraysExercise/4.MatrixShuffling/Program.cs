var size = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(long.Parse)
    .ToArray();

string[,] matrix = new string[size[0], size[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    var colArr = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = colArr[col];
    }
}

while (true)
{
    string[] commands = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

    string command = commands[0];

    if (command == "END")
        break;

    bool legth = commands.Length != 5;
    bool swap = commands[0] != "swap";

    if (swap || legth)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    long row1 = long.Parse(commands[1]);
    long col1 = long.Parse(commands[2]);
    long row2= long.Parse(commands[3]);
    long col2 = long.Parse(commands[4]);


    if (row1 < 0 || row1 >= matrix.GetLength(0) || col1 < 0 || col1 >= matrix.GetLength(1)
        || row2 < 0 || row2 >= matrix.GetLength(0) || col2 < 0 || col2 >= matrix.GetLength(1))
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    (matrix[row2, col2], matrix[row1, col1]) = (matrix[row1, col1], matrix[row2, col2]);

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}

