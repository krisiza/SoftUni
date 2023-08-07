int[] size = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char[size[0], size[1]];

string snake = Console.ReadLine();

int i = 0;

for (int row = 0; row < size[0]; row++)
{

    if (row % 2 == 0)
    {
        for (int col = 0; col < size[1]; col++)
        {
            matrix[row, col] = snake[i];
            i++;
            if (i == snake.Length)
                i = 0;
        }
    }
    else
    {
        for (int col = size[1] - 1; col >= 0; col--)
        {
            matrix[row, col] = snake[i];
            i++;
            if (i == snake.Length)
                i = 0;
        }
    }
}

for(int k = 0; k < size[0];k++)
{
    for(int j = 0; j < size[1]; j++)
    {
        Console.Write(matrix[k, j]);
    }
    Console.WriteLine();
}

