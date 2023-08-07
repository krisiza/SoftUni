int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());

Stack<int> bullets = new(Console.ReadLine()
    .Split()
    .Select(int.Parse));
Queue <int> locks = new(Console.ReadLine()
    .Split()
    .Select(int.Parse));

int intelligenceValue = int.Parse(Console.ReadLine());

int bulletCounter = 0;

Queue<int> bulletsInGunBarrel = new ();

bool noMoreLocks = false;

for (int i = 0; i < gunBarrelSize && bullets.Count > 0; i++)
{
    bulletsInGunBarrel.Enqueue(bullets.Pop());
}

while (bullets.Count >= 0)
{
    while (bulletsInGunBarrel.Any())
    {
        int currentLock = 0;

        if (locks.Any())
            currentLock = locks.Peek();
        else
        {
            noMoreLocks = true;
            break;
        }
        int currentBullet = bulletsInGunBarrel.Dequeue();
        bulletCounter++;

        if (currentBullet <= currentLock)
        {
            locks.Dequeue();
            Console.WriteLine("Bang!");
        }
        else
            Console.WriteLine("Ping!");
    }

    if (noMoreLocks)
        break;

    //Load gunBarrel
    if (bullets.Count > 0 && !noMoreLocks)
    {
        Console.WriteLine("Reloading!");
        for (int i = 0; i < gunBarrelSize && bullets.Count > 0; i++)
        {
            bulletsInGunBarrel.Enqueue(bullets.Pop());
        }
    }
    else
        break;
}

if (locks.Count == 0)
{
    int moneyEarned = intelligenceValue - bulletCounter * bulletPrice;
    Console.WriteLine($"{bullets.Count + bulletsInGunBarrel.Count} bullets left. Earned ${moneyEarned}");
}
else
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");


