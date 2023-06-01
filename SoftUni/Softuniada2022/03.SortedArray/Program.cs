int nArray = int.Parse(Console.ReadLine());

int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


int temp = 0;


for (int i = 0; i < numbers.Length-1; i++)
{
    for (int j = 0; j < numbers.Length - (1+i); j++)
    {
        if (j % 2 == 0)
        {
            if (numbers[j] <= numbers[j + 1])
            {
                temp = numbers[j + 1];
                numbers[j + 1] = numbers[j];
                numbers[j] = temp;
            }
        }
        else
        {

            if (numbers[j] >= numbers[j + 1])
            {
                temp = numbers[j + 1];
                numbers[j + 1] = numbers[j];
                numbers[j] = temp;
            }

        }
    }
}


foreach (int i in numbers)
{
    Console.Write(i + " ");
}