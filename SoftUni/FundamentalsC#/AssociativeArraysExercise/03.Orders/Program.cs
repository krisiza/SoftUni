using System;
using System.Collections.Generic;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string ,Dictionary<decimal, int>> product = new Dictionary<string ,Dictionary<decimal, int>>();
            while(input != "buy")
            {
                string[] arr = input.Split();

                string productName = arr[0];
                decimal price = Convert.ToDecimal(arr[1]);
                int quantity = Convert.ToInt32(arr[2]);

                product[productName].Add(price, quantity);

                input = Console.ReadLine();
            }
        }
    }
}
