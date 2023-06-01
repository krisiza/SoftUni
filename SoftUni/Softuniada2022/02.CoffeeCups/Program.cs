int n = int.Parse(Console.ReadLine());
string name = Console.ReadLine();

for(int row = 1; row <= n; row++)
{
    Console.Write(new string(' ', n));

    for (int i = 1; i <= 3; i++)
    {
        Console.Write('~');
        Console.Write(' ');
    }

    Console.WriteLine();
}

int width = ((n - 1) * 2 + 6) + 2 + (n-1);
int cupWidth = (n - 1) * 2 + 6;

Console.WriteLine(new String('=', width));

for (int row = 1; row <= (n/2)-1; row++)
{ 
    Console.Write('|');
    Console.Write(new String('~', cupWidth));
    Console.Write('|');
    Console.Write(new String(' ', n-1));
    Console.Write('|');

    Console.WriteLine();
}

int nameC = name.Length;

nameC = cupWidth - nameC;

Console.Write('|');
Console.Write(new String('~', nameC/2));
Console.Write(name.ToUpper());
Console.Write(new String('~', nameC / 2));
Console.Write('|');
Console.Write(new String(' ', n - 1));
Console.Write('|');

Console.WriteLine();

int minus = 0;

if (n % 2 == 0)
    minus = 2;
else
    minus= 1;

for (int row = 1; row <= Math.Round((double)(n / 2) - minus); row++)
{
    Console.Write('|');
    Console.Write(new String('~', cupWidth));
    Console.Write('|');
    Console.Write(new String(' ', n - 1));
    Console.Write('|');

    Console.WriteLine();
}

Console.Write(new String('=', width));

Console.WriteLine();

int interval = 0;

for(int row = 1; row <= n; row++)
{
    Console.Write(new String(' ', interval));
    interval++;

    Console.Write("\\");
    
    for(int column = 1; column <= cupWidth; column++)
    {
        Console.Write('@');
    }
    cupWidth -= 2;

    Console.Write("/");
    Console.WriteLine();

}

Console.Write(new String('-', width));
