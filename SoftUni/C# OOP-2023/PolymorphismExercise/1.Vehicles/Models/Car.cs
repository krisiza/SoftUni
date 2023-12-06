using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public class Car : Vehicle
    {
        const double conditionerConsumption = 0.9;
      
        public Car(double fuelQuantity, double fuelConsuption) 
            : base(fuelQuantity, fuelConsuption, conditionerConsumption)
        {

        }
    }
}
