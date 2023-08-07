int[] size = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int[,] matrix = new int[size[0], size[1]];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] colArr = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = colArr[col];
    }
}

int max = int.MinValue;
int sum = 0;
int[,] index = new int[2,2];

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        sum = 0;

        sum += matrix[row, col];
        sum += matrix[row + 1, col];
        sum += matrix[row, col + 1];
        sum += matrix[row + 1, col + 1];

        if (sum > max)
        {
            index[0,0] = matrix[row, col];
            index[0, 1] = matrix[row+1, col];
            index[1, 0] = matrix[row, col+1];
            index[1, 1] = matrix[row+1, col+1];
            max = sum;
        }
    }

}
Console.WriteLine($"{index[0, 0]} {index[1,0]}");
Console.WriteLine($"{index[0, 1]} {index[1, 1]}");
Console.WriteLine(max);
