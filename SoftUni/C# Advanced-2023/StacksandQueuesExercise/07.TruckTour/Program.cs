using System.Diagnostics.Metrics;

int n = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new (); 

FillQueue(n, pumps);

int counter = 0;

while (true)
{
    int fuelAmount = 0;
    bool foundPoint = true;
    for (int i = 0; i < n; i++)
    {
        int[] currentPump = pumps.Dequeue();
        fuelAmount += currentPump[0];
        if (fuelAmount < currentPump[1])
        {
            foundPoint = false;
        }
        fuelAmount -= currentPump[1];

        pumps.Enqueue(currentPump);
    }
    if (foundPoint)
    {
        break;
    }
    counter++;
    pumps.Enqueue(pumps.Dequeue());
}
Console.WriteLine(counter);

void FillQueue(int n, Queue<int[]> pumps)
{
    for(int i = 0; i < n; i++)
    {
        int[] currPump = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

        pumps.Enqueue(currPump);
    }
}

