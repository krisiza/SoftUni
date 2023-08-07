int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size,size];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string text = Console.ReadLine();

    char[] colArr = text.ToCharArray();

    for(int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row,col] = colArr[col];
    }
}

char c = char.Parse(Console.ReadLine());

for(int row = 0; row < matrix.GetLength(0); row++)
{
    for(int col = 0; col < matrix.GetLength(1); col++ )
    {
        if (matrix[row,col] == c)
        {
            Console.WriteLine($"({row}, {col})");
            return;
        }
    }
}

Console.WriteLine($"{c} does not occur in the matrix");
