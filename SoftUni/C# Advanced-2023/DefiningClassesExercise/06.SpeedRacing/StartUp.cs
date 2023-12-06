using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string,Car> cars = new();

            for(int i = 0; i< n; i++) 
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionPerKilometer = double.Parse(tokens[2]);

                Car car = new Car(model,fuelAmount,fuelConsumptionPerKilometer);

                if(!cars.ContainsKey(model))
                    cars.Add(model,car);
            }

            string command = Console.ReadLine();

            while(command != "End") 
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car car = cars.FirstOrDefault(x => x.Key == carModel).Value;

                car.CalculteFuel(car, amountOfKm);

                command = Console.ReadLine();
            }

            foreach(var car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
