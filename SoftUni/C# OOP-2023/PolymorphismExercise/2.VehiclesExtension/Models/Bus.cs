using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsuptionPerKm, int tankCapacity) 
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity)
        {
        }


        public void IncreaseConspumtion()
        {
            FuelConsuptionPerKm += fuelConsumptionModifier;
        }

        public void DecreaseConspumtion()
        {
            FuelConsuptionPerKm -= fuelConsumptionModifier;
        }

    }
}
