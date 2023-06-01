int num = int.Parse(Console.ReadLine());

int counter = 0;
int sumOdd = 0;
for(int i = 1; i < int.MaxValue;i++)
{
    if (i % 2 == 1)
    {
        Console.WriteLine(i);
        sumOdd += i;
        counter++;
    }

    if (counter == num)
        break;
}

Console.WriteLine("Sum: " + sumOdd);
