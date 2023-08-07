string[] input = Console.ReadLine()
    .Split();

Stack<string> stack = new Stack<string>(input.Reverse());

int result = int.Parse(stack.Pop());

while(stack.Any())
{
    string operation = stack.Pop();
    int number = int.Parse(stack.Pop());

    if (operation == "+")
        result += number;
    else
        result -= number;
}

Console.WriteLine(result);
