namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Stack<string> stack = new Stack<string>();

            while(command != "END")
            {

                if (command.Contains("Push"))
                {
                    command = command.Remove(0, 5);
                    string[] arr = command.Split(", ").ToArray();

                    stack.Push(arr[0..]);
                }
                else if(command == "Pop")
                {
                    stack.Pop();
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }


        }
    }
}