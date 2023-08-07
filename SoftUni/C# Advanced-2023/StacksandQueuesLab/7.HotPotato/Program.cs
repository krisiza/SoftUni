string[] names = Console.ReadLine()
    .Split();
int passes = int.Parse(Console.ReadLine());

Queue<string> queue = new Queue<string>(names);

while(queue.Count > 1)
{
    for(int i = 0; i < passes-1;i++)
    {
        string name = queue.Dequeue();
        queue.Enqueue(name);
    }
    Console.WriteLine($"Removed {queue.Dequeue()}");
}

string result = queue.Peek();
Console.WriteLine($"Last is {result}");
