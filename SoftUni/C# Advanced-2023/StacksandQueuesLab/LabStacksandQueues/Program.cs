string input = Console.ReadLine();
Stack<char> chars= new Stack<char>(input);

foreach(char c in chars)
    Console.Write(c);
