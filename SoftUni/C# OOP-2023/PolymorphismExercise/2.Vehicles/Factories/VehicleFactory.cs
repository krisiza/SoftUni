using _2.Vehicles.Factories.Interfaces;
using _2.Vehicles.Models;
using _2.Vehicles.Models.Interfaces;

namespace _2.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double consumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, consumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, consumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, consumption, tankCapacity);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
