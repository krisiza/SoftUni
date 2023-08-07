int[] matrixSize = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[matrixSize[0], matrixSize[1]];

FullArray(matrix);

for (int col = 0; col < matrix.GetLength(1); col++)
{
    int sumCol = 0;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        sumCol += matrix[row, col];
    }

    Console.WriteLine(sumCol);
}

void FullArray(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        int[] colElements = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = colElements[col];
        }
    }
}
