int[] numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Queue<int> queue = new Queue<int>(numbers);

for(int i = 0; i < numbers.Length;i++)
{
    int number = queue.Dequeue();

    if(number % 2 == 0)
        queue.Enqueue(number);
}

Console.WriteLine(String.Join(", ", queue));
