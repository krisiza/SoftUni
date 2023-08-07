Stack<int> box = new Stack<int>(Console.ReadLine()
    .Split()
    .Select(int.Parse));

int rackCapacity = int.Parse(Console.ReadLine());

int rackSum = 0;
int racks = 1;

while(box.Any())
{
    int currentBox = box.Pop();

    if(rackSum + currentBox <= rackCapacity)
    {
        rackSum += currentBox;
    }
    else
    {
        racks++;
        rackSum = currentBox;
    }
}

Console.WriteLine(racks);
