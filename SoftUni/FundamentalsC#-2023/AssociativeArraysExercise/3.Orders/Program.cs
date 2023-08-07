using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dic = new Dictionary<string, List<decimal>>();

            while (input != "buy")
            {
                string[] arr = input.Split();

                string productName = arr[0];
                decimal price = Convert.ToDecimal(arr[1]);
                int quantity = Convert.ToInt32(arr[2]);

                if(dic.ContainsKey(productName)) 
                {
                    dic[productName][0] = price;
                    dic[productName][1] += quantity;
                }
                else
                {
                    dic.Add(productName, new List<decimal>() { price, quantity});
                }          

                input = Console.ReadLine();
            }
            foreach(var d in dic)
            {
                Console.WriteLine($"{d.Key} -> {(d.Value[0] * d.Value[1]):f2}");
            }
        }
    }

}
