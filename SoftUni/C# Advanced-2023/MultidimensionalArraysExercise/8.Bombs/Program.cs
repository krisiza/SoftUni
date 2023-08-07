using System.Collections.Generic;

int size = int.Parse(Console.ReadLine());

int[,] matrix = new int[size, size];

for (int row = 0; row < size; row++)
{
    int[] colArr = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = colArr[col];
    }
}

string[] boombCoordinates = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

int[] boombs;

List<Boomb> boomsbList = new();

for (int i = 0; i < boombCoordinates.Length; i++)
{
    boombs = boombCoordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    int row = boombs[0];
    int col = boombs[1];

    Boomb boomb = new(row, col);
    boomsbList.Add(boomb);

    int explosion = matrix[row, col];

    if (explosion <= 0)
        continue;

    matrix[row, col] = 0;

    row--;

    if (row >= 0)
    {
        col--;

        for (int j = 0; j < 3 && col < matrix.GetLength(1); j++)
        {
            if (col < 0)
            {
                col++;
                continue;
            }
            else if (col >= matrix.GetLength(1))
            {
                col--;
                continue;
            }
            else
            {
                var foundObject = boomsbList.FirstOrDefault(x => x.Row == row && x.Col == col);

                if (foundObject == default)
                {
                    int cell = matrix[row, col];

                    if (cell <= 0)
                    {
                        col++;
                        continue;
                    }

                    matrix[row, col] -= explosion;
                }
                col++;
            }
        }
    }

    col = boomb.Col + 1;
    row = boomb.Row;
    if (col >= 0)
    {


        if (col < matrix.GetLength(1))
        {
            for (int j = 0; j < 2 && row < matrix.GetLength(0); j++)
            {
                if (row < 0)
                {
                    row++;
                    continue;
                }
                else if (row >= matrix.GetLength(0))
                {
                    continue;
                }
                else
                {
                    var foundObject = boomsbList.FirstOrDefault(x => x.Row == row && x.Col == col);

                    if (foundObject == default)
                    {
                        int cell = matrix[row, col];

                        if (cell <= 0)
                        {
                            row++;
                            continue;
                        }

                        matrix[row, col] -= explosion;
                    }
                    row++;
                }
            }
        }
    }
    col = boomb.Col;
    row = boomb.Row + 1;
    if (row >= 0 && row < matrix.GetLength(0))
    {

        for (int j = 0; j < 2 && matrix.GetLength(1) >= 0; j++)
        {
            if (col >= matrix.GetLength(1))
            {
                col--;
                continue;
            }
            else if (col < 0)
            {
                col++;
                continue;
            }
            else
            {
                var foundObject = boomsbList.FirstOrDefault(x => x.Row == row && x.Col == col);

                if (foundObject == default)
                {
                    int cell = matrix[row, col];

                    if (cell <= 0)
                    {
                        col--;
                        continue;
                    }

                    matrix[row, col] -= explosion;
                }
                col--;
            }
        }
    }

    col = boomb.Col - 1;
    row = boomb.Row;

    if (row >= 0 && col < matrix.GetLength(1) && col >= 0)
    {
        var foundObject = boomsbList.FirstOrDefault(x => x.Row == row && x.Col == col);

        if (foundObject == default)
        {
            int cell = matrix[row, col];

            if (cell <= 0)
                continue;

            matrix[row, col] -= explosion;
        }
    }

}

List<int> aliveCells = new List<int>();

foreach (var cell in matrix)
{
    if (cell > 0)
        aliveCells.Add(cell);
}

Console.WriteLine($"Alive cells: {aliveCells.Count}");
Console.WriteLine($"Sum: {aliveCells.Sum()}");

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}


class Boomb
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Boomb(int row, int col)
    {
        Row = row;
        Col = col;
    }
}
