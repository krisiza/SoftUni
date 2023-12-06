using _2.Vehicles.Core.Interfaces;
using _2.Vehicles.Factories.Interfaces;
using _2.Vehicles.IO.Interfaces;
using _2.Vehicles.Models;
using _2.Vehicles.Models.Interfaces;

namespace _2.Vehicles.Core
{
    /*
Car 30 0,04 70
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

Car 30,4 0,4 1000
Truck 99,34 0,9 1000
Bus 40 0,3 150
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

            vehicles= new List<IVehicle>();
        }
        public void Run()
        {
            IVehicle car = null;
            IVehicle truck = null;
            IVehicle bus = null;

            try
            {
                car = CreateVehicle();
                truck = CreateVehicle();
                bus = CreateVehicle();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);               
            }

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
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

            IVehicle vehicle = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
            return vehicle;
        }
        private void ProcessCommand()
        {
            string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle is null)
            {
                throw new Exception("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "DriveEmpty")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.DriveEmpty(distance));
            }
            else if (command == "Refuel")
            {
                double amount = double.Parse(commandTokens[2]);
                vehicle.Refuel(amount);
            }
        }
    }
}
