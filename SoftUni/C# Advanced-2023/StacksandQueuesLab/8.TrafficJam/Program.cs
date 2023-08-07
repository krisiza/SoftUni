/*
4
Hummer H2
Audi
Lada
Tesla
Renault
Trabant
Mercedes
MAN Truck
green
green
Tesla
Renault
Trabant
end
*/

int n = int.Parse(Console.ReadLine());

string commands = Console.ReadLine();

Queue<string> cars = new Queue<string>();

int counter = 0;
while (commands != "end")
{
    switch (commands)
    {
        case "green":
            for (int i = 0; i < n; i++)
            {
                if (cars.Count > 0)
                {
                    Console.WriteLine($"{cars.Dequeue()} passed!");
                    counter++;
                }
            }
            break;
        default:
            cars.Enqueue(commands);
            break;
    }

    commands = Console.ReadLine();
}

Console.WriteLine($"{counter} cars passed the crossroads.");

