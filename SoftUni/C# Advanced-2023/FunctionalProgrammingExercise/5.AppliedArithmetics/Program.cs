int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

string command = Console.ReadLine();

Action<int[]> print = num => Console.WriteLine(string.Join(" ", num));
Func<string, int, int> operation = (command, n) =>
{
    if (command == "add")
        return n + 1;
    else if (command == "multiply")
        return n * 2;
    else if (command == "subtract")
        return n - 1;
    else
        return n;
};

while (command != "end")
{
    if (command == "print")
        print(numbers);
    else
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = operation(command, numbers[i]);
        }
    }
    command = Console.ReadLine();
}