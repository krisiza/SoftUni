using System.Net.Http.Headers;

string typeOfDay = Console.ReadLine();
int age = int.Parse(Console.ReadLine());

double price = 0;
switch(typeOfDay)
{
    case "Weekday":
        if (age >= 0 && age <= 18)
            price = 12;
        else if (age <= 64 && age > 18)
            price = 18;
        else if (age <= 122 && age > 64)
            price = 12;
        else
        {
            Console.WriteLine("Error!");
            return;
        }
        break;
    case "Weekend":
        if (age >= 0 && age <= 18)
            price = 15;
        else if (age <= 64 && age > 18)
            price = 20;
        else if (age <= 122 && age > 64)
            price = 15;
        else
        {
            Console.WriteLine("Error!");
            return;
        }
        break;
    case "Holiday":
        if (age >= 0 && age <= 18)
            price = 5;
        else if (age <= 64 && age > 18)
            price = 12;
        else if (age <= 122 && age > 64)
            price = 10;
        else
        {
            Console.WriteLine("Error!");
            return;
        }
        break;

}
Console.WriteLine(price + "$");
