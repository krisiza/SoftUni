int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];

List<string> commands = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .ToList();

for (int row = 0; row < matrix.GetLength(0); row++)
{
    char[] colArr = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = colArr[col];
    }
}

Miner miner = new(0, 0);

miner = FindStartPosition(matrix);
int coals = CoalsCount(matrix);
bool allCoalsFound = false;
bool gameOver = false;

for (int i = 0; i < commands.Count; i++)
{
    switch (commands[i])
    {
        case "left":
            if (miner.Col > 0)
                miner.Col--;
            CheckPosition(matrix, miner, gameOver, 'c', 'e');
            break;
        case "right":
            if (miner.Col < matrix.GetLength(1) - 1)
                miner.Col++;
            CheckPosition(matrix, miner, gameOver, 'c', 'e');
            break;
        case "down":
            if (miner.Row < matrix.GetLength(0) - 1)
                miner.Row++;
            CheckPosition(matrix, miner, gameOver, 'c', 'e');
            break;
        case "up":
            if (miner.Row > 0)
                miner.Row--;
            CheckPosition(matrix, miner, gameOver, 'c', 'e');
            break;
    }

    if (coals == 0)
    {
        Console.WriteLine($"You collected all coals! ({miner.Row}, {miner.Col})");
        allCoalsFound = true;
        return;
    }

    if (gameOver)
        return;
}

if (!allCoalsFound)
{
    Console.WriteLine($"{coals} coals left. ({miner.Row}, {miner.Col})");
}

void CheckPosition(char[,] matrix, Miner miner, bool gOver, char v1, char v2)
{
    if (OnChar(matrix, miner, v1))
    {
        matrix[miner.Row, miner.Col] = '*';
        coals--;
    }
    else if (OnChar(matrix, miner, v2))
    {
        Console.WriteLine($"Game over! ({miner.Row}, {miner.Col})");
        gameOver = true;
    }
}
int CoalsCount(char[,] matrix)
{
    int counter = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'c')
                counter++;
        }
    }

    return counter;
}
bool OnChar(char[,] matrix, Miner miner, char c)
{
    if (matrix[miner.Row, miner.Col] == c)
        return true;
    else
        return false;
}
Miner FindStartPosition(char[,] matrix)
{
    Miner miner1 = new(0, 0);
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 's')
            {
                miner.Col = col;
                miner.Row = row;
                return miner;
            }
        }
    }
    return miner;
}
class Miner
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Miner(int row, int col)
    {
        Row = row;
        Col = col;
    }
}
