int rows = int.Parse(Console.ReadLine());

long[][] jagged = new long[rows][];

int currentWidth = 1;

for(long row = 0; row < rows; row++)
{
    jagged[row] = new long[currentWidth];
    long[] currentRow = jagged[row];
    currentRow[0] = 1;
    currentRow[currentRow.Length - 1] = 1;
    currentWidth++;

    if (currentRow.Length > 2)
    {
        for (int i = 1; i < currentRow.Length - 1; i++)
        {
            long[] previousRow = jagged[row - 1];
            long prevoiousRowSum = previousRow[i] + previousRow[i - 1];
            currentRow[i] = prevoiousRowSum;
        }
    }
}

foreach (long[] row in jagged)
    Console.WriteLine(string.Join(" ", row));
