using _1.Vehicles.Factories.Interfaces;
using _1.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double consumption)
        {
            switch(type)
            {
                case "Car":
                    return new Car(fuelQuantity, consumption);
                case "Truck":
                    return new Truck(fuelQuantity, consumption);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
