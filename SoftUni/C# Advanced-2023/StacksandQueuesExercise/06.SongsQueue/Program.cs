Queue<string> songsQueue = new (Console.ReadLine().Split(", "));

while(songsQueue.Any())
{
    string commands = Console.ReadLine();

    if (commands == "Play")
        songsQueue.Dequeue();
    else if (commands.Contains("Add"))
    {
        string song = commands.Remove(0, 4);
        if (!songsQueue.Contains(song))
            songsQueue.Enqueue(song);
        else
            Console.WriteLine($"{song} is already contained!");
    }
    else if (commands == "Show")
        Console.WriteLine(String.Join(", ",songsQueue));
}

Console.WriteLine("No more songs!");
