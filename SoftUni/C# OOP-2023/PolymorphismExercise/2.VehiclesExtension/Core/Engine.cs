using _2.VehiclesExtension.Models.Interfaces;
using Vehicles.Models;

namespace _1.Vehicles.Core
{
    /*
Car 30 0,04 10
Truck 100 0,5 300
Bus 40 0,3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100Car 30 0,04 10
Truck 100 0,5 300
Bus 40 0,3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
Refuel Truck 1000
    */
    internal class Engine : IEngine
    {
        public void Run()
        {
            Vehicle car = null;
            Vehicle truck = null;
            Vehicle bus = null;

            string[] carTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] truckTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] busTokens = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), int.Parse(carTokens[3]));
                truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), int.Parse(truckTokens[3]));
                bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), int.Parse(busTokens[3]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (tokens[0])
                    {
                        case "Drive":
                            if (tokens[1] == "Truck")
                            {
                                truck.Drive(double.Parse(tokens[2]));
                            }
                            else if (tokens[1] == "Car")
                            {
                                car.Drive(double.Parse(tokens[2]));
                            }
                            else
                            {
                                Bus myBus = (Bus)bus;
                                myBus.IncreaseConspumtion();
                                bus.Drive(double.Parse(tokens[2]));
                                myBus.DecreaseConspumtion();
                            }
                            break;

                        case "Refuel":
                            try
                            {
                                if (tokens[1] == "Truck")
                                {
                                    truck.Refuel(double.Parse(tokens[2]));
                                }
                                else if (tokens[1] == "Car")
                                {
                                    car.Refuel(double.Parse(tokens[2]));
                                }
                                else
                                {
                                    bus.Refuel(double.Parse(tokens[2]));
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case "DriveEmpty":
                            bus.Drive(double.Parse(tokens[2]));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
