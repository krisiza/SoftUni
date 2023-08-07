using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();


            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command.Contains("exchange"))
                    arr = Exchange(arr, command);

                if (command == "max even")
                    MaxEven(arr);

                if (command == "max odd")
                    MaxOdd(arr);

                if (command == "min even")
                    MinEven(arr);

                if (command == "min odd")
                    MinOdd(arr);

                if (command.Contains("first") && command.Contains("even"))
                    FirstEvenCount(arr, command);

                if (command.Contains("first") && command.Contains("odd"))
                    FirstOddCount(arr, command);

                if (command.Contains("last") && command.Contains("even"))
                    LastEvenCount(arr, command);

                if (command.Contains("last") && command.Contains("odd"))
                    LastOddCount(arr, command);

                command = Console.ReadLine();
            }

            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.WriteLine("]");
        }
        private static int[] Exchange(int[] arr, string command)
        {
            List<int> list = new List<int>();
            int[] arr2;

            string[] a = command.Split();

            int index = Convert.ToInt32(a[a.Length - 1]);         

            if (index < 0 || index >= arr.Length)
                Console.WriteLine("Invalid index");
            else
            {
                index += 1;
                arr2 = arr.Skip(index).ToArray();

                for (int i = 0; i < arr2.Length; i++)
                {
                    list.Add(arr2[i]);
                }

                arr2 = arr.Take(index).ToArray();

                for (int i = 0; i < arr2.Length; i++)
                {
                    list.Add(arr2[i]);
                }

                return arr = list.ToArray();
            }
            return arr;
        }

        private static void MaxEven(int[] arr)
        {
            int maxNum = 0;
            int maxIndex = 0;
            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] >= maxNum)
                    {
                        maxNum = arr[i];
                        maxIndex = i;
                        found = true;
                    }
                }
            }
            if (found)
                Console.WriteLine(maxIndex);
            else
                Console.WriteLine("No matches");
        }

        private static void MaxOdd(int[] arr)
        {
            int maxNum = 0;
            int maxIndex = 0;
            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    if (arr[i] >= maxNum)
                    {
                        maxNum = arr[i];
                        maxIndex = i;
                        found = true;
                    }
                }
            }
            if (found)
                Console.WriteLine(maxIndex);
            else
                Console.WriteLine("No matches");
        }

        private static void MinEven(int[] arr)
        {
            int minNum = int.MaxValue;
            int minIndex = 0;
            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] <= minNum)
                    {
                        minNum = arr[i];
                        minIndex = i;
                        found = true;
                    }
                }
            }
            if (found)
                Console.WriteLine(minIndex);
            else
                Console.WriteLine("No matches");
        }

        private static void MinOdd(int[] arr)
        {
            int minNum = int.MaxValue;
            int minIndex = 0;
            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    if (arr[i] <= minNum)
                    {
                        minNum = arr[i];
                        minIndex = i;
                        found = true;
                    }
                }
            }
            if (found)
                Console.WriteLine(minIndex);
            else
                Console.WriteLine("No matches");
        }

        private static void FirstEvenCount(int[] arr, string command)
        {
            List<int> ints = new List<int>();
            string[] a = command.Split();

            int index = Convert.ToInt32(a[a.Length - 2]);

            if (index <= 0 || index > arr.Length)
                Console.WriteLine("Invalid count");
            else
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {

                    if (arr[i] % 2 == 0)
                    {
                        ints.Add(arr[i]);

                        count++;

                        if (count == index)
                            break;
                    }
                }

                Console.Write("[");
                Console.Write(String.Join(", ", ints));
                Console.WriteLine("]");
            }
        }

        private static void FirstOddCount(int[] arr, string command)
        {
            List<int> ints = new List<int>();
            string[] a = command.Split();

            int index = Convert.ToInt32(a[a.Length - 2]);

            if (index <= 0 || index > arr.Length)
                Console.WriteLine("Invalid count");
            else
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {

                    if (arr[i] % 2 == 1)
                    {
                        ints.Add(arr[i]);

                        count++;

                        if (count == index)
                            break;
                    }
                }

                Console.Write("[");
                Console.Write(String.Join(", ", ints));
                Console.WriteLine("]");
            }

        }

        private static void LastEvenCount(int[] arr, string command)
        {
            List<int> ints = new List<int>();
            string[] a = command.Split();

            int index = Convert.ToInt32(a[a.Length - 2]);

            if (index <= 0 || index > arr.Length)
                Console.WriteLine("Invalid count");
            else
            {
                int count = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {

                    if (arr[i] % 2 == 0)
                    {
                        ints.Add(arr[i]);

                        count++;

                        if (count == index)
                            break;
                    }
                }

                Console.Write("[");
                Console.Write(String.Join(", ", ints));
                Console.WriteLine("]");
            }
        }

        private static void LastOddCount(int[] arr, string command)
        {
            List<int> ints = new List<int>();
            string[] a = command.Split();

            int index = Convert.ToInt32(a[a.Length - 2]);

            if (index <= 0 || index > arr.Length)
                Console.WriteLine("Invalid count");
            else
            {
                int count = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {

                    if (arr[i] % 2 == 1)
                    {
                        ints.Add(arr[i]);

                        count++;

                        if (count == index)
                            break;
                    }
                }

                Console.Write("[");
                Console.Write(String.Join(", ", ints));
                Console.WriteLine("]");
            }
        }
    }
}
