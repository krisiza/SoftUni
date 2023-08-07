int[] cupCapacity = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int[] filledBottles = Console.ReadLine()
    .Split()
    .Select(int.Parse) 
    .ToArray();

Stack<int> cups = new Stack<int>(cupCapacity.Reverse());
Queue<int> bottles = new Queue<int>(filledBottles.Reverse());

int wastedWater = 0;

while(cups.Any() && bottles.Any())
{
    int currentCup = cups.Pop();
    int currentBottle = bottles.Dequeue();

    int result = currentBottle - currentCup;

    if(result >= 0)
        wastedWater+= result;
    else
    {
        cups.Push(Math.Abs(result));
    }
}

if (cups.Count <= 0)
{
    Console.Write($"Bottles: ");
    Console.WriteLine(String.Join(" ", bottles));
}
else
{
    Console.Write($"Cups: ");
    Console.WriteLine(String.Join(" ", cups));
}

Console.WriteLine($"Wasted litters of water: {wastedWater}");
