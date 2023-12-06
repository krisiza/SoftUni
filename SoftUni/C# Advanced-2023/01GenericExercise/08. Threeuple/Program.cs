namespace _01GenericBoxofString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tuple> list = new();

            Tuple tuple = new();

            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 4)
            {
                tuple.FirstProperty = $"{tokens[0]} {tokens[1]}";
                tuple.SecondProperty = tokens[2];
                tuple.ThirdProperty = tokens[3];
            }
            else if(tokens.Length == 5) 
            {
                tuple.FirstProperty = $"{tokens[0]} {tokens[1]}";
                tuple.SecondProperty = tokens[2];
                tuple.ThirdProperty = $"{tokens[3]} {tokens[4]}";
            }

            list.Add(tuple);

            Tuple tuple2 = new();

            tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            tuple2.FirstProperty = tokens[0];
            tuple2.SecondProperty = double.Parse(tokens[1]);
            if (tokens[2] == "drunk")
                tuple2.ThirdProperty = true;
            else
                tuple2.ThirdProperty = false;

            list.Add(tuple2);

            Tuple tuple3 = new();

            tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            tuple3.FirstProperty = tokens[0];
            tuple3.SecondProperty = double.Parse(tokens[1]);
            tuple3.ThirdProperty = tokens[2];

            list.Add(tuple3);

            foreach(var item in list) 
            {
                Console.WriteLine($"{item.FirstProperty} -> {item.SecondProperty} -> {item.ThirdProperty}");
            }
        }
    }
}