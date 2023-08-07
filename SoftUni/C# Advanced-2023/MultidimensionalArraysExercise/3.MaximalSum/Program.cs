int[] size = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[size[0], size[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] colArr = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = colArr[col];
    }
}

int[,] matrixMax = new int[3, 3];
int max = int.MinValue;

for (int row = 0; row < matrix.GetLength(0) - 2; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
    {
        int sum = 0;

        for (int i = 0; i < matrixMax.GetLength(0); i++)
        {
            for (int j = 0; j < matrixMax.GetLength(1); j++)
            {
                sum += matrix[i + row, j + col];
            }
        }

        if (sum > max)
        {
            for (int i = 0; i < matrixMax.GetLength(0); i++)
            {
                for (int j = 0; j < matrixMax.GetLength(1); j++)
                {
                    matrixMax[i, j] = matrix[i + row, j + col];
                }
            }

            max = sum;
        }
    }
}

Console.WriteLine($"Sum = {max}");

for (int i = 0; i < matrixMax.GetLength(0); i++)
{
    for (int j = 0; j < matrixMax.GetLength(1); j++)
    {
        Console.Write(matrixMax[i, j] + " ");
    }
    Console.WriteLine();
}


