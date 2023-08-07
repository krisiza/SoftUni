int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size,size];

for(int roww = 0; roww < matrix.GetLength(0);roww++)
{
    int[] colArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

    for(int coll = 0; coll < matrix.GetLength(1); coll++)
    {
        matrix[roww,coll] = colArr[coll];
    }
}

int row = 0;
int col = 0;
int sumLeft = 0;
int sumRight = 0;

while(row < matrix.GetLength(0) && col < matrix.GetLength(1))
{
    sumRight += matrix[row,col];
    row++;
    col++;
}

row = 0;
col = matrix.GetLength(1)-1;

while (row >= 0 && col >= 0)
{
    sumLeft += matrix[row, col];
    row++;
    col--;
}

Console.WriteLine(Math.Abs(sumRight-sumLeft));

