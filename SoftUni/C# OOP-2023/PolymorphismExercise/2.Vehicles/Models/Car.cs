using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vehicles.Models
{
    public class Car : Vehicle
    {
        const double conditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsuption, double tankCapacity)
            : base(fuelQuantity, fuelConsuption, tankCapacity, conditionerConsumption)
        {

        }
    }
}
