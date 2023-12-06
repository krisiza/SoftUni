using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    internal class Truck : Vehicle
    {
        const double conditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsuption) 
            : base(fuelQuantity, fuelConsuption, conditionerConsumption)
        {
        }

        public override void Refuel(double fuel)
            =>  base.Refuel(fuel * 0.95);       
    }
}
