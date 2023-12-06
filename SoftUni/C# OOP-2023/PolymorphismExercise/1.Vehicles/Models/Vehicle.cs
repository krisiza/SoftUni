using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsuption, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsuption = fuelConsuption;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsuption { get; private set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsuption + increasedConsumption;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= consumption * distance;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
            => FuelQuantity += fuel;

        public override string ToString() => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
