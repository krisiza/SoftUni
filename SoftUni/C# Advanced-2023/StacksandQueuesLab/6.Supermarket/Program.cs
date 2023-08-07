string[] inputStrings = Console.ReadLine()
    .Split('\n');

Queue<string> customers = new Queue<string>();

while (inputStrings[0] != "End")
{
    switch (inputStrings[0])
    {
        case "Paid":
            while (customers.Any())
                Console.WriteLine(customers.Dequeue());
            break;
        default:
            customers.Enqueue(inputStrings[0]);
            break;
    }

    inputStrings = Console.ReadLine()
    .Split('\n');
}

Console.WriteLine($"{customers.Count} people remaining.");


