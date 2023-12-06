using _1.Vehicles.Factories.Interfaces;
using _1.Vehicles.IO.Interfaces;
using _1.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Core
{
    /*
Car 30,4 0,4
Truck 99,34 0,9
5
Drive Car 500
Drive Car 13,5
Refuel Truck 10,300
Drive Truck 56,2
Refuel Car 100,2
    */
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IVehicleFactory vehicleFactory;

        private ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            IVehicle car = CreateVehicle();
            IVehicle truck = CreateVehicle();

            vehicles.Add(car);
            vehicles.Add(truck);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch(Exception ex) 
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (var vehicle in vehicles) 
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
        private IVehicle CreateVehicle()
        {
            string[] tokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));
            return car;
        }
        private void ProcessCommand()
        {
            string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if(vehicle is null)
            {
                throw new Exception("Invalid vehicle type");
            }

            if(command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double amount = double.Parse(commandTokens[2]);
                vehicle.Refuel(amount);
            }
        }
    }
}
