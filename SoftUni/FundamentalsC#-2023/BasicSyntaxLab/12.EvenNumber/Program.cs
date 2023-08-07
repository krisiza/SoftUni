bool evenNumber = false;

while(!evenNumber)
{
    int input = int.Parse(Console.ReadLine());

    if(input % 2 == 0)
    {
        evenNumber = true;
        Console.WriteLine($"The number is: {Math.Abs(input)}");
    }
    else
        Console.WriteLine("Please write an even number.");

}
