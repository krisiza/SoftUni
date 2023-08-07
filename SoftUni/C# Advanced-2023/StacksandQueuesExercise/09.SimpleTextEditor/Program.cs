
Stack<char> text = new ();
int n = int.Parse(Console.ReadLine());
List<LastOperation> lastOperation = new ();

for (int i = 0; i < n; i++)
{
    string[] commands = Console.ReadLine().Split();

    switch (commands[0])
    {
        case "1":
            List<char> temp = new ();
            for(int j = 0; j < commands[1].Length ;j++)
            {
                text.Push(commands[1][j]);
                temp.Add(commands[1][j]);
            }
            LastOperation lo = new LastOperation(1,temp);
            lastOperation.Add(lo);
            break;
        case "2":
            temp = new List<char>();
            for (int j = 0; j < int.Parse(commands[1]);j++)
            {
                char t = text.Pop();
                temp.Add(t);
            }
            lo = new LastOperation(2, temp);
            lastOperation.Add(lo);
            break;
        case "3":
            List<char> list = new List<char>(text.Reverse());
            Console.WriteLine(list[int.Parse(commands[1])-1]);
            break;
        case "4":
            int op = lastOperation[lastOperation.Count - 1].Index;
            temp = lastOperation[lastOperation.Count - 1].List;
            lastOperation.Remove(lastOperation[lastOperation.Count - 1]);
            if (op == 1)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    text.Pop();
                }
            }
            else if(op == 2) 
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    text.Push(temp[j]);
                }
            }
            break;
    }
}

class LastOperation
{
    public int Index { get; set; }
    public List <char> List { get; set; }

    public LastOperation(int index, List<char> list)
    {
        Index= index;
        list.Reverse();
        List = list;
    }
}
