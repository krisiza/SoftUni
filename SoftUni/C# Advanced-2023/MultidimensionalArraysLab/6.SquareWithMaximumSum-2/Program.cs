/*
10, 20
7, 1, 3, 3, 2, 1, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
1, 3, 9, 8, 5, 6, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
4, 6, 7, 9, 1, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
7, 1, 3, 3, 2, 1, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
1, 3, 9, 0, 5, 6, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
4, 6, 0, 0, 1, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
4, 6, 7, 9, 1, 0, 0,  0,  0,  0,  0,  0,  0,  0,  100, 500,  0,  0,  0,  0
7, 1, 3, 3, 2, 1, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
1, 3, 9, 0, 5, 6, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
4, 6, 0, 0, 1, 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0
*/


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

int top = int.Parse(Console.ReadLine());
int left = int.Parse(Console.ReadLine());

int max = int.MinValue;
int sum = 0;
int[,] index = new int[top, left];

int rowEnd = matrix.GetLength(0) - (left-1);
int colEnd = matrix.GetLength(1) - (top-1);

for (int row = 0; row < rowEnd; row++)
{
    for (int col = 0; col <colEnd; col++)
    {
        sum = 0;


        for(int i = 0; i < index.GetLength(0); i++) 
        {
            for(int j = 0; j < index.GetLength(1); j++) 
            {
                sum += matrix[i+row, j+col];
            }
        }


        if (sum > max)
        {
            for (int i = 0; i < index.GetLength(0); i++)
            {
                for (int j = 0; j < index.GetLength(1); j++)
                {
                    index[i, j] = matrix[i+row, j+col];
                }
            }
            max = sum;
        }
    }

}
for (int i = 0; i < index.GetLength(0); i++)
{
    for (int j = 0; j < index.GetLength(1); j++)
    {
        Console.Write(index[i, j] + " "); 
    }
    Console.WriteLine();
}
Console.WriteLine(max);
