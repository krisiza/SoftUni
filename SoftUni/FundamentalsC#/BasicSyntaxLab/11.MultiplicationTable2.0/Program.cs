int input = int.Parse(Console.ReadLine());
int multiplier = int.Parse(Console.ReadLine());

if (multiplier >= 10)
    Console.WriteLine($"{input} X {multiplier} = {input * multiplier}");
else
{
    for(int i = multiplier; i <= 10; i++)
    {
        Console.WriteLine($"{input} X {i} = {input * i}");
    }
}
