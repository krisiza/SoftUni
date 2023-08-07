int[] size = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] matrix = new char[size[0], size[1]];

for (int row = 0; row < size[0]; row++)
{
    string colArr = Console.ReadLine();

    for (int col = 0; col < size[1]; col++)
    {
        matrix[row, col] = colArr[col];
    }
}

bool gOver = false;

Player player = new(0, 0);
player = FindPlayer(matrix);

List<Bunny> bunneis = new List<Bunny>();
bunneis = FindBunnis(matrix);

string commands = Console.ReadLine();

for (int i = 0; i < commands.Length; i++)
{
    switch (commands[i])
    {
        case 'U':
            matrix[player.Row, player.Col] = '.';
            player.Row--;
            break;
        case 'D':
            matrix[player.Row, player.Col] = '.';
            player.Row++;
            break;
        case 'L':
            matrix[player.Row, player.Col] = '.';
            player.Col--;
            break;
        case 'R':
            matrix[player.Row, player.Col] = '.';
            player.Col++;
            break;
    }

    SpreadBunnies(matrix, bunneis, player, gOver);
    bunneis = FindBunnis(matrix);
    ;
    if (PlayerWon(matrix, player,gOver))
    {
        ShowMatrix(matrix);
        Console.WriteLine($"won: {player.Row} {player.Col}");
        return;
    }

    if (PlayerDied(matrix, player, bunneis) || gOver)
    {
        ShowMatrix(matrix);
        Console.WriteLine($"dead: {player.Row} {player.Col}");
        return;
    }
}

void SpreadBunnies(char[,] matrix, List<Bunny> bunnis, Player player, bool gOver)
{
    for (int i = 0; i < bunnis.Count; i++)
    {
        int row = bunnis[i].Row;
        int col = bunnis[i].Col;
        row++;
        if (row < matrix.GetLength(0) && row >= 0)
        {
            //!
            if (matrix[row, col] == 'P')
            {
                gOver= true;
                return;
            }
            else
            {
                matrix[row, col] = 'B';
            }
        }
        row = bunnis[i].Row;
        row--;
        if (row < matrix.GetLength(0) && row >= 0)
        {
            //!
            if (matrix[row, col] == 'P')
            {
                gOver = true;
                return;
            }
            else
            {
                matrix[row, col] = 'B';
            }
        }
        row = bunnis[i].Row;
        col = bunnis[i].Col;
        col++;
        if (col < matrix.GetLength(1) && col >= 0)
        {
            //!
            if (matrix[row, col] == 'P')
            {
                gOver = true;
                return;
            }
            else
            {
                matrix[row, col] = 'B';
            }
        }
        col = bunnis[i].Col;
        col--;
        if (col < matrix.GetLength(1) && col >= 0)
        {
            //!
            if (matrix[row, col] == 'P')
            {
                gOver = true;
                return;
            }
            else
            {
                matrix[row, col] = 'B';
            }
        }
    }
}
Player FindPlayer(char[,] matrix)
{
    Player player = new(0, 0);
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'P')
            {
                player.Row = row;
                player.Col = col;
                return player;
            }
        }
    }
    return player;
}
List<Bunny> FindBunnis(char[,] matrix)
{
    List<Bunny> bunnies = new List<Bunny>();
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == 'B')
            {
                Bunny bunny = new(0, 0);
                bunny.Row = row;
                bunny.Col = col;

                bunnies.Add(bunny);
            }
        }
    }
    return bunnies;
}
bool PlayerWon(char[,] matrix, Player player,bool gameOver)
{
    if (player.Row >= matrix.GetLength(0))
    {
        player.Row = matrix.GetLength(0) - 1;
        return true;
    }
    else if (player.Row < 0)
    {
        player.Row = 0;
        return true;
    }
    else if (player.Col >= matrix.GetLength(1))
    {
        player.Col = matrix.GetLength(1) - 1;
        return true;
    }
    else if (player.Col < 0)
    {
        player.Col = 0;
        return true;
    }
    else
    {
        if (matrix[player.Row, player.Col] == '.')
        {
            matrix[player.Row, player.Col] = 'P';
            return false;
        }
        else
        {
            gameOver = true;
            return false;
        }
    }
}
bool PlayerDied(char[,] matrix, Player player, List<Bunny> bunnis)
{
    if (matrix[player.Row, player.Col] == 'B')
        return true;

    return false;
}
void ShowMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }

        Console.WriteLine();
    }
}
class Player
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Player(int row, int col)
    {
        Row = row;
        Col = col;
    }
} 
class Bunny
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Bunny(int row, int col)
    {
        Row = row;
        Col = col;
    }
}
