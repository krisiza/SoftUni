int foodQuantity = int.Parse(Console.ReadLine());

Queue<int> orders = new (Console.ReadLine()
    .Split()
    .Select(int.Parse));

Console.WriteLine(orders.Max());

while (orders.Any())
{
    int currentOrder = orders.Peek();

    if (currentOrder <= foodQuantity)
    {
        orders.Dequeue();
        foodQuantity -= currentOrder;
    }
    else
        break; 
}

if (orders.Count == 0)
    Console.WriteLine("Orders complete");
else
    Console.WriteLine($"Orders left: {String.Join(" ", orders)}");
