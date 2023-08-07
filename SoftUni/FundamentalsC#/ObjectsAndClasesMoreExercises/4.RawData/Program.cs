using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _4.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars= new List<Car>();

            for(int i = 0; i < n; i++) 
            {
                string[] arr = Console.ReadLine().Split();

                string model = arr[0];
                double engineSpeed = double.Parse(arr[1]);
                double enginePower = double.Parse(arr[2]);
                double cargoWeight = double.Parse(arr[3]);
                string cargoType = arr[4];

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            bool fragile = command == "fragile" ? true : false;
            List<Car> selectedType = new List<Car>();
            if (fragile) 
                selectedType = cars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Cargo.Weight < 1000)
                    .ToList();
            else
                selectedType = cars
                    .Where(x => x.Cargo.Type == "flamable")
                    .Where(x => x.Engine.Power > 250)
                    .ToList();

            selectedType.ForEach(x => { Console.WriteLine(x.Model); });
        }
    }
    class Car
    {
        public Car(string model, double engineSpeed, double enginePower, double cargoWeight, string cargoType)
        {
            Engine = new Engine();
            Cargo = new Cargo();

            Model = model;
            Engine.Speed= engineSpeed;
            Engine.Power = enginePower;
            Cargo.Weight= cargoWeight;
            Cargo.Type= cargoType;
        }

        public string Model { get; set; }
        public Engine Engine{ get; set; }

        public Cargo Cargo { get; set; }
    }
    class Engine
    {
        public double Speed { get; set; }
        public double Power { get; set; }
    }
    class Cargo
    {
        public double Weight { get; set; }
        public string Type { get; set; }
    }
}
