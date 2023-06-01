using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            double discount = 0;
            switch(typeOfGroup)
            {
                case "Students":
                    if (day == "Friday")
                        price = 8.45;
                    if (day == "Saturday")
                        price = 9.8;
                    if (day == "Sunday")
                        price = 10.46;

                    if (people >= 30)                   
                        discount = price * 0.15;

                    break;
                case "Business":
                    if (day == "Friday")
                        price = 10.9;
                    if (day == "Saturday")
                        price = 15.6;
                    if (day == "Sunday")
                        price = 16;

                    if (people >= 100)
                        people -= 10;

                    break;
                case "Regular":
                    if (day == "Friday")
                        price = 15;
                    if (day == "Saturday")
                        price = 20;
                    if (day == "Sunday")
                        price = 22.50;

                    if (people >= 10 && people <= 20)
                        discount = price * 0.05;
                    break;
            }

            price -= discount;
            double totalPrice = price * people;

            Console.WriteLine($"Total price: {totalPrice:f2}");


        }
    }
}
