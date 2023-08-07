int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];

for (int row = 0; row < size; row++)
{
    string input = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = input[col];
    }
}

List<Knight> knights = new List<Knight>();

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Knight knight = new Knight(row, col, 0, matrix[row, col]);
        knights.Add(knight);
    }
}

int removedKnights = 0;

while (true)
{
    knights = FindKnight(matrix, removedKnights, knights);

    int maxCounter = knights.Max(x => x.Counter);
    
    if (maxCounter == 0)
        break;

    var foundObject = knights.FirstOrDefault(x => x.Counter == maxCounter);

    if (foundObject != default)
    {
        foundObject.C = '0';
        removedKnights++;

        for (int i = 0; i < knights.Count; i++)
        {
            knights[i].Counter = 0;
        }

        int k = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = knights[k].C;
                k++;
            }
        }
        
    }
}

Console.WriteLine(removedKnights);

static List<Knight> FindKnight(char[,] matrix, int counter, List<Knight> knights)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row,col] == 'K')
            {
                //MoveHorizontallyRightDown
                int indexC = ChangeIndexCol('+', 2, col);
                int indexR = ChangeIndexRow('+', 1, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row== row && x.Col == col);
                    foundsObject.Counter++;
                }

                //MoveHorizontallyLeftDown
                indexC = ChangeIndexCol('-', 2, col);
                indexR = ChangeIndexRow('+', 1, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                }

                //MoveHorizontallyRightUp
                indexC = ChangeIndexCol('+', 2, col);
                indexR = ChangeIndexRow('-', 1, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                }

                //MoveHorizontallyLeftUp
                indexC = ChangeIndexCol('-', 2, col);
                indexR = ChangeIndexRow('-', 1, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                }

                //MoveDiagonallyLeftUp
                indexC = ChangeIndexCol('-', 1, col);
                indexR = ChangeIndexRow('-', 2, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                }

                //MoveDiagonallyRightUp
                indexC = ChangeIndexCol('+', 1, col);
                indexR = ChangeIndexRow('-', 2, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                }

                //MoveDiagonallyLeftDown
                indexC = ChangeIndexCol('-', 1, col);
                indexR = ChangeIndexRow('+', 2, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                };

                //MoveDiagonallyRightDown
                indexC = ChangeIndexCol('+', 1, col);
                indexR = ChangeIndexRow('+', 2, row);

                if (HittingAnotherKnight(matrix, indexC, indexR))
                {
                    var foundsObject = knights.FirstOrDefault(x => x.Row == row && x.Col == col);
                    foundsObject.Counter++;
                }
            }
        }

    }
    return knights;
}
static int ChangeIndexCol(char opCol, int colIndexOp, int col)
{
    int indexC = 0;
    if (opCol == '-')
        indexC = col - colIndexOp;
    else
        indexC = col + colIndexOp;

    return indexC;
}
static int ChangeIndexRow(char opRow, int rowIndexOp, int row)
{
    int indexR = 0;

    if (opRow == '-')
        indexR = row - rowIndexOp;
    else
        indexR = row + rowIndexOp;

    return indexR;
}
static bool HittingAnotherKnight(char[,] matrix, int indexC, int indexR)
{
    if (indexR < matrix.GetLength(0) && indexR >= 0
                        && indexC < matrix.GetLength(1) && indexC >= 0)
    {
        char position = matrix[indexR, indexC];

        if (position == 'K')
        {
            return true;
        }
    }
    return false;
}
public class Knight
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Counter { get; set; }
    public char C { get; set; }

    public Knight(int row, int col, int counter, char c)
    {
        Row = row;
        Col = col;
        Counter = counter;
        C = c;
    }
}
