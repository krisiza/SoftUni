int rows = int.Parse(Console.ReadLine());
int columns = int.Parse(Console.ReadLine());

List<int> numbers = new List<int>();
int[] array = new int[columns * rows];

for (int i = 0; i < rows; i++)
{
    array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    foreach (int ar in array) numbers.Add(ar);
}


int indexStart = 0;
int indexEnd = columns;
int index = 0;

int counter = 0;

for (int row = 0; counter <= numbers.Count - 1; row++)
{

    for (int i = indexStart + row; i < (indexEnd - row) - 1; i++)
    {
        Console.Write(numbers[i] + " ");
        counter++;

        if (counter > numbers.Count - 1)
            return;
    }

    for (int i = indexEnd - row - 1; i < numbers.Count - indexStart - row; i += columns)
    {
        Console.Write(numbers[i] + " ");
        counter++;

        if (counter > numbers.Count - 1)
            return;
    }

    for (int i = numbers.Count - indexStart - row - 2; i >= numbers.Count - indexEnd - row  + index; i--)
    {
        Console.Write(numbers[i] + " ");
        counter++;

        if (counter > numbers.Count - 1)
            return;
    }

    for (int i = numbers.Count - indexEnd - row + index - columns; i >= (columns + row) + index; i -= columns)
    {
        Console.Write(numbers[i] + " ");
        counter++;

        if (counter > numbers.Count - 1)
            return;
    }


    indexStart += columns;
    indexEnd += columns;
    index += 2;
}