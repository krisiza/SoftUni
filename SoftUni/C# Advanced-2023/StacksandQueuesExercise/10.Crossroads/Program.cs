int greeenLightDuration = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());

string input = Console.ReadLine();
Queue<string> queue = new Queue<string>();

bool succes = true;
int counter = 0;

while (input != "END")
{
    int greenL = greeenLightDuration;
    if (input == "green")
    {
        while (queue.Any() && greenL > 0)
        {
            string currentCar = queue.Dequeue();
            int currentCarLength = currentCar.Length;

            int result = greenL - currentCarLength;
            greenL -= currentCarLength;

            if (result < 0)
            {
                //FreeWindow
                result += freeWindowDuration;

                if (result < 0)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length + result]}.");
                    succes = false;
                    break;
                }
                else
                    counter++;
            }
            else
                counter++;

            if (!succes)
                break;
        }
    }
    else
    {
        queue.Enqueue(input);
    }

    if (!succes)
        break;

    input = Console.ReadLine();
}

if (succes)
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{counter} total cars passed the crossroads.");
}