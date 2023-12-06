using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsuption { get; }

        double TankCapacity { get; }

        string Drive(double distance);

        string DriveEmpty(double distance);
        void Refuel(double fuel);
    }
}
