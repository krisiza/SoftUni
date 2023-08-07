using System;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int field = int.Parse(Console.ReadLine());

            int[] arr = new int[field];

            int[] ladyBugsarr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < ladyBugsarr.Length; i++)
            {
                if (ladyBugsarr[i] >= 0 && ladyBugsarr[i] <= arr.Length - 1)
                    arr[ladyBugsarr[i]] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandArr = input.Split();

                int bugPosition = Convert.ToInt32(commandArr[0]);
                string command = commandArr[1];
                int bugSteps = Convert.ToInt32(commandArr[2]);

                if (bugPosition <= arr.Length - 1 && bugPosition >= 0 && arr[bugPosition] == 1)
                {
                    int index = 0;
                    arr[bugPosition] = 0;

                    if (command == "right")
                    {
                        index = bugPosition + bugSteps;

                        if (index < arr.Length)
                        {
                            if (arr[index] != 1)
                                arr[index] = 1;
                            else
                            {
                                while (true)
                                {
                                    index += bugSteps;

                                    if (index > arr.Length - 1)
                                        break;

                                    if (arr[index] != 1)
                                    {
                                        arr[index] = 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (command == "left")
                    {

                        index = bugPosition - bugSteps;

                        if (index >= 0)
                        {
                            if (arr[index] != 1)
                                arr[index] = 1;
                            else
                            {
                                while (true)
                                {
                                    index -= bugSteps;

                                    if (index < 0)
                                        break;

                                    if (arr[index] != 1)
                                    {
                                        arr[index] = 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
