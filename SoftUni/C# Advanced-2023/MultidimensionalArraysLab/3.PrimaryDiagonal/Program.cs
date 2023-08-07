int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] colArr = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = colArr[col];
    }
}

int sumDiagonal = 0;
int roww = 0;
int coll = 0;

while (roww < matrix.GetLength(1) && coll < matrix.GetLength(0)) 
{
    sumDiagonal += matrix[roww, coll];

    roww++;
    coll++;
}

Console.WriteLine(sumDiagonal);
