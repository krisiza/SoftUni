int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

char[,]matrix = new char[size[0], size[1]];

for(int row = 0; row < matrix.GetLength(0); row++)
{
    char[] con = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

    for(int col = 0; col < matrix.GetLength(1);col++)
    {
        matrix[row,col] = con[col];
    }
}

int counter = 0;
char currentChar;

for(int row = 0;row < matrix.GetLength(0)-1; row++)
{
    for(int col = 0; col < matrix.GetLength(1)-1; col++)
    {
        currentChar= matrix[row,col];

        if (currentChar == matrix[row, col + 1] &&
            currentChar == matrix[row + 1, col] &&
            currentChar == matrix[row + 1, col + 1])
        {
            counter++;
        }
    }
}
Console.WriteLine(counter);
