using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phrase = new List<string>();
            List<string> eventt = new List<string>();
            List<string> author = new List<string>();
            List<string> city = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Random random= new Random();
                Console.WriteLine($"{Phrase()[random.Next(0, Phrase().Count)]} {Events()[random.Next(0, Events().Count)]} {Authors()[random.Next(0, Authors().Count)]} – {Cities()[random.Next(0, Cities().Count)]}.");
            }

        }
        public static List<string> Phrase()
        {
            List<string> list = new List<string>();

            list.Add("Excellent product.");
            list.Add("Such a great product.");
            list.Add("I always use that product.");
            list.Add("Best product of its category.");
            list.Add("Exceptional product.");
            list.Add("I can't live without this product.");

            return list;
        }
        public static List<string> Events()
        {
            List<string> list = new List<string>();

            list.Add("Now I feel good.");
            list.Add("I have succeeded with this product.");
            list.Add("Makes miracles. I am happy of the results!");
            list.Add("I cannot believe but now I feel awesome.");
            list.Add("Try it yourself, I am very satisfied.");
            list.Add("I feel great!");

            return list;
        }
        public static List<string> Authors()
        {
            List<string> list = new List<string>();

            list.Add("Diana");
            list.Add("Petya");
            list.Add("Stella");
            list.Add("Elena");
            list.Add("Katya");
            list.Add("Iva");
            list.Add("Katya");
            list.Add("Eva");

            return list;
        }
        public static List<string> Cities()
        {
            List<string> list = new List<string>();

            list.Add("Burgas");
            list.Add("Sofia");
            list.Add("Plovdiv");
            list.Add("Varna");
            list.Add("Ruse");

            return list;
        }
    }
}
