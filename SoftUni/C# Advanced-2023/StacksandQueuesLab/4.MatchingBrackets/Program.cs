string input = Console.ReadLine();

Stack<char> stack = new Stack<char>(input.Reverse());
Stack<int> indexes = new Stack<int>();
for (int i = 0; i < stack.Count; i++)
{
    char currentChar = input[i];

    if (currentChar == '(')
    {
        indexes.Push(i);

    }
    else if (currentChar == ')')
    {
        int index = indexes.Pop();

        for (int j = index; j <= i; j++)
        {
            Console.Write(input[j]);
        }
        Console.WriteLine();
    }
}

