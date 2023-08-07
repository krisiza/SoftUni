int[] matrixSize = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[matrixSize[0], matrixSize[1]];

FullArray(matrix);

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));

int sum = 0;
foreach (int i in matrix)
{
    sum += i;
}
    
Console.WriteLine(sum);
void FullArray(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        int[] colElements = Console.ReadLine()
        .Split(", ")
        .Select(int.Parse)
        .ToArray();

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = colElements[col];
        }
    }
}




