namespace _02.SetsofElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1= new HashSet<int>();
            HashSet<int> set2= new HashSet<int>();

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int lengthSet1 = arr[0];
            int lengthSet2 = arr[1];

            for(int i = 0; i < lengthSet1; i++) 
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for(int i = 0; i< lengthSet2; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            set1.IntersectWith(set2);

            Console.WriteLine(String.Join(" ", set1));
        }
    }
}