namespace BasicAlgorithmsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[]arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(arr, arr.Length-1));
        }
        private static int Sum(int[] nums, int index) 
        {
            if(index < 0)
            {
                return 0;
            }

            int sum = nums[index] + Sum(nums, --index);

            return sum;
        }
    }
}