using System.Runtime.CompilerServices;

int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());

List<int> list1nod = new List<int>();
List<int> list2nod = new List<int>();

for (int i = 1; i <= num1;i++)
{
    if(num1 % i == 0)
    {
        list1nod.Add(i);
    }
}

for (int i = 1; i <= num2; i++)
{
    if (num2 % i == 0)
    {
        list2nod.Add(i);
    }
}

int nod = 0;

foreach(int number1 in list1nod)
{
    foreach(int number2 in list2nod)
    {
        if(number1 == number2)
        {
            if(number2 > nod) 
            {
                nod = number2;
            }           
        }
    }
}


List<int> list1nok = new List<int>();
List<int> list2nok = new List<int>();


for (int i = num1; i <= num1*10000;i++)
{
    if(i % num1 == 0) 
    {
        list1nok.Add(i);
    }
}

for (int i = num2; i <= num2 * 10000; i++)
{
    if (i % num2 == 0)
    {
        list2nok.Add(i);
    }
}

int nok = int.MaxValue;

foreach (int number1 in list1nok)
{
    foreach (int number2 in list2nok)
    {
        if (number1 == number2)
        {
            if (number2 < nok)
            {
                nok = number2;
            }
        }
    }
}

Console.WriteLine(nok + nod);
