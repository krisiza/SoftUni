using System;
using System.Collections.Generic;

namespace _03.SpeedRacing
{
    /*
2
AudiA4 23 0,3
BMW-M2 45 0,42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End

3
AudiA4 18 0,34
BMW-M2 33 0,41
Ferrari-488Spider 50 0,47
Drive Ferrari-488Spider 97
Drive Ferrari-488Spider 35
Drive AudiA4 85
Drive AudiA4 50
End
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for(int i = 0; i < n; i++) 
            {
                string[] arr = Console.ReadLine().Split();

                string model = arr[0];
                decimal fuelAmount = decimal.Parse(arr[1]);
                decimal fuelConsum = decimal.Parse(arr[2]);

                Car car = new Car(model, fuelAmount, fuelConsum);
                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End") 
            {
                string[] arr = input.Split();

                string model = arr[1];
                decimal km = decimal.Parse(arr[2]);

                var currCar = cars.Find(x => x.Model== model);

                currCar.MoveCar(km);

                input = Console.ReadLine();
            }

            cars.ForEach(x => { Console.WriteLine($"{x.Model} {x.FuelAmount:f2} {x.TraveledDistance}"); });
        }
    }
    class Car
    {
        public Car(string model, decimal fuelAmount, decimal fuelConsumprionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumprionPerKm;
        }
        public void  MoveCar(decimal km)
        {
            decimal temp = FuelAmount;
            if(FuelAmount > 0)
            {
                FuelAmount -= km * FuelConsumptionPerKm;
                if(FuelAmount< 0)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                    FuelAmount = temp;
                    return;
                }    
                TraveledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumptionPerKm { get; set;}
        public decimal TraveledDistance { get; set; }
    }
}
