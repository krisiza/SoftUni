int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Stack<int> stack = new Stack<int>(numbers);

string[] commands = Console.ReadLine()
    .Split();

while (commands[0].ToLower() != "end")
{
    switch(commands[0].ToLower())
    {
        case "add":
            stack.Push(int.Parse(commands[1]));
            stack.Push(int.Parse(commands[2]));
            break;
        case "remove":
            if (int.Parse(commands[1]) >= stack.Count)
                break;

            for(int i = 0; i < int.Parse(commands[1]);i++)
            {
                stack.Pop();
            }
            break;
    }

    commands = Console.ReadLine()
        .Split();
}

Console.WriteLine("Sum: " + stack.Sum());
