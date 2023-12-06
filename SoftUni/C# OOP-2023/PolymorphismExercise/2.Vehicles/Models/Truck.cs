using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vehicles.Models
{
    public class Truck : Vehicle
    {
        const double conditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsuption, double tankCapacity)
            : base(fuelQuantity, fuelConsuption, tankCapacity, conditionerConsumption)
        {
        }

        public override void Refuel(double fuel)
        {  
            double amount = fuel * 0.95;

            if (amount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (FuelQuantity + amount > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            base.Refuel(amount);
        }
    }
}
