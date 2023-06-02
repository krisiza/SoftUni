using System;

namespace _05.SuppliesforSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pen = int.Parse(Console.ReadLine());
            int edding = int.Parse(Console.ReadLine());
            int cleaner = int.Parse(Console.ReadLine());
            double discount = int.Parse(Console.ReadLine());

            double penPrice = pen * 5.80;
            double eddingPrice = edding * 7.20;
            double cleanerPrice = cleaner * 1.20;

            double sum = penPrice + eddingPrice + cleanerPrice;
            discount /= 100;
            discount = sum * discount;
            double discountPrice = sum - discount;
            Console.WriteLine(discountPrice);
        }
    }
}
