int n = int.Parse(Console.ReadLine());

Stack<int> stack = new();

for (int i = 0; i < n; i++)
{
    Queue<int> queue = new(Console.ReadLine()
        .Split()
        .Select(int.Parse));

    int command = queue.Dequeue();

    switch (command)
    {
        case 1:
            int element = queue.Dequeue();
            stack.Push(element);
            break;
        case 2:
            stack.Pop();
            break;
        case 3:
            if (stack.Any())
                Console.WriteLine(stack.Min());
            break;
        case 4:
            if (stack.Any())
                Console.WriteLine(stack.Max());
            break;
    }
}

Console.WriteLine(String.Join(", ", stack));