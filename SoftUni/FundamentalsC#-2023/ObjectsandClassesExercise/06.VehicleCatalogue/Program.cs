using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Vehicle> catalogue = new List<Vehicle>();

            while (input != "End")
            {
                string[] arr = input.Split();
      
                string typeOfVehicle = arr[0];
                string model = arr[1];
                string color = arr[2];
                decimal horsepower = decimal.Parse(arr[3]);

                Vehicle vehicle = new Vehicle(typeOfVehicle, model, color, horsepower);
                catalogue.Add(vehicle);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                string model = input;

                var found = catalogue.FirstOrDefault(x => x.Model == model);
                if (found != null)
                {
                    Console.WriteLine(found);
                }

                input = Console.ReadLine();
            }

            decimal averageHP = catalogue
                    .Where(x => x.Type == Type.Car)
                    .Select(x => x.Horsepower)
                    .DefaultIfEmpty()
                    .Average();
            Console.WriteLine($"Cars have average horsepower of: {averageHP:F2}.");

            averageHP = catalogue
                .Where(vehicle => vehicle.Type == Type.Truck)
                .Select(vehicle => vehicle.Horsepower)
                .DefaultIfEmpty()
                .Average();
            Console.WriteLine($"Trucks have average horsepower of: {averageHP:F2}.");
        }
    }
    public enum Type
    {
        Car,
        Truck
    }
    class Vehicle
    {
        public Type Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Horsepower { get; set; }

        public Vehicle(string type, string model, string color, decimal hsp)
        {
            Type = type == "car" ? Type.Car : Type.Truck;
            Model = model;
            Color = color;
            Horsepower = hsp;
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += $"Type: {Type}\nModel: {Model}\nColor: {Color}\nHorsepower: {Horsepower}";
            return result;
        }
    }
}
