using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        const double conditionerConsumption = 0.9;

        private double fuelConsuption;

        public Car(double fuelQuantity, double fuelConsuptionPerKm, int tankCapacity) 
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity)
        {
            this.FuelConsuptionPerKm += conditionerConsumption;
        }
    }
}
