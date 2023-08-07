using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> items = new List<Box>();
            while (input != "end")
            {
                var arr = input.Split().ToArray();

                Box box = new Box();

                box.SerialNumber = int.Parse(arr[0]);
                box.Item.Name = arr[1];
                box.ItemQuantity = int.Parse(arr[2]);
                box.Item.Price = decimal.Parse(arr[3]);

                box.PriceForABox = box.Item.Price * box.ItemQuantity;

                items.Add(box);

           

                input = Console.ReadLine();
            }

            List<Box> SortedList = items.OrderByDescending(o => o.PriceForABox).ToList();

            foreach (Box box in SortedList)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }
        }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForABox { get; set; }
    }
}
