using _2.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vehicles.Models
{
    public class Bus : Vehicle
    {
        const double conditionerConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsuption,double tankCapacity) 
            : base(fuelQuantity, fuelConsuption, tankCapacity, conditionerConsumption)
        {

        }
    }
}
